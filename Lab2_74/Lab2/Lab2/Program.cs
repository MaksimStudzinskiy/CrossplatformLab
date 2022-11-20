using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Program
    {
        public static string InputFilePath = @"..\..\input.txt";
        public static string OutputFilePath = @"..\..\output.txt";

        static void Main(string[] args)
        {
            string str1 = "", str2 = "";

            using (StreamReader reader = new StreamReader(InputFilePath))
            {
                int linecount = 0;

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (linecount == 0)
                    {

                        str1 = line;
                    }
                    else
                    {
                        str2 = line;
                    }

                    linecount++;

                }
            }

            bool flag = Equal(str1, str2);

            if (flag == false)
                using (StreamWriter writer = new StreamWriter(OutputFilePath, false))
                {
                    writer.WriteLineAsync("NO");
                }
            else
                using (StreamWriter writer = new StreamWriter(OutputFilePath, false))
                {
                    writer.WriteLineAsync("YES");
                }

            Console.WriteLine("Розрухунки виконано");

            Console.Read();

        }

        public static bool Equal(string A, string B)
        {
            bool answ = true;
            foreach (var v in B)
                if (!A.Contains(v))
                {
                    answ = false;
                    break;
                }

            return answ;
        }
    }
}
