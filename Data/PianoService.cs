using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace MusicAuthenticationSystem.Data
{
    public class PianoService
    {
        public string firstPass;
        public string secondPass;
        private Stopwatch watch = new Stopwatch();
        private string[] notes = { "c", "cs", "d", "ds", "e", "f", "fs", "g", "gs", "a", "as", "b" };

        public List<string> PianoNotes ()
        {
            int noteSize = 37;
            List<string> newNotes = new List<string>();
            int pos = 0;
            int oct = 3;
            for(int i = 0; i < noteSize; i++)
            {
                if(pos >= 12)
                {
                    pos = 0;
                    oct++;
                }

                string n = CreateNote(notes[pos], oct);
                newNotes.Add(n);
                pos++;
            }

            return newNotes;
        }

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

        public int StartNote()
        {
            if(Convert.ToInt32(watch.ElapsedMilliseconds) != 0)
            {
                int timer = NoteEnd();
                watch.Restart();
                return timer;
            } else
            {
                watch.Start();
                return 1000;
            }
        }

        public void StopTimer()
        {
            watch.Reset();
        }

        private int NoteEnd()
        {
            watch.Stop();
            TimeSpan stopped = watch.Elapsed;
            int time = Convert.ToInt32(stopped.TotalMilliseconds);
            return time;
        }

        private string CreateNote(string note, int oct)
        {
            int length = note.Length == 1 ? 1 : 2;
            if(length == 1)
            {
                return note += oct.ToString();
            } else
            {
                return note.Replace("s", oct.ToString() + "s");
            }
        }
    }
}
