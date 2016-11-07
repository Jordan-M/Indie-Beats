using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndieBeats_WFA
{
    class MusicLibraryMemory
    {
        // Constructor
        public MusicLibraryMemory()
        {

        }


        /* Shuffles a music List using a combination of Fisher-Yates alogrith 
         * and an algorith described here: http://keyj.emphy.de/balanced-shuffle/ */
        private void shuffleMusic(ref List<string> files)
        {
            fisherYatesShuffle(ref files);
        }

        private void fisherYatesShuffle(ref List<string> files)
        {
            Random rnd = new Random();

            for (int i = files.Capacity - 1; i > 0; i--)
            {
                int n = rnd.Next(i + 1);
                swap(ref files, i, n);
            }
        }

        private void swap(ref List<string> list, int num1, int num2)
        {
            string temp = list[num1];
            list[num1] = list[num2];
            list[num2] = temp;
        }
    }
}
