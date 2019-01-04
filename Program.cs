using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;



namespace ATTRIBUTEproject
{
    class Program
    {

        [DllImport("kernel32.dll")]
        public static extern bool Beep(int freq, int duration);

        public static void TestBeeps()
        {
            Beep(6000, 1600); //low frequency, longer sound
            Beep(6000, 4000); //high frequency, short sound
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            TestBeeps();
        }

    }
}
