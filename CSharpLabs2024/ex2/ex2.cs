using System;

public class Point
{
    public int X { get; }
    public int Y { get; }
    public string Name { get; }

    public Point(int x, int y, string name)
    {
        X = x;
        Y = y;
        Name = name;
    }
}

public class Figure
{
    private Point[] points;

    public Figure(Point p1, Point p2, Point p3)
    {
        points = new Point[] { p1, p2, p3 };
    }

    public Figure(Point p1, Point p2, Point p3, Point p4)
    {
        points = new Point[] { p1, p2, p3, p4 };
    }

    public Figure(Point p1, Point p2, Point p3, Point p4, Point p5)
    {
        points = new Point[] { p1, p2, p3, p4, p5 };
    }

    private double LengthSide(Point A, Point B)
    {
        return Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
    }

    public void PerimeterCalculator()
    {
        double perimeter = 0;
        for (int i = 0; i < points.Length; i++)
        {
            int nextIndex = (i + 1) % points.Length;
            perimeter += LengthSide(points[i], points[nextIndex]);
        }
        Console.WriteLine($"Периметр багатокутника: {perimeter}");
    }
}

class ex2
{
    static void Main(string[] args)
    {
        Point A = new Point(0, 0, "A");
        Point B = new Point(3, 0, "B");
        Point C = new Point(3, 4, "C");
        
        Figure triangle = new Figure(A, B, C);
        triangle.PerimeterCalculator();
    }
}
