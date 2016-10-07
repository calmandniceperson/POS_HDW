/*
 * Michael Koeppl
 * Textuhr
 * 3. Hausuebung der Woche
 */
using System;
using System.Threading;

namespace ConsoleApplication
{
    public class Program
    {
        private static System.Threading.Timer t;
        private static string[] zahlen = {null, "ein", "zwei", "drei", "vier", "fuenf", "sechs", "sieben", "acht", "neun", "zehn", "elf",
            "zwoelf", "dreizehn", "vierzehn", "fuenfzehn", "sechzehn", "siebzehn", "achtzehn", "neunzehn", "zwanzig",
            "einundzwanzig", "zweiundzwanzig", "dreiundzwanzig", "vierundzwanzig", "fuenfundzwanzig", "sechsundzwanzig",
            "siebenundzwanzig", "achtundzwanzig", "neunundzwanzig", "dreissig", "einunddreissig", "zweiunddreissig",
            "dreiunddreissig", "vierunddreissig", "fuenfunddreissig", "sechsunddreissig", "siebenunddreissig",
            "achtunddreissig", "neununddressig", "vierzig", "einundvierzig", "zweiundvierzig", "dreiundvierzig",
            "vierundvierzig", "fuenfundvierzig", "sechsundvierzig", "siebenundvierzig", "achtungvierzig",
            "neunundvierzig", "fuenfzig", "einundfuenfzig", "zweiundfuenfzig", "dreiundfuenfzig", "vierundfuenfzig",
            "fuenfundfuenfzig", "sechsundfuenfzig", "siebenundfuenfzig", "achtundfuenfzig", "neunundfuenfzig",};

        public static void Main(string[] args)
        {
            Console.Clear();

            // Create a callback method that will be called every time there
            // is a Timer tick.
            TimerCallback cb = new TimerCallback(OnMinute);

            // Calculate delay based on how much time is left until the next
            // full minute.           
            var delay = (60-DateTime.Now.Second)*1000;
            // New Timer calling cb every 60 seconds.
            t = new System.Threading.Timer(cb, null, delay, 60*1000);

            // Wait for input so the program doesn't close.
            Console.ReadKey();
        }

        private static void OnMinute(object state) {
            var time = DateTime.Now;
            string hour = String.Empty;
            if (zahlen[time.Hour] == null) {
                hour = "null";
            } else if (zahlen[time.Hour] == "ein") {
                hour = "eins";
            } else {
                hour = zahlen[time.Hour];
            }
            var minute = zahlen[time.Minute] == null ? "" : zahlen[time.Minute];
            Console.WriteLine(hour + " uhr " + minute);
        }
    }
}
