using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR3_
{
  
    public class Program
    {
        public static string InputFilePath = @"..\..\input(First example).txt";
        public static string OutputFilePath = @"..\..\output.txt";

        public class graf
        {
            public string name { get; set; }

            public string n1{
                get{ return name.Substring(0, 3); }
                set { }
            }
            public string n2
            {
                get { return name.Substring(3, 3); }
                set { }
            }
        }

         static void Main(string[] args)
        {
            List<graf> grafs = new List<graf>();



            using (StreamReader reader = new StreamReader(InputFilePath))
            {
                int linecount = 0;

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (linecount == 0)
                    {
                        linecount++;
                        continue;
                    }
                    else
                    {
                        grafs.Add(new graf { name = line });
                    }

                }
            }                                

            algoritm(grafs);

            Console.WriteLine("Розрухунки виконано");
            Console.Read();

        }

        public static void algoritm(List<graf> grafs)
        {
            int count = 0;

            for (int i = 0; i < grafs.Count-1; i++)
            {       
                for (int j = i + 1; j < grafs.Count; j++)
                {
                    if (grafs[i].n2 == grafs[j].n1)
                    {
                        if (j == i + 1)
                        {
                            break;
                        }
                        else
                        {
                            graf tmp = grafs[i + 1];
                            grafs[i + 1] = grafs[j];
                            grafs[j] = tmp;

                            break;
                        }
                    }
                    else if (j == grafs.Count - 1)
                    {
                        count++;
                    }
                }
            }


            if (grafs[grafs.Count-1].n2 != grafs[0].n1)
            {
                count++;
            }


            using (StreamWriter writer = new StreamWriter(OutputFilePath, false))
            {
                writer.WriteLineAsync(count.ToString());
            }

        }
    }
}
