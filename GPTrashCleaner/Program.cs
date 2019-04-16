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
        static List<string> otherFiles = new List<string>();

        static void Main(string[] args)
        {
            Welcome(Environment.UserName);
        }

        static void Welcome(string name) {
            Console.WriteLine("# You want to clean trash ? " + name + "!");
            //Console.ReadLine();

            GetInfos();
        }

        static void GetInfos() {
            string[] fils = Directory.GetFiles(@"C:\Users\GAURAV~1\AppData\Local\Temp\");
            string[] fols = Directory.GetDirectories(@"C:\Users\GAURAV~1\AppData\Local\Temp\");

            for (int i = 0; i < fils.Length; i++) {
                Console.WriteLine(fils[i]);
            }

            for (int i = 0; i < fols.Length; i++) {
                Console.WriteLine(fols[i]);
            }

            Delete(fils, fols);

            Console.ReadLine();
        }

        static void Delete(string[] fileLoc, string[] folderLoc) {
            for (int i = 0; i < fileLoc.Length; i++) {
                try
                {
                    File.Delete(fileLoc[i]);
                }
                catch {

                }
            }

            for (int i = 0; i < folderLoc.Length; i++) {
                try
                {
                    Directory.Delete(folderLoc[i]);
                }
                catch
                {
                    string[] OFs = Directory.GetFiles(folderLoc[i]);
                    //otherFiles.Add(OFs[i]);
                }
            }
        }
    }
}
