using Lavrentev.Practice.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavrentev.Practice.Presentation
{
    /// <summary>
    /// Класс содержит методы для создания деревьев по заданным параметрам.
    /// </summary>
    public class TreeGenerator
    {
        private static readonly Random random = new Random();

        /// <summary>
        /// Создаёт бинарное дерево с типом данных int.
        /// С колличеством вершин count.
        /// Занчения вершин задаются случайными числами в диапозоне valuesRange.
        /// </summary>
        public static Tree<int> Generate(int count, (int, int) valuesRange)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException();

            if (valuesRange.Item1 > valuesRange.Item2)
                throw new ArgumentException();

            int[] values = new int[count];

            for(int i = 0; i < count; i++)
            {
                values[i] = random.Next(valuesRange.Item1, valuesRange.Item2);
            }

            return Generate(values);
        }

        /// <summary>
        /// Создаёт бинарное дерево поиска с сравнимым типом данным T по заданному набору значений.
        /// </summary>
        public static Tree<T> Generate<T>(params T[] values) where T : IComparable
        {
            if (values.Length == 0)
                throw new ArgumentOutOfRangeException();

            TreeNode<T> root = new TreeNode<T>(values[0]);
            T currentValue;
            TreeNode<T> currentNode;

            for(int i = 1; i < values.Length; i++)
            {
                currentValue = values[i];
                currentNode = root;

                while (true)
                {
                    if(currentNode.Data.CompareTo(currentValue) >= 0)
                    {
                        if(currentNode.LeftChild == null)
                        {
                            currentNode.AddLeft(currentValue);
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.LeftChild;
                        }
                    }
                    else
                    {
                        if (currentNode.RightChild == null)
                        {
                            currentNode.AddRight(currentValue);
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.RightChild;
                        }
                    }
                }
            }

            return new Tree<T>(root);
        }

    }
}
