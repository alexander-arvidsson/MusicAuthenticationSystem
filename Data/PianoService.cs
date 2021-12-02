using System;
using System.Collections.Generic;

namespace MusicAuthenticationSystem.Data
{
    public class PianoService
    {
        public string firstPass;
        public string secondPass;

        public void SaveNote(string note)
        {
            firstPass = note;
        }

        public void SavePass(string first, string second)
        {
            firstPass = first ;
            secondPass = second;
        }

        public void ClearNotes(List<string> pNotes)
        {
            pNotes.Clear();
        }

    }
}
