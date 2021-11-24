using System.Collections.Generic;
using Lavrentev.Practice.Tree;

namespace Lavrentev.Practice.Tasks
{
    public static class Task
    {
        /* Задание 1. Tree26.
         * Дано число N (> 0) и набор из N чисел. Создать дерево из N вершин, в
         * котором каждая внутренняя вершина имеет только одну дочернюю вершину,
         * причем правые и левые дочерние вершины чередуются (корень имеет левую дочернюю вершину). 
         * Каждой создаваемой вершине присваивать очередное значение из исходного набора.
         * Вывести указатель на корень созданного дерева.
         */
        public static Tree<int> Tree26(int[] arr)
        {
            int N = arr.Length;

            TreeNode<int> root = new TreeNode<int>(arr[0]);
            TreeNode<int> current = root;

            for(int i = 1; i < N; i++)
            {
                if(i % 2 == 0)
                {
                    current.AddRight(arr[i]);
                    current = current.RightChild;
                }
                else
                {
                    current.AddLeft(arr[i]);
                    current = current.LeftChild;
                }
            }

            return new Tree<int>(root);
        }

        /* Задание 2. Tree39.
         * Дан указатель P1 на корень непустого дерева. 
         * Для всех внутренних вершин дерева поменять местами их левые и правые дочерние вершины
         * (то есть значения полей Left и Right).
         */
        public static TreeNode<T> Tree39<T>(TreeNode<T> root)
        {
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();

            stack.Push(root);

            TreeNode<T> current;

            while (stack.Count > 0)
            {
                current = stack.Pop();

                var temp = current.LeftChild;
                current.LeftChild = current.RightChild;
                current.RightChild = temp;

                if (current.RightChild != null)
                    stack.Push(current.RightChild);

                if (current.LeftChild != null)
                    stack.Push(current.LeftChild);
            }

            return root;
        }

        /* Задание 3. Tree43.
         * Дан указатель P1 на корень непустого дерева. Для вершин дерева,
         * имеющих две дочерние вершины, удалить одну из дочерних вершин:
         * правую, если родительская вершина имеет четное значение, и левую в противном случае
         * (вершины дерева перебирать в префиксном порядке,
         * при удалении вершины удалять и всех ее потомков).
         * Для удаленных вершин освобождать память, которую они занимали.
         */
        public static TreeNode<int> Tree43(TreeNode<int> root)
        {
            Stack<TreeNode<int>> stack = new Stack<TreeNode<int>>();

            stack.Push(root);

            TreeNode<int> current;

            while (stack.Count > 0)
            {
                current = stack.Pop();

                if(current.RightChild != null && current.LeftChild != null)
                {
                    if(current.Data % 2 == 0)
                    {
                        current.RemoveRight();
                    }
                    else
                    {
                        current.RemoveLeft();
                    }
                }

                if (current.RightChild != null)
                    stack.Push(current.RightChild);

                if (current.LeftChild != null)
                    stack.Push(current.LeftChild);
            }

            return root;
        }
    }
}
