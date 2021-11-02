using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._05Lesson
{
    class task01
    {

        public task01()
        {
            bfsInst = new BreadthFS(this);
            dfsInst = new DeepFS(this);
            Start();
        }
        BreadthFS bfsInst = null;
        DeepFS dfsInst = null;

        public void Start()
        {
            Tree tree = new Tree(20);
            for (int i = 0; i < 15; i++)
            {
                tree.AddItem(i * 5);
            }
            Console.WriteLine("\t\tНаше дерево: ");
            tree.PrintTree(tree.GetRoot(), 0);
            dynamic search_value = 45;

            Console.WriteLine("\nПоиск в ширину" +
                "\nНиже изменения очереди на каждой итерации:");
            bfsInst.BFS(tree, search_value);

            Console.WriteLine("\n\t\tНаше дерево: \n");

            tree.PrintTree(tree.GetRoot(), 0);
            Console.WriteLine("\nПоиск в глубину\n" +
                "Ниже изменения стека на каждой итерации:");
            dfsInst.DFS(tree, search_value);

            Console.WriteLine();
        }
        internal void PrintStepQueue(Queue<TreeNode> queue)
        {
            Console.Write("       ");
            foreach (var item in queue)
            {
                Console.Write(item.Value + " ");
            }
            Console.WriteLine();
        }
        internal void PrintStepStack(Stack<TreeNode> stack)
        {
            Console.Write("       ");
            foreach (var item in stack)
            {
                Console.Write(item.Value + " ");
            }
            Console.WriteLine();
        }
        
        
    }
}

