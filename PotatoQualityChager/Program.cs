using System;
using System.IO;

namespace PotatoQualityChager
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            if (!File.Exists(Constance.UserFile))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("GameUserSettings.ini Not Found");
                Console.ResetColor();
                Console.WriteLine("Please Put this file into the right path ...");
                Console.ReadLine();
                return;
            }

            if (!Directory.Exists(Constance.UserSettingFolder))
            {
                Directory.CreateDirectory(Constance.UserSettingFolder);
            }

            if (!File.Exists(Constance.CopyDestination))
            {
                File.Copy(Constance.UserFile, Constance.CopyDestination);
            }

            Console.WriteLine("Chose your menu ...");
            Console.WriteLine(
                "1 => default setup (60% 3D resolution - 2 => Custom 3D resolution - 3 => Reset Setting)");
            int choseSetup = Convert.ToInt16(Console.ReadLine());
            switch (choseSetup)
            {
                case 1:
                {
                    Servises.Changer(60);
                    break;
                }
                case 2:
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Please Enter 3D resolution value (100-0)");
                    int resolution = Convert.ToInt16(Console.ReadLine());
                    Console.ResetColor();
                    Servises.Changer(resolution);
                    break;
                }
                case 3:
                {
                    Servises.Restore();
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}