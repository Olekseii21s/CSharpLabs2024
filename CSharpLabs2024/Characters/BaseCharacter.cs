using System;

namespace CSharpLabs2024.Characters
{
    public class BaseCharacter
    {
        private string name;
        private int health;

        public BaseCharacter(string name, int health)
        {
            this.name = name;
            Health = health;
        }

        public string Name => name;

        public int Health
        {
            get => health;
            set => health = value < 0 ? 0 : value;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public void ShowStats()
        {
            Console.WriteLine($"Name: {Name}");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Health: {Health}");
            Console.ResetColor();
        }
    }
}
