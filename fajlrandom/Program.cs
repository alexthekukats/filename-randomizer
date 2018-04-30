using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace fajlrandom
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\wallpapers\";

            string[] array1 = Directory.GetFiles(path);
            string[,] asd = new string[array1.Length, 3];

            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] Files = d.GetFiles("*.*");
            int sz = 0;
            foreach (FileInfo file in Files)
            {
                asd[sz,2] = file.Name;
                sz++;
            }



            for (int i = 0; i < array1.Length; i++)
            {
                asd[i, 0] = array1[i];
            }

            Random ran = new Random();

            bool tr = false;
            for (int i = 0; i < array1.Length; i++)
            {
                asd[i, 1] = ran.Next(0, array1.Length * 10000).ToString();

                    for (int k = 0; k < i; k++)
                    {
                        if (asd[i, 1] == asd[k, 1] && i != k)
                        {
                            
                            tr = true;
                        }
                    }
                    if (tr == true)
                    { i--; tr = false; break; }
                       
            }

            using (StreamWriter iro = new StreamWriter("asd.txt"))
            {
                try
                {
                    for (int i = 0; i < asd.Length / 2; i++)
                    {
                        Console.WriteLine("{0}\t{1}", asd[i, 0], asd[i, 1]);
                        iro.WriteLine("{0}\t{1}", asd[i, 0], asd[i, 1]);
                        System.IO.File.Move(path+asd[i,2],path+asd[i,1]+".jpg");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }



            Console.ReadKey();
        }
    }
}
