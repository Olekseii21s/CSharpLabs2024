using System;
using CSharpLabs2024.Interfaces;

namespace CSharpLabs2024.Characters.Mages
{
    public class FireMage : BaseMage, IDamageable
    {
        public FireMage(string name) : base(name)
        {
        }

        public bool CastFireSpell(int power, IDamageable target)
        {
            int castMult = 2;
            int costMult = 3;
            if (Mana < power * costMult || power < 0)
            {
                Console.WriteLine($"Not enough mana ({Mana}) to cast spell with {power} damage on {target.Name}");
                Console.WriteLine($"You need {power * costMult} mana to cast spell with {power}");
                return false;
            }

            Mana -= power * costMult;
            target.TakeDamage(power * castMult);

            Console.WriteLine($"{Name} casted fire spell with {power * castMult} damage on {target.Name}");
            Console.WriteLine("Mana left: " + Mana);
            return true;
        }

        public new void SelectActions(IDamageable target)
        {
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Show stats");
                Console.WriteLine("2. Actions");
                Console.Write("Your choice: ");
                int choice;
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Wrong choice");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        ShowStatsMenu(target);
                        break;
                    case 2:
                        Console.Clear();
                        if (ShowActionsMenu(target))
                            return;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong choice");
                        break;
                }
            }
        }

        public new bool ShowActionsMenu(IDamageable target)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("1. Cast default spell");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("2. Cast fire spell");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("3. Restore mana");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("4. Heal");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("5. Exit");
                Console.ResetColor();
                Console.Write("Your choice: ");
                int choice;
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Wrong choice");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                    case 2:
                        Console.Clear();
                        Console.Write("Spell power: ");
                        int power;
                        try
                        {
                            power = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("Wrong choice");
                            Console.ReadKey();
                            continue;
                        }
                        Console.Clear();
                        bool result = choice == 1 ? CastDefaultSpell(power, target) : CastFireSpell(power, target);
                        if (result)
                            return true;
                        break;
                    case 3:
                        Console.Clear();
                        return RestoreMana();
                    case 4:
                        Console.Clear();
                        Console.Write("Heal power: ");
                        int healPower;
                        try
                        {
                            healPower = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("Wrong choice");
                            Console.ReadKey();
                            continue;
                        }

                        Console.Clear();
                        Console.WriteLine("Who should be healed?");
                        Console.WriteLine("1. Me");
                        Console.WriteLine("2. Enemy");
                        Console.Write("Your choice: ");
                        int targetChoice;
                        try
                        {
                            targetChoice = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("Wrong choice");
                            Console.ReadKey();
                            continue;
                        }

                        Console.Clear();
                        bool resultHeal;
                        switch (targetChoice)
                        {
                            case 1:
                                resultHeal = Heal(healPower);
                                break;
                            case 2:
                                resultHeal = Heal(healPower, target);
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("Wrong choice");
                                Console.ReadKey();
                                continue;
                        }

                        if (resultHeal)
                            return true;
                        break;
                    case 5:
                        Console.Clear();
                        return false;
                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong choice");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
