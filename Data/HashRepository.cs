using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MusicAuthenticationSystem.Data
{
    public class HashRepository : IHash
    {
        private AesCryptoServiceProvider aes = new AesCryptoServiceProvider();

        public string Encryption(string password, byte[] IV)
        {
            byte[] passwordbytes = Encoding.ASCII.GetBytes(password);

            if (!IsSessionStarted())
            {
                GenerateKey();
            }

            ICryptoTransform transform = aes.CreateEncryptor(GetKey(), IV);

            byte[] encrypt = transform.TransformFinalBlock(passwordbytes, 0, passwordbytes.Length);
            
            string encryptedPassword = Convert.ToBase64String(encrypt);
            
            return encryptedPassword;
        }

        public string Decryption(byte[] passwordbytes, byte[] IV)
        {
            aes.Padding = PaddingMode.PKCS7;
            byte[] toDecrypt = passwordbytes;

            ICryptoTransform transform = aes.CreateDecryptor(GetKey(), IV);

            byte[] decryptedPasswordBytes = transform.TransformFinalBlock(toDecrypt, 0, toDecrypt.Length);

            string decryptedPassword = ASCIIEncoding.ASCII.GetString(decryptedPasswordBytes);

            return decryptedPassword;
        }

        public byte[] GenerateIV()
        {
            aes.GenerateIV();
            return aes.IV;
        }

        public void GenerateKey()
        {
            aes.GenerateKey();
            string storeJsonString = JsonSerializer.Serialize(aes.Key);
            File.WriteAllText("file.txt", storeJsonString);
        }

        public bool IsSessionStarted()
        {
            bool hasKey = File.Exists("file.txt");
            return hasKey;
        }

        public byte[] GetKey()
        {
            string getJsonString = File.ReadAllText("file.txt");
            return JsonSerializer.Deserialize<byte[]>(getJsonString);
        }
        
    }
}