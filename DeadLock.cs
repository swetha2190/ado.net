using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace MULTITREADING
{
    class DeadLock
    {
        static object obj = 0;
        public void write()
        {
            Monitor.Enter(obj);

            lock (this)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(new FileStream(@"C:\csharp\datafile.txt", FileMode.Append,
                    FileAccess.Write, FileShare.None));
                    sw.BaseStream.Seek(0, SeekOrigin.End);

                    Console.WriteLine("enter a sentence");
                    string s = Console.ReadLine();
                    sw.Write(s);
                    sw.Flush();
                    sw.Close();
                }
                catch (IOException e)
                {
                    Console.WriteLine();
                }
                Monitor.Exit(obj);
            }
        }

        public static  void read()
        {
            Monitor.Enter(obj);
            try
            {
                StreamReader sr = new StreamReader(new FileStream(@"C:\csharp\datafile.txt", FileMode.OpenOrCreate,
                    FileAccess.Read, FileShare.None));

                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                String s = sr.ReadToEnd();
                Console.WriteLine(s);
                sr.Close();
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }
            Monitor.Exit(obj);

        }
    }

    class runner
    {
        static void Main(string[] args)
        {
            DeadLock d = new DeadLock();


            Thread t1 = new Thread(d.write);
            ThreadStart ts = new ThreadStart(DeadLock.read);
            Thread t2 = new Thread(ts);
            d.write();
            t1.Start();
            t2.Start();
            DeadLock.read();
            Console.ReadKey();
        }
    }
}
