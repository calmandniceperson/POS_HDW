/*
 * Michael Koeppl
 * XML reader
 * ~ 30 minutes.
 */

using System;
using System.Xml;

namespace ConsoleApplication
{
    public class Program
    {
        static bool printFormat = true;
        public static void Main(string[] args)
        {
            Console.Clear();
            XmlReader reader = XmlReader.Create("GoodGuyBadGuy.xml");
            while (reader.Read()) {
                processLine(reader);
            }
            Console.ReadKey();
        }
        
        private static void processLine(XmlReader reader) {
            switch (reader.NodeType) {
                case XmlNodeType.Element:
                printElement(reader);
                break;
            }
        }
        
        private static void printElement(XmlReader reader) {
            var port = string.Empty;
            if (reader.HasAttributes) {
                port = reader.GetAttribute("Port");
            }
            switch (reader.Name) {
                case "GoodGuys":
                printFormat = true;
                Console.Write("\nGood guys");
                break;
                case "BadGuys":
                printFormat = true;
                Console.Write("\nBad guys");
                break;
                case "IPAddress":
                if (printFormat) { Console.WriteLine(", IPAddress format:"); }
                printFormat = false;
                Console.Write("\tIPAddress: " + reader.ReadElementContentAsString());
                Console.WriteLine(!port.Equals(string.Empty) ? " Port=\""+port+"\"" : "");
                break;
                case "Hostname":
                if (printFormat) { Console.WriteLine(", Hostname format:"); }
                printFormat = false;
                Console.Write("\tHostname: " + reader.ReadElementContentAsString());
                Console.WriteLine(!port.Equals(string.Empty) ? " Port=\""+port+"\"" : "");
                break;
            }
        }
    }
}
