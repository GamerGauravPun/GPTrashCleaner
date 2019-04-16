using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace GPTrashCleaner
{
    class Program
    {
        static float Percent;

        static List<string> otherFiles;

        static void Main(string[] args)
        {
            Welcome(Environment.UserName);
            otherFiles = new List<string>();
        }

        static void Welcome(string name) {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  # You want to clean trash ? " + name + "!");
            GetInfos();
        }

        static void GetInfos() {
            string[] fils = Directory.GetFiles(@"C:\Users\GauravPun\Desktop\TMP\");
            string[] fols = Directory.GetDirectories(@"C:\Users\GauravPun\Desktop\TMP\");

            for (int i = 0; i < fils.Length; i++) {
                Thread.Sleep(200);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(fils[i]);
            }

            for (int i = 0; i < fols.Length; i++) {
                Thread.Sleep(200);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(fols[i]);
            }

            Percent = (float)(fils.Length + fols.Length);
            float A = 100 / Percent;

            Console.WriteLine(A);

            Console.ReadLine();
            Delete(fils, fols);
        }

        static void Delete(string[] filesLoc, string[] foldersLoc) {
            for (int i = 0; i < filesLoc.Length; i++) {
                try
                {
                    //File.Delete(filesLoc[i]);
                }
                catch {

                }
            }

            for (int i = 0; i < filesLoc.Length; i++)
            {
                try
                {

                }
                catch {
                }
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}
