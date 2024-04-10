namespace CSharpLabs2024.Task1
{
    public class Title(string title)
    {
        public string Text => title;

        public void Show()
        {
            Console.WriteLine(title);
        }
    }
}