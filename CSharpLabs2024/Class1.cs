using System;

class Program
{
    static void Main(string[] args)
    {
        Task1.Execute();
        Task2.Execute();
        Task3.Execute();
        Task4.Execute();
    }
}

class Task1
{
    public static void Execute()
    {
        Console.WriteLine("Введіть три цілих числа:");
        
        Console.Write("Число 1: ");
        int num1 = int.Parse(Console.ReadLine());
        
        Console.Write("Число 2: ");
        int num2 = int.Parse(Console.ReadLine());
        
        Console.Write("Число 3: ");
        int num3 = int.Parse(Console.ReadLine());

        int lastDigit = 9;
        int lowerBound = 1;
        int upperBound = 10 + lastDigit;

        Console.WriteLine("Числа, які належать інтервалу [1,{0}]:", upperBound);

        if (num1 >= lowerBound && num1 <= upperBound)
        {
            Console.WriteLine(num1);
        }

        if (num2 >= lowerBound && num2 <= upperBound)
        {
            Console.WriteLine(num2);
        }

        if (num3 >= lowerBound && num3 <= upperBound)
        {
            Console.WriteLine(num3);
        }
    }
}

class Task2
{
    public static void Execute()
    {
        Console.WriteLine("Введіть довжини сторін трикутника:");

        Console.Write("Сторона 1: ");
        double side1 = double.Parse(Console.ReadLine());

        Console.Write("Сторона 2: ");
        double side2 = double.Parse(Console.ReadLine());

        Console.Write("Сторона 3: ");
        double side3 = double.Parse(Console.ReadLine());

        if (side1 <= 0 || side2 <= 0 || side3 <= 0)
        {
            Console.WriteLine("Некоректні дані. Довжина сторони повинна бути більше нуля.");
            return;
        }

        if (!(side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1))
        {
            Console.WriteLine("Трикутник з такими сторонами не існує.");
            return;
        }

        double perimeter = side1 + side2 + side3;

        double s = perimeter / 2;
        double area = Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3));

        Console.WriteLine($"Периметр трикутника: {perimeter}");
        Console.WriteLine($"Площа трикутника: {area}");

        if (side1 == side2 && side2 == side3)
        {
            Console.WriteLine("Трикутник є рівностороннім.");
        }
        else if (side1 == side2 || side1 == side3 || side2 == side3)
        {
            Console.WriteLine("Трикутник є рівнобедреним.");
        }
        else
        {
            Console.WriteLine("Трикутник є різностороннім.");
        }
    }
}

class Task3
{
    public static void Execute()
    {
        int size = 10 + 29 % 10; 

        int[] X = new int[size];
        Random rnd = new Random();
        for (int i = 0; i < size; i++)
        {
            X[i] = rnd.Next(100); 
        }

        Console.WriteLine("Масив Х:");
        foreach (int num in X)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        int min = X[0];
        int max = X[0];
        for (int i = 1; i < size; i++)
        {
            if (X[i] < min)
            {
                min = X[i];
            }
            if (X[i] > max)
            {
                max = X[i];
            }
        }

        Console.WriteLine("Мінімальне значення: " + min);
        Console.WriteLine("Максимальне значення: " + max);
    }
}

class Task4
{
    public static void Execute()
    {
        int[] X = GenerateArray(); 
        int M = 5; 

        Console.WriteLine("Заданий масив X:");
        PrintArray(X);

        int[] Y = FilterArray(X, M); 

        Console.WriteLine("\nЧисло M: " + M);
        Console.WriteLine("Отриманий масив Y:");
        PrintArray(Y);
    }

    static int[] GenerateArray()
    {
        int[] X = new int[39];
        Random rand = new Random();

        for (int i = 0; i < X.Length; i++)
        {
            X[i] = rand.Next(-10, 11);
        }

        return X;
    }

    static int[] FilterArray(int[] X, int M)
    {
        int count = 0;
        foreach (int num in X)
        {
            if (Math.Abs(num) > M)
            {
                count++;
            }
        }

        int[] Y = new int[count];
        int index = 0;

        foreach (int num in X)
        {
            if (Math.Abs(num) > M)
            {
                Y[index] = num;
                index++;
            }
        }

        return Y;
    }

    static void PrintArray(int[] arr)
    {
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}
