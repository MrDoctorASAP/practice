using System.Collections;

namespace Lavrentev.Practice.Tree
{
    /// <summary>
    /// Бинарное дерево.
    /// </summary>
    /// <typeparam name="T"> Тип данных, хранимый в вершинах. </typeparam>
    public class Tree<T> : IEnumerable
    {
        public TreeNode<T> Root { get; private set; } = null;
        
        public Tree() { }

        public Tree(TreeNode<T> root)
        {
            Root = root;
        }

        public Tree(T rootData)
        {
            Root = new TreeNode<T>(rootData);
        }

        public IEnumerator GetEnumerator() => Root?.GetEnumerator();

        public void Print() => Root?.Print();
    }
}
