using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._04Lesson
{
    class task02
    {
        public task02()
        {
            trN = new();
            StartCreateTree();
        }
        Tree trN;

        private void StartCreateTree()
        {
            trN.AddItem(1);
            trN.AddItem(2);
            trN.AddItem(3);
            trN.AddItem(4);
            trN.AddItem(5);
            trN.AddItem(6);
            trN.AddItem(7);
        }
    }

    public class TreeNode<T>
    {
        public TreeNode()
        {

        }
        public TreeNode(T value)
        {
            this.Value = value;
        }
        public T Value { get; set; }
        public TreeNode<T> LeftChild { get; set; }
        public TreeNode<T> RightChild { get; set; }
        public List<TreeNode<T>> vertices { get; }  // по идее, ноде дерева список вершин не нужен, только для графа. но потом такой код проще адаптировать
        public Tree self_Tree { get; set; }
        public bool Passed { get; set; }

        public TreeNode<T> Parent { get; set; }

        //public override bool Equals(object obj)
        //{
        //    var node = obj as TreeNode<T>;

        //    if (node == null)
        //        return false;

        //    return node.Value == Value;
        //}
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }

    public interface ITree<T>
    {
        TreeNode<T> GetRoot();
        void AddItem(int value); // добавить узел
        void RemoveItem(int value); // удалить узел по значению
        TreeNode<T> GetNodeByValue(int value); //получить узел дерева по значению
        void PrintTree(); //вывести дерево в консоль
    }

    public class Tree : ITree<int>
    {
        Queue<TreeNode<int>> queNodes = new();
        HashSet<TreeNode<int>> hsNodes = new();
        private TreeNode<int> root = null;
        private TreeNode<int> node = null;

        public void AddItem(int value)
        {
            TreeNode<int> l_Node = null;
            TreeNode<int> r_Node = null;
            if (root == null)
            {
                root = new TreeNode<int>(value)
                {
                    Parent = null,
                    //LeftChild = new TreeNode<int>(),
                    //RightChild = new(),
                    //Value = value
                };
                node = root;
                hsNodes.Add(root);
                queNodes.Enqueue(root);
                return;
            }
            else if (node.LeftChild == null)
            {

                node.LeftChild = new TreeNode<int>(value);
                node.LeftChild.Parent = root;
                hsNodes.Add(node.LeftChild);

            }
            else if (node.RightChild == null)
            {
                node.RightChild = new TreeNode<int>(value);
                root.RightChild.Parent = root;
                hsNodes.Add(node.RightChild);
            }

            if (node.LeftChild != null && node.RightChild != null)
            {
                node = node.LeftChild;
                
                foreach (TreeNode<int> items in hsNodes)
                {
                    if (items == null)
                    {
                        AddItem(value);
                    }
                }
            }




            //lsNode.Add()
            //if (root != null)
            //{
            //    if (searchValue != null)
            //    {
            //        do
            //        {
            //            if (c.Equals(node.Data, searchValue))
            //            {
            //                return node;
            //            }
            //            node = node.Next;
            //        } while (node != head);
            //    }
            //    else
            //    {
            //        do
            //        {
            //            if (node.Data == null)
            //            {
            //                return node;
            //            }
            //            node = node.Next;
            //        } while (node != head);
            //    }
            //}

            //TreeNode newNode = null;
            //if (value == 0)
            //    return;
            //else
            //{
            //    var nl = value / 2;
            //    var nr = value - nl - 1;
            //    newNode = new TreeNode();
            //    newNode.Value = new Random().Next();
            //    newNode.LeftChild = TreeNode(nl);
            //    newNode.RightChild = TreeNode(nr);
            //}
            //return newNode;




        }

        public TreeNode<int> GetNodeByValue(int value)
        {
            while (value != 0)
            {

            }
            return null;
        }

        public TreeNode<int> GetRoot()
        {
            if (node.Parent == null)
            {
                return node;
            }
            return null;
        }

        public void PrintTree()
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(int value)
        {
            throw new NotImplementedException();
        }
    }

    public static class TreeHelper
    {
        public static NodeInfo[] GetTreeInLine(ITree<int> tree)
        {
            var bufer = new Queue<NodeInfo>();
            var returnArray = new List<NodeInfo>();
            var root = new NodeInfo() { Node = tree.GetRoot() };
            bufer.Enqueue(root);

            while (bufer.Count != 0)
            {
                var element = bufer.Dequeue();
                returnArray.Add(element);

                var depth = element.Depth + 1;

                if (element.Node.LeftChild != null)
                {
                    var left = new NodeInfo()
                    {
                        Node = element.Node.LeftChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(left);
                }
                if (element.Node.RightChild != null)
                {
                    var right = new NodeInfo()
                    {
                        Node = element.Node.RightChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(right);
                }
            }

            return returnArray.ToArray();
        }
    }

    public class NodeInfo
    {
        public int Depth { get; set; }
        public TreeNode<int> Node { get; set; }
    }

}
