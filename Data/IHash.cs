using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAuthenticationSystem.Data
{
    public interface IHash
    {
        public string Encryption(string password, byte[] IV);

        public string Decryption(byte[] passwordbytes, byte[] IV);

        public byte[] GenerateIV();
    }
}
