using System;
using System.IO;

namespace PotatoQualityChager
{
    public class Servises
    {
        public static void Changer(int res)
        {
            try
            {
                string[] content = File.ReadAllLines(Constance.UserFile);
                Changer(ref content, "ResolutionSizeX", "ResolutionSizeX=800");
                Changer(ref content, "ResolutionSizeY", "ResolutionSizeY=600");
                Changer(ref content, "LastUserConfirmedResolutionSizeX",
                    "LastUserConfirmedResolutionSizeX=800");
                Changer(ref content, "LastUserConfirmedResolutionSizeY",
                    "LastUserConfirmedResolutionSizeY=600");
                Changer(ref content, "sg.ResolutionQuality", $"sg.ResolutionQuality={res}.000000");
                Changer(ref content, "sg.ViewDistanceQuality", "sg.ViewDistanceQuality=1");
                Changer(ref content, "sg.AntiAliasingQuality", "sg.AntiAliasingQuality=1");
                Changer(ref content, "sg.ShadowQuality", "sg.ShadowQuality=1");
                Changer(ref content, "sg.PostProcessQuality", "sg.PostProcessQuality=1");
                Changer(ref content, "sg.TextureQuality", "sg.TextureQuality=0");
                Changer(ref content, "sg.EffectsQuality", "sg.EffectsQuality=1");
                Changer(ref content, "sg.FoliageQuality", "sg.FoliageQuality=1");
                Changer(ref content, "sg.ShadingQuality", "sg.ShadingQuality=1");
                File.WriteAllLines(Constance.UserFile, content);
                Console.WriteLine("Everything Changed !!");
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }

        private static void Changer(ref string[] array, string key, string value)
        {
            int index = Array.FindIndex(array, s => s.StartsWith(key));
            array[index] = value;
        }

        public static void Restore()
        {
            if (File.Exists(Constance.CopyDestination))
            {
                File.Delete(Constance.UserFile);
                File.Copy(Constance.CopyDestination, Constance.UserFile);
                Console.WriteLine("everything restored");
            }
            else
            {
                Console.WriteLine("file not found");
            }
        }
    }
}