using System;
using System.IO;
using System.Collections.Generic;
using Comparable.Entities;

namespace Comparable
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\comparable.txt";

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    List<Employee> list = new List<Employee>();
                    while (!sr.EndOfStream)
                        list.Add(new Employee(sr.ReadLine()));
                    list.Sort();
                    foreach (Employee emp in list)
                        Console.WriteLine(emp);
                }                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}