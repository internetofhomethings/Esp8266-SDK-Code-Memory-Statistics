using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EspMemUsage
{
    class Program
    {
        static string RemoveSpaces(string value)
        {
            return Regex.Replace(value, @"\s+", " ");
        }
        static string MemStat(string resource, string line, int size, string delim, bool used) {
            int mem_used, mem_usedP, mem_free, mem_freeP;
            int v1, v1P, v2, v2P;
            //Extract value from line read
            string val = line.Substring(line.LastIndexOf(delim) + 1);
            val = RemoveSpaces(val).Substring(1);
            //Calculate memory used/free statistics
            v1 = int.Parse(val);
            v1P = (int)(((float)v1 / (float)size) * 100);
            v2 = size - v1;
            v2P = 100 - v1P;
            //Align results with used/free as applicable
            mem_used = used ? v1 : v2;
            mem_usedP = used ? v1P : v2P;
            mem_free = used ? v2 : v1;
            mem_freeP = used ? v2P : v1P;
            //return memory statistics as formatted string
            return resource +
                mem_used.ToString().PadLeft(8, ' ') +
                "|" +
                mem_usedP.ToString().PadLeft(12, ' ') +
                "|" +
                mem_free.ToString().PadLeft(12, ' ') +
                "|" +
                mem_freeP.ToString().PadLeft(8, ' ');
        }

        static void Main(string[] args)
        {
            int counter = 0;
            string line;
            string ram="",iram="",spi="";

            // Open the file created by "MemAnalyzer.exe".
            System.IO.StreamReader file = new System.IO.StreamReader("mem.txt");
            //Extract Memory Usage & assemble for output
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains("Total Used RAM : "))
                {
                    ram = MemStat("RAM  - Data         |      81920|", line, 81920, ":", true);
                }
                if (line.Contains("Free IRam : "))
                {
                    iram = MemStat("IRAM - Cached Code  |      32768|", line, 32768, ":", false);
                }
                if (line.Contains("Uncached Code (SPI)|"))
                {
                    spi = MemStat("SPI  - Uncached Code|     253952|", line, 253952, "|", true);
                }
                counter++;
            }
            file.Close();
            //Memory Statistics Header
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("Resource            |Size(bytes)|    Used|       %Used|        Free|   %Free");
            Console.WriteLine("--------------------|-----------|--------|------------|------------|----------");
            //Output statistics in this order
            Console.WriteLine(iram);
            Console.WriteLine(spi);
            Console.WriteLine(ram);
        }
    }
}
