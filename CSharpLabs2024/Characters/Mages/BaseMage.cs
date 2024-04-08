using System;
using CSharpLabs2024.Interfaces;

namespace CSharpLabs2024.Characters.Mages
{
    public class BaseMage : BaseCharacter, IDamageable
    {
        public int Mana = 100;

        public BaseMage(string name) : base(name, health: 85)
        {
        }

        public bool CastDefaultSpell(int power, IDamageable target)
        {
            int costMult = 2;
            if (Mana < power * costMult || power < 0)
            {
                Console.WriteLine($"Not enough mana ({Mana}) to cast spell with {power} damage on {target.Name}");
                Console.WriteLine($"You need {power * costMult} mana to cast spell with {power}");
                return false;
            }

            Mana -= power * costMult;
            target.TakeDamage(power);

            Console.WriteLine($"{Name} casted default spell with {power} damage on {target.Name}");
            Console.WriteLine("Mana left: " + Mana);
            return true;
        }

        public bool RestoreMana()
        {
            int addMana = 20;
            Mana += addMana;
            Console.WriteLine("Mana restored: +" + addMana);
            Console.WriteLine("Mana left: " + Mana);
            return true;
        }

        public bool Heal(int power, IDamageable? target = null)
        {
            int costMult = 3;
            if (Mana < power * costMult || power < 0)
            {
                Console.WriteLine($"Not enough mana ({Mana}) to heal");
                Console.WriteLine($"You need {power * costMult} mana to heal with {power}hp");
                return false;
            }

            Mana -= power * costMult;

            if (target == null)
            {
                Health += power;
                Console.WriteLine($"{Name} healed {power} hp");
            }
            else
            {
                target.Health += power;
                Console.WriteLine($"{Name} healed {power} hp to {target.Name}");
            }

            Console.WriteLine("Mana left: " + Mana);
            return true;
        }

        public new void ShowStats()
        {
            base.ShowStats();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"Mana: {Mana}");
            Console.ResetColor();
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

        public void ShowStatsMenu(IDamageable target)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("1. Your stats");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("2. Enemy stats");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("3. Exit");
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

                Console.Clear();
                switch (choice)
                {
                    case 1:
                        ShowStats();
                        break;
                    case 2:
                        target.ShowStats();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        public bool ShowActionsMenu(IDamageable target)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("1. Cast default spell");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("2. Restore mana");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("3. Heal");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("4. Exit");
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
                        bool result = CastDefaultSpell(power, target);
                        if (result)
                            return true;
                        break;
                    case 2:
                        Console.Clear();
                        return RestoreMana();
                    case 3:
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
                    case 4:
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
