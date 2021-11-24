using System;
using System.Collections;
using System.Collections.Generic;

namespace Lavrentev.Practice.Tree
{
    /// <summary>
    /// Вершина бинарного дерева
    /// </summary>
    /// <typeparam name="T"> Тип данных хранимых в вершине. </typeparam>
    public class TreeNode<T> : IEnumerable
    {
        public T Data { get; internal set; }

        public TreeNode<T> Parent { get; internal set; }

        public TreeNode<T> RightChild { get; internal set; } = null;
        public TreeNode<T> LeftChild { get; internal set; } = null;

        public Side? NodeSide
        {
            get
            {
                if (Parent == null)
                {
                    return null;
                }

                if(Parent.RightChild == this)
                {
                    return Side.Right;
                }
                else
                {
                    return Side.Left;
                }
            }
        }

        public int Depth { get; private set; }

        /// <summary> Создаёт корневую вершину бинарного дерева. </summary>
        public TreeNode(T data) : this(data, null, 0) { }

        /// <summary>
        /// Создаёт дочернюю вершину бинарного дерева.
        /// </summary>
        private TreeNode(T data, TreeNode<T> parent, int depth)
        {
            Data = data;
            Parent = parent;
            Depth = depth;
        }

        public TreeNode<T> AddRight(T data) => Add(data, Side.Right);

        public TreeNode<T> AddLeft(T data) => Add(data, Side.Left);

        public TreeNode<T> Add(T data, Side side)
        {
            var node = new TreeNode<T>(data, this, Depth + 1);
            
            Add(node, side);

            return node;
        }

        private void Add(TreeNode<T> node, Side side)
        {
            switch(side)
            {
                case Side.Right:
                    RightChild = node;
                    break;

                case Side.Left:
                    LeftChild = node;
                    break;

                default:
                    throw new NotSupportedException();
            }
        }

        // При удалении вершин cборшик мусора освободит
        // всю неиспользуемую память дочерних узлов автоматически.

        /// <summary> Удаляет правый дочерний узел и все его дочерние узлы.</summary>
        public void RemoveRight() => RightChild = null;

        /// <summary> Удаляет левый дочерний узел и все его дочерние узлы.</summary>
        public void RemoveLeft() => LeftChild = null;

        /// <summary>
        /// Удаляет дочерний узел со стороны side и все его дочерние узлы.
        /// </summary>
        /// <seealso cref="Side"/>
        public void RemoveChild(Side side)
        {
            switch (side)
            {
                case Side.Right:
                    RemoveRight();
                    break;

                case Side.Left:
                    RemoveLeft();
                    break;

                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Возвращает дочерний узел.
        /// </summary>
        /// <param name="side">Сторона</param>
        public TreeNode<T> GetChild(Side side)
        {
            switch (side)
            {
                case Side.Right:
                    return RightChild;

                case Side.Left:
                    return LeftChild;

                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Возвращает IEnumerator для обхода дерева.
        /// </summary>
        /// <remarks>
        /// Префиксный обход дерева без рекурсии.
        /// </remarks>
        public IEnumerator GetEnumerator()
        {
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();

            stack.Push(this);

            TreeNode<T> current;

            while(stack.Count > 0)
            {
                current = stack.Pop();

                if (current.RightChild != null)
                    stack.Push(current.RightChild);

                if (current.LeftChild != null)
                    stack.Push(current.LeftChild);

                yield return current;
            }
        }
    }
}
