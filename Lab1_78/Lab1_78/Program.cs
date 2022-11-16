using System;
using System.IO;
using System.Linq;

namespace Lab1_78
{
    class Program
    {
        public static string InputFilePath = @"..\..\..\input (First example).txt";
        public static string OutputFilePath = @"..\..\..\output.txt";
        static void Main(string[] args)
        {
            FileInfo outputFileInfo = new FileInfo(OutputFilePath);
            int final_result = 0;
            string[] Line_1 = File.ReadLines(InputFilePath).ElementAtOrDefault(0).Split(' ');

            int N = int.Parse(Line_1[0]);
            int M = int.Parse(Line_1[1]);
            
            if(N < 1 || N > 109 || M < 1 || M > 109)
            {
                Console.WriteLine("Incorrect input data");
            }

            int holes_1 = int.Parse(File.ReadLines(InputFilePath).ElementAtOrDefault(1));
            if(holes_1 == 0)
            {
                using (StreamWriter streamWriter = outputFileInfo.CreateText())
                {
                    streamWriter.WriteLine(0);
                    Environment.Exit(-1);
                }
            }

            int holes_2 = int.Parse(File.ReadLines(InputFilePath).ElementAtOrDefault(2 + holes_1));
            if (holes_2 == 0)
            {
                using (StreamWriter streamWriter = outputFileInfo.CreateText())
                {
                    streamWriter.WriteLine(0);
                    Environment.Exit(-1);
                }
            }

            bool[,] coordinates_1 = new bool[M, N];
            bool[,] coordinates_2 = new bool[M, N];
            string[] holesPos_1 = new string[holes_1];
            string[] holesPos_2 = new string[holes_2];
            if(holes_1 > 1)
            {
                for (int i = 2; i < 2 + holes_1; i++)
                {
                    holesPos_1[i-2] = File.ReadLines(InputFilePath).ElementAtOrDefault(i);
                }
            }
            else
            {
                holesPos_1[0] = File.ReadLines(InputFilePath).ElementAtOrDefault(2);
            }
            if (holes_2 > 1)
            {
                for (int i = 3 + holes_1; i < 3 + holes_1 + holes_2; i++)
                {
                    holesPos_2[i - (3 + holes_1)] = File.ReadLines(InputFilePath).ElementAtOrDefault(i);
                }
            }
            else
            {
                holesPos_2[0] = File.ReadLines(InputFilePath).ElementAtOrDefault(3 + holes_1);
            }

            foreach (string holePos in holesPos_1)
            {
                for (int y = int.Parse(holePos.Split(' ')[1]); y <= int.Parse(holePos.Split(' ')[3]); y++)
                {
                    for (int x = int.Parse(holePos.Split(' ')[0]); x <= int.Parse(holePos.Split(' ')[2]); x++)
                    {
                        coordinates_1[y, x] = true;
                    }
                }
            }
            foreach (string holePos in holesPos_2)
            {
                for (int y = int.Parse(holePos.Split(' ')[1]); y <= int.Parse(holePos.Split(' ')[3]); y++)
                {
                    for (int x = int.Parse(holePos.Split(' ')[0]); x <= int.Parse(holePos.Split(' ')[2]); x++)
                    {
                        coordinates_2[y, x] = true;
                    }
                }
            }
            int result_1 = 0;
            foreach (string holePos in holesPos_1)
            {
                bool isHole = false;
                for (int y = int.Parse(holePos.Split(' ')[1]); y <= int.Parse(holePos.Split(' ')[3]); y++)
                {
                    for (int x = int.Parse(holePos.Split(' ')[0]); x <= int.Parse(holePos.Split(' ')[2]); x++)
                    {
                        if(coordinates_2[y, x] == true)
                        {
                            isHole = true;
                        }
                    }
                }
                if (isHole)
                {
                    result_1++;
                }
            }
            int result_2 = 0;
            foreach (string holePos in holesPos_2)
            {
                bool isHole = false;
                for (int y = int.Parse(holePos.Split(' ')[1]); y <= int.Parse(holePos.Split(' ')[3]); y++)
                {
                    for (int x = int.Parse(holePos.Split(' ')[0]); x <= int.Parse(holePos.Split(' ')[2]); x++)
                    {
                        if (coordinates_1[y, x] == true)
                        {
                            isHole = true;
                        }
                    }
                }
                if (isHole)
                {
                    result_2++;
                }
            }
            if(result_1 > result_2)
            {
                final_result = result_1;
            }
            else
            {
                final_result = result_2;
            }

            using (StreamWriter streamWriter = outputFileInfo.CreateText())
            {
                streamWriter.WriteLine(final_result.ToString());
            }
        }
    }
}
