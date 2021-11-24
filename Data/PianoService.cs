using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicAuthenticationSystem.Data
{
    public class PianoService
    {
        public void SaveNote(string note, List<string> pNotes)
        {
            pNotes.Add(note);
        }


        public void ClearNotes(List<string> pNotes)
        {
            pNotes.Clear();
        }

    }
}
