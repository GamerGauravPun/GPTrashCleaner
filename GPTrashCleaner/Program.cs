using System;
using System.Threading;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace GPTrashCleaner
{
    class Program
    {
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

            Console.Title = "GP Trash Cleaner";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  # Do you want to remove trash ? " + name + "!");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("    Type: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Yes or No ! and press Enter !");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("  > ");

            DirectorySecurity dsecurity = Directory.GetAccessControl(@"C:\Windows\Prefetch");
            FileSystemAccessRule accessRule = new FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow);
            dsecurity.AddAccessRule(accessRule);

            Directory.SetAccessControl(@"C:\Windows\Prefetch", dsecurity);

            try
            {
                GetInfos();
            }
            catch {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR!");
                Console.ReadLine();
            }
        }

        static void GetInfos() {

            try
            {
                perTempFils = Directory.GetFiles(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\");
                perTempFols = Directory.GetDirectories(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\");

                tempFils = Directory.GetFiles(@"C:\Windows\Temp\");
                tempFols = Directory.GetDirectories(@"C:\Windows\Temp\");

                preFils = Directory.GetFiles(@"C:\Windows\Prefetch\");
                preFols = Directory.GetDirectories(@"C:\Windows\Prefetch\");
            }
            catch (Exception ex){
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR!!" + ex.Message);
                Console.ReadLine();
            }

            if (Console.ReadLine().ToUpper() == "YES")
            {
                Console.Clear();
                Console.Beep();
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
                    Console.ForegroundColor = ConsoleColor.DarkRed;
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
