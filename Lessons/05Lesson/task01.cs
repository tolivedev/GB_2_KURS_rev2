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
            Start();
        }

        public void Start()
        {
            var tree = new Tree(20);
            for (int i = 0; i < 15; i++)
            {
                tree.AddItem(i * 5);
            }
            Console.WriteLine("\t\tНаше дерево: ");
            tree.PrintTree(tree.GetRoot(), 0);
            int search_value = 45;

            Console.WriteLine("\nПоиск в ширину" +
                "\nНиже изменения очереди на каждой итерации:");
            var res = BFS(tree, search_value);

            Console.WriteLine("\t\tНаше дерево: \n");

            tree.PrintTree(tree.GetRoot(), 0);
            Console.WriteLine("\nПоиск в глубину\n" +
                "Ниже изменения стека на каждой итерации:");
            res = DFS(tree, search_value);

            Console.WriteLine();
        }
        void PrintStepQueue(Queue<TreeNode> queue)
        {
            Console.Write("       ");
            foreach (var item in queue)
            {
                Console.Write(item.Value + " ");
            }
            Console.WriteLine();
        }
        void PrintStepStack(Stack<TreeNode> stack)
        {
            Console.Write("       ");
            foreach (var item in stack)
            {
                Console.Write(item.Value + " ");
            }
            Console.WriteLine();
        }
        TreeNode BFS(Tree tree, int search_value)
        {
            int i = 0;
            Console.WriteLine();
            var res = new TreeNode();
            var fail = new TreeNode();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(tree.GetRoot()); //обходим дерево в ширину с помощью очереди в поисках нужного значения, если его нет, возвращаем пустой элемент
            PrintStepQueue(queue);
            Console.WriteLine($"\nСравниваем первый в очереди '{tree.GetRoot().Value}' с искомым '{search_value}', " +
                $"\nОни не равны, поэтому вытаскиваем его и добавляем в очередь двух его 'детей': {tree.GetRoot().LeftChild.Value} и {tree.GetRoot().RightChild.Value}\n");
            while (queue.Count != 0)
            {
                int now = queue.Peek().Value;
                res = queue.Dequeue();
                if (res?.Value == search_value)
                {
                    Console.WriteLine($"\nСравниваем первый в очереди '{now}' с искомым '{search_value}', " +
                        "\nОни равны, искомый элемент найден! Возвращаем его значание, прекращаея обход.");
                    return res;
                }
                if (res.LeftChild != null)
                {
                    queue.Enqueue(res.LeftChild);
                }
                if (res.RightChild != null)
                {
                    queue.Enqueue(res.RightChild);
                }
                if (i != 0)
                {
                    Console.WriteLine($"\nСравниваем первый в очереди '{now}' с искомым '{search_value}', " +
                        $"\nОни не равны, поэтому вытаскиваем его и добавляем в очередь двух его 'детей' (если они есть): {res.LeftChild.Value} и {res.RightChild.Value}.\n");
                }
                PrintStepQueue(queue);
                i++;
            }
            Console.WriteLine("Искомый элемент не найден, поэтому возвращаем пустой элемент");
            return fail;
        }
        TreeNode DFS(Tree tree, int search_value)
        {
            int i = 0;
            Console.WriteLine();
            var res = new TreeNode();
            var fail = new TreeNode();
            var stack = new Stack<TreeNode>();
            stack.Push(tree.GetRoot());                  //обходим дерево в глубину с помощью стека, иначе возвращаем пустой элемент
            PrintStepStack(stack);
            Console.WriteLine($"\nСравниваем последний в стеке '{tree.GetRoot().Value}' с искомым '{search_value}', " +
                $"\nОни не равны, поэтому вытаскиваем его и добавляем в стек двух его 'детей': {tree.GetRoot().LeftChild.Value} и {tree.GetRoot().RightChild.Value}\n");
            while (stack.Count != 0)
            {
                int now = stack.Peek().Value;
                res = stack.Pop();
                if (res?.Value == search_value)
                {
                    Console.WriteLine($"\nСравниваем первый в стеке '{now}' с искомым '{search_value}', " +
                        "\nОни равны, искомый элемент найден! Возвращаем его значание, прекращаея обход.");
                    return res;
                }
                if (res.LeftChild != null)
                {
                    stack.Push(res?.LeftChild);
                }
                if (res.RightChild != null)
                {
                    stack.Push(res?.RightChild);
                }
                if (i != 0)
                {
                    Console.WriteLine($"\nСравниваем последний в стеке '{now}' с искомым '{search_value}', ");
                    Console.WriteLine($"Они не равны, поэтому вытаскиваем его и добавляем в стек двух его 'детей' (если они есть): {res.LeftChild.Value} и {res.RightChild.Value}.\n");
                }
                PrintStepStack(stack);
                i++;
            }
            Console.WriteLine("Искомый элемент не найден, поэтому возвращаем пустой элемент");
            return fail;
        }
    }
}

