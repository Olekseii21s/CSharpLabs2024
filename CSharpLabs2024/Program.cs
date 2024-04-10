using System;
using CSharpLabs2024.Task1;
using CSharpLabs2024.Task2;

namespace CSharpLabs2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1");
            
            Book book = new Book("Володар перснів");
            
            book.Show();
            
            book.Author = "Дж. Р. Р. Толкін";
            book.Content = "У далекому королівстві...";

            book.Show();

            
            // book.Title = new Title("Володар перснів");


            Console.WriteLine("Task 2");
            
            Point pointA = new Point(1, 2, "A");
            Point pointB = new Point(4, 5, "B");
            Point pointC = new Point(7, 8, "C");

            var figure = new Figure(pointA, pointB, pointC);
            figure.PerimeterCalculator();
        }
    }
}