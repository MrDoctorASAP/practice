using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lavrentev.Practice;
using Lavrentev.Practice.Tasks;
using Lavrentev.Practice.Tree;

namespace Lavrentev.Practice.Presentation
{
    public class Presentation
    {
        private static readonly Menu main = new Menu(

            title: new string[]
            {
                "Выполнил Лаврентьев, 6213",
            },

            items: new string[]
            {
                "Задание 1 (Tree26)",
                "Задание 2 (Tree39)",
                "Задание 3 (Tree43)",
            },

            back: "Выход из программы"
        );

        public void Show() 
        {
            int task = main.Show();
            
            switch(task)
            {
                case 1: Task1(); break;
                case 2: Task2(); break;
                case 3: Task3(); break;
                case 0: Exit(); break;
            }
        }

        private void Task1()
        {
            Console.WriteLine("Формулировка задания 1 (Tree 26)");
            Console.WriteLine("Дано число N (> 0) и набор из N чисел. Создать дерево из N вершин, в");
            Console.WriteLine("котором каждая внутренняя вершина имеет только одну дочернюю вершину,");
            Console.WriteLine("причем правые и левые дочерние вершины чередуются");
            Console.WriteLine("(корень имеет левую дочернюю вершину).");
            Console.WriteLine("Каждой создаваемой вершине присваивать очередное значение из исходного набора.");
            Console.WriteLine("Вывести указатель на корень созданного дерева.");

            Console.WriteLine();

            int[] arr = Input.GetArray("Введите набор целых чисел разделённых одним пробелом: ");

            Tree<int> tree = Task.Tree26(arr);

            Console.WriteLine();
            Console.WriteLine("Созданное дерево: ");

            tree.Print();

            Console.WriteLine();
            Console.WriteLine();
            Input.WaitContinueRequest();
        }

        private void Task2()
        {
            string[] task = new string[]
            {
                "Формулировка задания 2 (Tree 39)",
                "Дан указатель P1 на корень непустого дерева. ",
                "Для всех внутренних вершин дерева поменять местами",
                "их левые и правые дочерние вершины",
                "(то есть значения полей Left и Right).",
            };

            TransformTask(task, Task.Tree39);
        }

        private void Task3() 
        {
            string[] task = new string[] 
            {
                "Формулировка задания 3 (Tree 43)",
                "Дан указатель P1 на корень непустого дерева. Для вершин дерева,",
                "имеющих две дочерние вершины, удалить одну из дочерних вершин:",
                "правую, если родительская вершина имеет четное значение, и левую в противном случае",
                "(вершины дерева перебирать в префиксном порядке,",
                "при удалении вершины удалять и всех ее потомков).",
                "Для удаленных вершин освобождать память, которую они занимали.",
            };

            TransformTask(task, Task.Tree43);
        }

        private void TransformTask(string[] task, Func<TreeNode<int>, TreeNode<int>> transform)
        {
            if (task == null)
                throw new ArgumentNullException("task");

            if(transform == null)
                throw new ArgumentNullException("transform");

            Tree<int> origin = Input.GetTree(task);

            if (origin == null)
                return;

            Print(task);
            Console.WriteLine();

            Console.WriteLine("Созданное дерево : ");

            origin.Print();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Преобразованное дерево : ");

            TreeNode<int> transformed = transform(origin.Root);

            transformed.Print();

            Console.WriteLine();
            Console.WriteLine();
            Input.WaitContinueRequest();
        }

        private static void Print(params string[] str)
        {
            foreach(var s in str)
            {
                Console.WriteLine(s);
            }
        }

        private static void Exit()
        {
            Environment.Exit(0);
        }
    }
}
