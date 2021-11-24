using Lavrentev.Practice.Tree;
using System;

namespace Lavrentev.Practice.Presentation
{
    public class Menu
    {
        private readonly string[] title;
        private readonly string[] items;
        private readonly string back;
        private readonly string choice;

        public const string DefaultBack = "Назад";
        public const string DefaultChoice = "Введите пунт меню: ";

        public Menu(string[] title, string[] items, string back = DefaultBack, string choice = DefaultChoice)
        {
            this.title = title;
            this.items = items;
            this.back = back;
            this.choice = choice;
        }

        public int Show()
        {
            bool failed = false;

            while (true)
            {
                Console.Clear();
                
                for(int i = 0; i < title.Length; i++)
                {
                    Console.WriteLine(title[i]);
                }

                Console.WriteLine();
                
                for (int i = 0; i < items.Length; i++)
                {
                    Console.WriteLine($"{i+1}. {items[i]}");
                }

                Console.WriteLine($"0. {back}");
                Console.WriteLine();

                if(failed)
                {
                    Console.WriteLine("Выбран неверный пункт меню. Попробуйте ещё раз.");
                } 

                Console.Write(choice);

                string input = Console.ReadLine();
                
                try
                {
                    int item = int.Parse(input);

                    if(item >= 0 && item <= items.Length)
                    {
                        Console.Clear();
                        return item;
                    }

                }
                catch { }

                failed = true;
            }
        }
    }
    
    public static class Input
    {
        public static int GetInt(string text, int min = int.MinValue, int max = int.MaxValue)
        {
            int value;

            while (true)
            {
                Console.Write(text);
                string input = Console.ReadLine();
                
                try
                {
                    value = int.Parse(input);

                    if (value >= min && value <= max) 
                    {
                        return value; 
                    }
                    else
                    {
                        Console.WriteLine("Число не входит в заданный диапозон. Попробуйте ещё раз.");
                    }
                }
                catch
                {
                    Console.WriteLine("Неверное значение. Попробуйте ещё раз.");
                }
            }
        }
        
        public static int[] GetArray(string text, string separator = " ")
        {
            while(true)
            {
                Console.WriteLine(text);

                string input = Console.ReadLine();

                string[] row = input.Trim().Split(separator.ToCharArray());

                int[] arr = new int[row.Length];

                try
                {
                    for (int i = 0; i < row.Length; i++)
                    {
                        arr[i] = int.Parse(row[i]);
                    }

                    return arr;
                } 
                catch
                {
                    Console.WriteLine("Недопустимое значение. Попробуйте ещё раз.");
                }
            }
        }
        
        public static void WaitContinueRequest(string text = "Нажмите Enter для продолжения...")
        {
            Console.WriteLine(text);
            Console.ReadLine();
            Console.Clear();
        }
        
        public static Tree<int> GetTree(params string[] title)
        {
            Menu menu = new Menu(
                title,
                items: new string[]
                {
                    "Сгенерировать случайное дерево",
                    "Ввести значения"
                },
                back: Menu.DefaultBack,
                choice: "Выберете способ создания дерева: "
            );

            Tree<int> tree;

            int item = menu.Show();

            switch(item)
            {
                case 1:
                    {
                        int count = GetInt("Введите колличество вершин дерева (Не меньше одной): ", min: 1);

                        tree = TreeGenerator.Generate(count, (10, 100));

                        break;
                    }
                case 2:
                    {

                        int[] arr = GetArray("Введите набор целых чисел разделённых одним пробелом: ");

                        tree = TreeGenerator.Generate(arr);

                        break;
                    }

                default: tree = null; break;
            }

            Console.Clear();
            return tree;
        }
    }
}