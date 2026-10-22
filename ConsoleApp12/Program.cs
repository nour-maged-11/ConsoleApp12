using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Product> ProductList = new List<Product>();
        List<Customer> CustomerList = new List<Customer>();

        var q1 = ProductList.OrderByDescending(p => p.UnitPrice).Take(3);

        var q2 = ProductList.Skip(5).Take(5);

        var q3 = ProductList.OrderBy(p => p.UnitPrice).TakeWhile(p => p.UnitPrice < 25);

        var q4 = ProductList.Where(p => p.Category == "Seafood").All(p => p.UnitsInStock > 0);

        int[] ids = { 3, 9, 13, 18 };
        bool q5 = ids.Contains(9);

        var q6 = ProductList.GroupBy(p => p.Category);

        var q7 = ProductList.GroupBy(p => p.Category).Select(g => new { Category = g.Key, Names = g.Select(p => p.ProductName) });

        var q8 = ProductList.GroupBy(p => p.Category).Where(g => g.Count() > 3);

        var q9 = from c in CustomerList
                 group c by c.Country into g
                 select new { Country = g.Key, Count = g.Count() };

        var q10 = ProductList.Sum(p => p.UnitsInStock);

        var minPrice = ProductList.Min(p => p.UnitPrice);
        var maxPrice = ProductList.Max(p => p.UnitPrice);

        var q12 = ProductList.Select(p => p.Category).Distinct();

        int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
        int[] setB = { 3, 6, 9, 12, 15, 13 };
        var q13 = setA.Except(setB);

        string[] list1 = { "Germany", "France", "UK", "Spain" };
        string[] list2 = { "france", "SPAIN", "Italy" };
        var q14 = list1.Except(list2, StringComparer.OrdinalIgnoreCase);

        var q16 = ProductList.First(p => p.UnitPrice > 50);

        var q17 = ProductList.FirstOrDefault(p => p.UnitPrice > 500);

        var q18 = Enumerable.Range(1, 12).Select(i => i * 7);

        var q19 = Enumerable.Range(1, 30).Where(i => i % 2 == 0);
    }
}