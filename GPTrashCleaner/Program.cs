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
            catch {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR!");
            }
            
        }

        static void GetInfos() {

            try
            {
                //Console.WriteLine("Found!");
                perTempLoc = File.ReadAllText(AppContext.BaseDirectory + @"LocSettings\loc1.wow");
                tempLoc = File.ReadAllText(AppContext.BaseDirectory + @"LocSettings\loc2.wow");
                prefetchLoc = File.ReadAllText(AppContext.BaseDirectory + @"LocSettings\loc3.wow");

                perTempFils = Directory.GetFiles(perTempLoc);
                perTempFols = Directory.GetDirectories(perTempLoc);

                tempFils = Directory.GetFiles(tempLoc);
                tempFols = Directory.GetDirectories(tempLoc);

                preFils = Directory.GetFiles(perTempLoc);
                preFols = Directory.GetDirectories(perTempLoc);
            }
            catch {
                //Console.WriteLine("NotFound!");
                Console.ForegroundColor = ConsoleColor.Red;
                perTempFils = Directory.GetFiles(@"C:\Users\GAURAV~1\AppData\Local\Temp\");
                perTempFols = Directory.GetDirectories(@"C:\Users\GAURAV~1\AppData\Local\Temp\");

                tempFils = Directory.GetFiles(@"C:\Windows\Temp\");
                tempFols = Directory.GetDirectories(@"C:\Windows\Temp\");

                preFils = Directory.GetFiles(@"C:\Windows\Prefetch\");
                preFols = Directory.GetDirectories(@"C:\Windows\Prefetch\");
            }

            if (Console.ReadLine().ToUpper() == "YES")
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
                    Thread.Sleep(20);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    File.Delete(filesLoc[i]);
                    Console.WriteLine(filesLoc[i]);
                }
                catch {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("");
                    Console.Write("> ");
                    Console.ForegroundColor = ConsoleColor.DarkRed; ;
                    Console.Write(foldersLoc[i]);
                    Console.WriteLine("");
                }
            }

            for (int i = 0; i < foldersLoc.Length; i++)
            {
                try
                {
                    Thread.Sleep(20);
                    Directory.Delete(foldersLoc[i], true);
                    Console.WriteLine(foldersLoc[i]);
                }
                catch {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("");
                    Console.Write("> ");
                    Console.ForegroundColor = ConsoleColor.DarkRed; ;
                    Console.Write(foldersLoc[i]);
                    Console.WriteLine("");
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
                    Thread.Sleep(20);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    File.Delete(filesLoc[i]);
                    Console.WriteLine(filesLoc[i]);
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("");
                    Console.Write("> ");
                    Console.ForegroundColor = ConsoleColor.DarkRed; ;
                    Console.Write(filesLoc[i]);
                    Console.WriteLine("");
                }
            }

            for (int i = 0; i < foldersLoc.Length; i++)
            {
                try
                {
                    Thread.Sleep(20);
                    Directory.Delete(foldersLoc[i], true);
                    Console.WriteLine(foldersLoc[i]);
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("");
                    Console.Write("> ");
                    Console.ForegroundColor = ConsoleColor.DarkRed; ;
                    Console.Write(foldersLoc[i]);
                    Console.WriteLine("");
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
                    Thread.Sleep(20);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    File.Delete(filesLoc[i]);
                    Console.WriteLine(filesLoc[i]);
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("");
                    Console.Write("> ");
                    Console.ForegroundColor = ConsoleColor.DarkRed; ;
                    Console.Write(filesLoc[i]);
                    Console.WriteLine("");
                }
            }

            for (int i = 0; i < foldersLoc.Length; i++)
            {
                try
                {
                    Thread.Sleep(20);
                    Directory.Delete(foldersLoc[i], true);
                    Console.WriteLine(foldersLoc[i]);
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("");
                    Console.Write("> ");
                    Console.ForegroundColor = ConsoleColor.DarkRed; ;
                    Console.Write(foldersLoc[i]);
                    Console.WriteLine("");
                }
            }

            //Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("             Compelete!");
            Console.ReadLine();
        }
    }
}
