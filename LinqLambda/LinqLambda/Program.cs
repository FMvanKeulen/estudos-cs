using System;
using System.Linq;
using LinqLambda.Entities;
using System.Collections.Generic;

namespace LinqLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Electronics", Tier = 1 };

            List<Product> list = new List<Product>()
            {
                new Product() {Id = 1, Name = "Computer", Price = 1100.0, Category = c2},
                new Product() {Id = 2, Name = "Hammer", Price = 90, Category = c1},
                new Product() {Id = 3, Name = "TV", Price = 1700.0, Category = c3},
                new Product() {Id = 4, Name = "Notebook", Price = 1300.0, Category = c2},
                new Product() {Id = 5, Name = "Saw", Price = 80.0, Category = c1},
                new Product() {Id = 6, Name = "Tablet", Price = 700.0, Category = c2},
                new Product() {Id = 7, Name = "Camera", Price = 700.0, Category = c3},
                new Product() {Id = 8, Name = "Printer", Price = 350.0, Category = c3},
                new Product() {Id = 9, Name = "MacBook", Price = 1800.0, Category = c2},
                new Product() {Id = 10, Name = "Sound Bar", Price = 700.0, Category = c3},
                new Product() {Id = 11, Name = "Level", Price = 70.0, Category = c1}
            };

            var r1 =
                from p in list
                where p.Category.Tier == 1 && p.Price < 900.00
                select p;

            var result = list.Where(x => x.Category.Tier == 1 && x.Price < 900.0);
            Print("TIER 1 AND PRICE < 900:", result);

            var result1 = list.Where(x => x.Category.Name == "Tools").Select(x => x.Name);
            Print("NAMES OF PRODUCTS FROM TOOLS", result1);

            var r2 =
                from p in list
                where p.Name[0] == 'C'
                select new
                {
                    p.Name,
                    p.Price,
                    CategoryName = p.Category.Name
                };

            var result2 = list.Where(x => x.Name.StartsWith('C')).Select(x => new { x.Name, Category = x.Category.Name });
            Print("NAMES OF PRODUCTS THAT STARTS WITH C", result2);

            var r3 =
                from p in list
                where p.Category.Tier == 1
                orderby p.Name
                orderby p.Price
                select p;

            var result3 = list.Where(x => x.Category.Tier == 1).OrderBy(x => x.Price).ThenBy(x => x.Name);
            Print("TIER 1 BY PRICE THEN NAME", result3);

            var r4 =
                (from p in r3
                 select p).Skip(2).Take(4);

            var result4 = result3.Skip(2).Take(4);
            Print("TIER 1 BY PRICE THEN NAME SKIP 2 TAKE 4", result4);

            var result5 = list.Max(x => x.Price);
            Console.WriteLine("MAX PRICE: " + result5);

            var result6 = list.Where(x => x.Category.Id == 1).Sum(x => x.Price);
            Console.WriteLine("Category 1 sum prices: " + result6);

            var result7 = list.Where(x => x.Category.Id == 1).Select(x => x.Price).Aggregate(0.0, (x, y) => x + y);
            Console.WriteLine("Category 1 aggregate prices: " + result7);

            Console.WriteLine();
            var result8 = list.GroupBy(x => x.Category);
            foreach (IGrouping<Category, Product> group in result8)
            {
                Console.WriteLine("Category " + group.Key.Name + ":");
                foreach (Product p in group)
                    Console.WriteLine(p);
                Console.WriteLine();
            }
        }

        static void Print<T>(string message, IEnumerable<T> collecton)
        {
            Console.WriteLine(message);
            foreach (T obj in collecton)
                Console.WriteLine(obj);

            Console.WriteLine();
        }
    }
}