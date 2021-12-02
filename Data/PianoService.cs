using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MusicAuthenticationSystem.Data
{
    public class PianoService
    {
        public string firstPass;
        public string secondPass;
        private Stopwatch watch = new Stopwatch();

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
            if((int) watch.ElapsedMilliseconds != 0)
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

        public int NoteEnd()
        {
            watch.Stop();
            TimeSpan stopped = watch.Elapsed;
            int time = Convert.ToInt32(stopped.TotalMilliseconds);
            return time;
        }

        public void StopTimer()
        {
            watch.Reset();
        }

    }
}
