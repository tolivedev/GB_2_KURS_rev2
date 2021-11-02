using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._05Lesson
{
    public class Tree : ITree
    {
        public TreeNode root;
        public List<TreeNode> tree = new(10);

        public Tree(int valueRoot)
        {
            root = new TreeNode() { Value = valueRoot };
            tree.Add(null);
            tree.Add(root);
        }
        public void AddItem(int value)
        {
            for (int i = 1; i < tree.Count; i++)   //проверка на нулевые значения, true - заменяем
            {
                if (tree[i].Value == 0)
                {
                    tree[i].Parent = tree[i / 2];
                    tree[i].Value = value;
                    if (i % 2 == 0)
                    {
                        tree[i / 2].LeftChild = tree[i];
                    }
                    else
                    {
                        tree[i / 2].RightChild = tree[i];
                    }
                    return;
                }
            }
            var newnode = new TreeNode() { Value = value };   //добавляем в конец новый элемент
            int amountBefore = tree.Count;
            tree.Add(newnode);
            newnode.Parent = tree[amountBefore / 2];
            if (amountBefore % 2 == 0)
            {
                tree[amountBefore / 2].LeftChild = newnode;
            }
            else
            {
                tree[amountBefore / 2].RightChild = newnode;
            }

        }

        public TreeNode GetNodeByValue(int value)
        {
            TreeNode res;
            Queue<TreeNode> queue = new();
            queue.Enqueue(tree[1]);    //обходим дерево в ширину в поисках искомого, иначе возвращаем пустой элемент
            while (queue.Count != 0)
            {
                res = queue.Dequeue();
                if (res.Value == value)
                {
                    return res;
                }
                if (res.LeftChild != null)
                {
                    queue.Enqueue(res?.LeftChild);
                }
                if (res.RightChild != null)
                {
                    queue.Enqueue(res?.RightChild);
                }
            }
            return new TreeNode();
        }

        public TreeNode GetRoot()
        {
            return tree[1];
        }

        public void PrintTree(TreeNode tree, int depth)
        {
            if (tree != null)  //рекурсивно выводим элементы по уровням
            {
                PrintTree(tree.LeftChild, depth + 1);
                for (int i = 0; i < depth; ++i) Console.Write("      ");
                Console.WriteLine(" -" + tree.Value + "{");
                PrintTree(tree.RightChild, depth + 1);
            }
        }
        private int GetIndexByValue(int value)
        {
            for (int i = 1; i < tree.Count; i++)
            {
                if (tree[i].Value == value)
                {
                    return i;
                }
            }
            return 0;
        }
        private void ClearNode(TreeNode node)
        {
            node.Parent = null;
            node.Value = 0;
            node.LeftChild = null;
            node.RightChild = null;
        }
        public void RemoveItem(int value)
        {
            int index = GetIndexByValue(value);
            if (index == 0)
            {
                Console.WriteLine($"Элемент со значением {value} не найден");
                return;
            }
            if (index % 2 == 0)
            {
                tree[index / 2].LeftChild = null;
            }
            else
            {
                tree[index / 2].RightChild = null;
            }
            ClearNode(tree[index]);
            for (int i = index * 2; i < tree.Count; i *= 2)
            {

                ClearNode(tree[i]);
                ClearNode(tree[i + 1]);
            }
        }
    }

    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Parent { get; set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }

        public override bool Equals(object obj)
        {
            var node = obj as TreeNode;

            if (node == null)
                return false;

            return node.Value == Value;
        }
    }

    public interface ITree
    {
        TreeNode GetRoot();
        void AddItem(int value); // добавить узел
        void RemoveItem(int value); // удалить узел по значению
        TreeNode GetNodeByValue(int value); //получить узел дерева по значению
        void PrintTree(TreeNode tree, int depth); //вывести дерево в консоль
    }
}
