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
        static string perTempLoc;
        static string tempLoc;
        static string prefetchLoc;

        static string[] perTempFils;
        static string[] perTempFols;

        static string[] tempFils;
        static string[] tempFols;

        static string[] preFils;
        static string[] preFols;

        static void Main(string[] args)
        {
            Welcome(Environment.UserName);
        }

        static void Welcome(string name) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  # Do you want to clean trash ? " + name + "!");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("    Type: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Yes or No !");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("  > ");

            try
            {
                GetInfos();
            }
            catch
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR");
            }
        }

        static void GetInfos() {

            if (Directory.GetFiles(AppContext.BaseDirectory + "LocSettings") != null)
            {
                Console.WriteLine("Found!");
                perTempLoc = File.ReadAllText(AppContext.BaseDirectory + @"LocSettings\loc1.wow");
                tempLoc = File.ReadAllText(AppContext.BaseDirectory + @"LocSettings\loc2.wow");
                prefetchLoc = File.ReadAllText(AppContext.BaseDirectory + @"LocSettings\loc3.wow");

                perTempFils = Directory.GetFiles(perTempLoc);
                perTempFols = Directory.GetDirectories(perTempLoc);

                tempFils = Directory.GetFiles(tempLoc);
                tempFols = Directory.GetDirectories(tempLoc);

                preFils = Directory.GetFiles(perTempLoc);
                preFols = Directory.GetDirectories(perTempLoc);

                Console.WriteLine(perTempLoc);
            }
            else {
                Console.WriteLine("NotFound!");
                perTempFils = Directory.GetFiles(@"C:\Users\GauravPun\Desktop\tmp\");
                perTempFols = Directory.GetDirectories(@"C:\Users\GauravPun\Desktop\tmp\");

                tempFils = Directory.GetFiles(@"C:\Users\GauravPun\Desktop\tmp2\");
                tempFols = Directory.GetDirectories(@"C:\Users\GauravPun\Desktop\tmp2\");

                preFils = Directory.GetFiles(@"C:\Users\GauravPun\Desktop\tmp3\");
                preFols = Directory.GetDirectories(@"C:\Users\GauravPun\Desktop\tmp3\");
            }


            bool errorFound = false;

            //Search for
            string[] S = new string[] {
                AppContext.BaseDirectory + @"LocSettings\loc1.wow",
                AppContext.BaseDirectory + @"LocSettings\loc2.wow",
                AppContext.BaseDirectory + @"LocSettings\loc3.wow"
            };

            try {
                string[] SSame = Directory.GetFiles(AppContext.BaseDirectory + "LocSettings");

                for (int i = 0; i < S.Length; i++)
                {
                    try
                    {
                        if (SSame[i] == S[i]){ } // Scan the files
                    }
                    catch
                    {
                        errorFound = true;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR !");

                        Console.WriteLine("NotFound : " + "loc" + (i + 1) + ".wow");
                        break;
                    }
                }
            }
            catch {
                errorFound = true;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error....!");
                Console.WriteLine("(*_*)!");
            }

            if (Console.ReadLine().ToUpper() == "YES" && !errorFound)
            {
                Console.Clear();
                Delete1(perTempFils, perTempFols);
            }
        }

        static void Delete1(string[] filesLoc, string[] foldersLoc) {

            Console.CursorVisible = false;

            for (int i = 0; i < filesLoc.Length; i++) {
                try
                {
                    Thread.Sleep(50);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    //File.Delete(filesLoc[i]);
                    Console.WriteLine(filesLoc[i]);
                }
                catch {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-_-");
                }
            }

            for (int i = 0; i < foldersLoc.Length; i++)
            {
                try
                {
                    Thread.Sleep(50);
                    //Directory.Delete(foldersLoc[i], true);
                    Console.WriteLine(foldersLoc[i]);
                }
                catch {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-_-");
                }
            }

            Delete2(tempFils, tempFols);
        }

        static void Delete2(string[] filesLoc, string[] foldersLoc)
        {

            Console.CursorVisible = false;

            for (int i = 0; i < filesLoc.Length; i++)
            {
                try
                {
                    Thread.Sleep(50);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    //File.Delete(filesLoc[i]);
                    Console.WriteLine(filesLoc[i]);
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-_-");
                }
            }

            for (int i = 0; i < foldersLoc.Length; i++)
            {
                try
                {
                    Thread.Sleep(50);
                    //Directory.Delete(foldersLoc[i], true);
                    Console.WriteLine(foldersLoc[i]);
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-_-");
                }
            }

            Delete3(preFils, preFols);
        }

        static void Delete3(string[] filesLoc, string[] foldersLoc)
        {

            Console.CursorVisible = false;

            for (int i = 0; i < filesLoc.Length; i++)
            {
                try
                {
                    Thread.Sleep(50);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    //File.Delete(filesLoc[i]);
                    Console.WriteLine(filesLoc[i]);
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-_-");
                }
            }

            for (int i = 0; i < foldersLoc.Length; i++)
            {
                try
                {
                    Thread.Sleep(50);
                    //Directory.Delete(foldersLoc[i], true);
                    Console.WriteLine(foldersLoc[i]);
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-_-");
                }
            }

            //Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Compelete!");
            Console.ReadLine();
        }
    }
}
