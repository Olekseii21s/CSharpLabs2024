using System;

namespace CSharpLabs2024.Task1
{
    public class Book
    {
        private Title _title;
        private Content _content;
        private Author _author;


        public Book(string title)
        {
            _title = new Title(title);
            _content = new Content();
            _author = new Author();
        }


        public string Author
        {
            get => _author.Name;
            set=> _author.Name =  value;
        }

        public string Content
        {
            get => _content.Text;
            set => _content.Text = value;
            
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Назва книги: " + _title.Text);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Автор: " + _author.Name);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Зміст: " + _content.Text);
            
            Console.ResetColor();
        }
    }

}

