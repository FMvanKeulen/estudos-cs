using System;
using System.IO;

namespace FileCsNew
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\textoOrigin.txt";
            string pathNew = @"D:\textoTarget.txt";

            try
            {            
                using (StreamReader sr = File.OpenText(path))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            Console.WriteLine(line);
                        }
                    }

                string[] lines = File.ReadAllLines(path);
                using (StreamWriter sw = File.AppendText(pathNew))
                {
                    foreach (string line in lines)
                    {
                        sw.WriteLine(line.ToUpper());
                    }
                }
            }
            catch(IOException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}