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
            trN = new(1);
            StartCreateTree();
        }
        Tree trN;

        private void StartCreateTree()
        {
            //trN.AddItem(1);

            //trN.AddItem(2);
            //trN.AddItem(3);
            //trN.AddItem(4);
            //trN.AddItem(5);
            //trN.AddItem(6);
            //trN.AddItem(7);


            trN.AddItems(4);
            trN.AddItems(5);
            trN.AddItems(6);
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

        // по идее, ноде дерева список вершин не нужен, только для графа. но потом такой код проще адаптировать
        public List<TreeNode<T>> vertices { get; }
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
        void AddItem(T value); // добавить узел
        void RemoveItem(T value); // удалить узел по значению
        TreeNode<T> GetNodeByValue(T value); //получить узел дерева по значению
        void PrintTree(); //вывести дерево в консоль
    }

    public class Tree : ITree<int>
    {
        //Queue<TreeNode<int>> queNodes = new();
        //private TreeNode<int> node = null;
        int count = 0;
        int level = 1;

        private TreeNode<int> root = null;

        HashSet<TreeNode<int>> hsNodes = new();
        public List<TreeNode<int>> tree = new List<TreeNode<int>>(10);

        public Tree(int valueRoot)
        {
            root = new TreeNode<int>() { Value = valueRoot };
            tree.Add(null);
            //tree.Add(root);
            tree.Insert(1, root);
            hsNodes.Add(root);
        }

#if true
        public void AddItem(int value)
        {
            for (int i = 1; i < tree.Count; i++)         //ищем есть ли пропуски в массиве, если есть вставляем элемент в него
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
            var newnode = new TreeNode<int>() { Value = value };   //если в массиве пропусков нет, то добавляем в конец новый элемент
            int n = tree.Count;
            tree.Add(newnode);
            newnode.Parent = tree[n / 2];
            if (n % 2 == 0)
            {
                tree[n / 2].LeftChild = newnode;
            }
            else
            {
                tree[n / 2].RightChild = newnode;
            }

        }
#endif

        public TreeNode<int> AddItems(int value)
        {
            var currNode = new TreeNode<int>();
            int level = 0;
            Console.WriteLine();
            TreeNode<int> deqNode = new TreeNode<int>();
            var fail = new TreeNode<int>();
            var queue = new Queue<TreeNode<int>>();

            if (hsNodes.Count < 2)
            {
                queue.Enqueue(root);
            }

            hsNodes.Add(new TreeNode<int>(value));

            while (queue.Count != 0)
            {
                int now = queue.Peek().Value;
                deqNode = queue.Dequeue();

                //if (deqNode.Value == search_value)
                if (deqNode.LeftChild != null && deqNode.RightChild != null)
                {
                    Console.WriteLine($"\nОба наследника");
                    deqNode = deqNode.Parent;
                    continue;
                    //queue.Enqueue()
                    //return deqNode;
                }
                if (deqNode.LeftChild != null)
                {
                    queue.Enqueue(deqNode.LeftChild);
                    hsNodes.Add(deqNode.LeftChild);
                    continue;
                }
                if (deqNode.RightChild != null)
                {
                    queue.Enqueue(deqNode.RightChild);
                    hsNodes.Add(deqNode.RightChild);
                    continue;
                }
                if (level != 0)
                {
                    //Console.WriteLine($"\nСравниваем первый в очереди '{deqNode.Value}' с искомым '{value}', ");
                    //Console.WriteLine($"Они не равны, поэтому вытаскиваем его и добавляем в очередь двух его 'детей' (если они есть): {deqNode.LeftChild.Value} и {deqNode.RightChild.Value}.");
                }
                //PrintStepQueue(queue);
                level++;



            }
            queue = new Queue<TreeNode<int>>(hsNodes);
            Console.WriteLine("Искомый элемент не найден, поэтому возвращаем пустой элемент");
            return fail;
        }

        private void Example()
        {
            if (hsNodes.Count % 2 == 0)
            {
                //node=hsNodes[0]

                if (deqNode.LeftChild != null)
                {
                    queue.Enqueue(deqNode.LeftChild);
                    hsNodes.Add(deqNode.LeftChild);
                    continue;
                }
                if (deqNode.RightChild != null)
                {
                    queue.Enqueue(deqNode.RightChild);
                    hsNodes.Add(deqNode.RightChild);
                    continue;
                }
            }
            //return null;
            else
            {
                TreeNode<int> newNode = null;
                var nl = n / 2;
                var nr = n - nl - 1;
                newNode = new TreeNode<int>();
                newNode.Value = new Random().Next();
                newNode.Left = Tree(nl);
                newNode.Right = Tree(nr);

            }
        }

#if false
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

            node = new TreeNode<int>(value);

            foreach (var item in hsNodes)
            {
                if ((hsNodes.Count - 1) % 2 == 0)
                {

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

#endif




        public TreeNode<int> GetNodeByValue(int value)
        {
            while (value != 0)
            {

            }
            return null;
        }

        public TreeNode<int> GetRoot()
        {
            if (tree[1] != null)
            {
                return tree[1];
            }
            throw new NullReferenceException();
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

    public class TreeHelper
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
