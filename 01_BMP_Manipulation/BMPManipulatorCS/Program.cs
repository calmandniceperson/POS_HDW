// Michael Koeppl
// 5AHIF
// 2016/2017
// HUE der Woche 01 - Bitmaps manipulieren

using System;
using System.IO;

namespace ConsoleApplication
{
    public class Program
    {
        const string USAGE_STRING = "Usage: BMPManipulator <path>";

        private static string fileName;

        public static void Main(string[] args)
        {
            if (args.Length <= 0) {
                Console.WriteLine(USAGE_STRING);
                return;
            }

            if (!File.Exists(args[0])) {
                Console.WriteLine("File " + args[0] + " does not exist");
                return;
            }

            fileName = args[0];

            if (!Directory.Exists("bitmaps")) {
                Directory.CreateDirectory("bitmaps");
            }

            // Get original bitmap
            byte[] byteArray = File.ReadAllBytes(fileName);

            Bitmap originalbmp = new Bitmap(byteArray);
            // Print original bitmap's data
            Console.WriteLine(originalbmp.ToString());

            // Perform the image manipulation and draw the current number (i) onto the bitmap
            // for every image from 0 to 9.
            for(int i = 0; i < 10; i++) {
                Bitmap bmp = new Bitmap(File.ReadAllBytes(fileName));
                bmp.draw(i);
                bmp.save(i);
            }
        }
    }
}
