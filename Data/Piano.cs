using System;
using System.Collections.Generic;
using SharpDX.DirectSound;

namespace MusicAuthenticationSystem.Data
{
    public class Piano
    {
        public List<string> PlayedNotes { get; set; }

        public Piano()
        {
            PlayedNotes = new List<string>();
        }
    }
}
