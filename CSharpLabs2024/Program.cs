using System;
using CSharpLabs2024.Characters.Mages;
using CSharpLabs2024.Interfaces;

namespace CSharpLabs2024
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var player1 = new FireMage("SuperMag");
            var player2 = new BaseMage("UltimateMag");
            
            // GamePvP(player1, player2);
            GamePvE(player1, player2);
        }

        public static void GamePvP(IDamageable player1, IDamageable player2)
        {
            Console.WriteLine(player1.Name + " vs " + player2.Name);
            while (player1.Health > 0 && player2.Health > 0)
            {
                Console.WriteLine(player1.Name + " turn");
                player1.SelectActions(player2);
                if (player2.Health <= 0)
                {
                    Console.WriteLine(player1.Name + " wins!");
                    break;
                }
                Console.ReadKey();
                Console.Clear();
                
                Console.WriteLine(player2.Name + " turn");
                player2.SelectActions(player1);
                if (player1.Health <= 0)
                {
                    Console.WriteLine(player2.Name + " wins!");
                    break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
        
        public static void GamePvE(IDamageable player, IDamageable bot)
        {
            Console.WriteLine(player.Name + " vs " + bot.Name);
            while (player.Health > 0 && bot.Health > 0)
            {
                Console.WriteLine(player.Name + " turn");
                player.SelectActions(bot);
                if (bot.Health <= 0)
                {
                    Console.WriteLine(player.Name + " wins!");
                    break;
                }
                Console.ReadKey();
                Console.Clear();
                
                Console.WriteLine(bot.Name + " turn");
                bot.SelectActions(player);
                if (player.Health <= 0)
                {
                    Console.WriteLine(bot.Name + " wins!");
                    break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
