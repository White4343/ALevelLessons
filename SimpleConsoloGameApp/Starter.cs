using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleConsoleGameApp.Characters;
using SimpleConsoleGameApp.Characters.Enemies;
using SimpleConsoleGameApp.Equipment;

namespace SimpleConsoleGameApp
{
    public class Starter
    {
        private static Random _random = new Random();

        public void Start()
        {
            bool isNotExit = true;
            ICharacter? character = null;

            while (isNotExit)
            {
                Console.WriteLine("Hello! Here's list of command's:\n create\n show\n fight\n exit");
                string? input = Console.ReadLine();
                
                switch (input)
                {
                    case "create":
                        if (character != null)
                        {
                            Console.WriteLine("Character is already created!");
                            break;
                        }
                        character = CreateCharacter();
                        if (character == null)
                        {
                            Console.WriteLine("Character creation is gone wrong!");
                            break;
                        }
                        Console.WriteLine("Character created!");
                        continue;
                    case "show":
                        if (character == null)
                        {
                            Console.WriteLine("Character creation is gone wrong!");
                            break;
                        }
                        ShowCharacter(character);
                        continue;
                    case "fight":
                        if (character == null)
                        {
                            Console.WriteLine("Character creation is gone wrong!");
                            break;
                        }
                        Fight(character);
                        continue;
                    case "exit":
                        isNotExit = false;
                        break;
                    default:
                        Console.WriteLine("Please write command!");
                        continue;
                }
            }
        }

        public ICharacter? CreateCharacter()
        {
            Console.WriteLine("Enter name for you're character");
            string? nameLine = Console.ReadLine();
            if (string.IsNullOrEmpty(nameLine))
            {
                Console.WriteLine("You're input is not valid!");
                return null;
            }

            Console.WriteLine("Choose class:\n wizard\n warrior");
            string? input = Console.ReadLine();

            switch (input)
            {
                case "wizard":
                    return new Wizzard(nameLine, "Wizard", _random.Next(15, 20), _random.Next(1, 2), _random.Next(1, 2), 3, 3);
                case "warrior":
                    return new Warrior(nameLine, "Warrior", _random.Next(20, 25), _random.Next(2, 4), _random.Next(1, 3));
                default:
                    Console.WriteLine("Please write command!");
                    return null;
                    break;
            }
        }

        public void ShowCharacter(ICharacter? character)
        {
            if (character == null)
            {
                Console.WriteLine("Character is null!");
                return;
            }
            character.PrintCharacter();
        }

        public (ICharacter?, IWeapon?) CreateEnemy()
        {
            ICharacter? enemy = null;
            IWeapon? enemyWeapon = null;
            switch (_random.Next(1, 2))
            {
                case 1:
                    Console.WriteLine("You're enemy is Troll");
                    enemy = new Trol("Troll", "Warrior", 30, 2, 3);
                    enemyWeapon = new Sword("Big Sword", "Sword", 5);
                    return (enemy, enemyWeapon);
                case 2:
                    Console.WriteLine("You're enemy is Goblin");
                    enemy = new Goblin("Goblin", "Warrior", 10, 1, 1, 3);
                    enemyWeapon = new Sword("Short Sword", "Sword", 4);
                    return (enemy, enemyWeapon);
                default:
                    return (null, null);
            }
        }

        public IWeapon? CreateWeapon(ICharacter? character)
        {
            if (character.Specialization == "Wizard")
            {
                return new Wand("Elder Wand", "Wand", 1, 6);
            }
            else if (character.Specialization == "Warrior")
            {
                return new Sword("Long Sword", "Sword", 5);
            }
            else
            {
                return null;
            }
        }

        public bool EnemyAction(ICharacter? enemyCharacter, ICharacter heroCharacter, IWeapon enemyWeapon, IWeapon heroWeapon, bool isBlock)
        {
            bool isHeroAlive = true;

            if (isBlock == true)
            {
                int attackDamage = enemyWeapon.DealDamage() + enemyCharacter.Strength;
                attackDamage = ((Sword)heroWeapon).BlockDamage(attackDamage);
                return isHeroAlive = heroCharacter?.TakeDamage(attackDamage) ?? false;
            }
            else
            {
                int attackDamage = enemyWeapon.DealDamage() + enemyCharacter.Strength;
                return isHeroAlive = heroCharacter?.TakeDamage(attackDamage) ?? false;
            }

            return isHeroAlive;
        }

        public (bool, bool) CharacterChoices(ICharacter? character, IWeapon characterWeapon, ICharacter? enemy)
        {
            bool ifEnemyAlive = true;
            bool isBlock = true;

            if (character?.Specialization == "Wizard")
            {
                Console.WriteLine("Do action: attack\n regen");
                string? input = Console.ReadLine();
                switch (input)
                {
                    case "attack":
                        int attackDamage = characterWeapon.DealDamage() + character.Strength + ((Wizzard)character).ManaPoints;
                        ((Wizzard)character).ManaPoints = ((Wizzard)character).MaxManaPoints - ((Wizzard)character).ManaPoints;
                        ifEnemyAlive = enemy?.TakeDamage(attackDamage) ?? false;
                        return (ifEnemyAlive, isBlock = false);
                    case "regen":
                        ((Wizzard)character).RegenerateManaPoints();
                        ifEnemyAlive = true;
                        return (ifEnemyAlive, isBlock = false);
                }
            } 
            else if (character?.Specialization == "Warrior")
            {
                Console.WriteLine("Do action: attack\n rage \n block");
                string? input = Console.ReadLine();
                switch (input)
                {
                    case "attack":
                        int attackDamage = characterWeapon.DealDamage() + character.Strength;
                        ifEnemyAlive = enemy?.TakeDamage(attackDamage) ?? false;
                        return (ifEnemyAlive, isBlock = false);
                    case "rage attack":
                        int attackDmg = characterWeapon.DealDamage() + ((Warrior)character).EnterRage();
                        ifEnemyAlive = enemy?.TakeDamage(attackDmg) ?? false;
                        return (ifEnemyAlive, isBlock = false);
                    case "block":
                        return (ifEnemyAlive, isBlock = true);
                }
            }

            return (true, false);
  
        }

        public void Fight(ICharacter? character)
        {
            IWeapon characterWeapon = CreateWeapon(character);
            var (enemy, enemyWeapon) = CreateEnemy();

            bool isEnemyAlive = true;
            bool isHeroAlive = true;
            bool isBlock = true;

            while (isEnemyAlive && isHeroAlive)
            {
                (isEnemyAlive, isBlock) = CharacterChoices(character, characterWeapon, enemy);

                if (isEnemyAlive == false)
                {
                    Console.WriteLine("You won!");
                    break;
                }
                else
                {
                    isHeroAlive = EnemyAction(enemy, character, enemyWeapon, characterWeapon, isBlock);

                    if (isHeroAlive == false)
                    {
                        Console.WriteLine("Enemy won!");
                        break;
                    }
                }
                continue;
            }
        }
    }
}
