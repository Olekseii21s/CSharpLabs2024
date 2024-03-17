using System;

class Book
{
    private string title;
    private string author;
    private string content;

    public Book(string title, string author, string content)
    {
        this.title = title;
        this.author = author;
        this.content = content;
    }

    public string Title
    {
        get { return title; }
    }

    public string Author
    {
        get { return author; }
        set { author = value; }
    }

    public string Content
    {
        get { return content; }
        set { content = value; }
    }

    public void Show()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Назва книги: {title}");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Автор: {author}");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Зміст:\n{content}");
        Console.ResetColor();
    }
}

class ex1
{
    static void Main(string[] args)
    {
        Book book = new Book("Титан", "Франсіс Скотт Фіцджеральд", "Зміст книги Титан...");
        
    
        book.Show();

        
        book.Author = "Новий Автор";
        book.Content = "Новий зміст книги Титан...";

        
        book.Show();
    }
}