using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._05Lesson
{
    class DeepFS
    {
        private DeepFS()
        {

        }
        public DeepFS(task01 tsk)
        {
            this.tsk = tsk;
        }
        task01 tsk = null;
        internal TreeNode DFS(Tree tree, int search_value)
        {
            int i = 0;
            TreeNode res;

            Console.WriteLine();

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(tree.GetRoot());                  //обходим дерево в глубину с помощью стека, иначе возвращаем пустой элемент
            tsk.PrintStepStack(stack);
            Console.WriteLine($"\nСравниваем последний в стеке '{tree.GetRoot().Value}' с искомым '{search_value}', " +
                $"\nОни не равны, поэтому вытаскиваем его и добавляем в стек двух его 'детей': {tree.GetRoot().LeftChild.Value} и {tree.GetRoot().RightChild.Value}\n");
            while (stack.Count != 0)
            {
                int now = stack.Peek().Value;
                res = stack.Pop();
                if (res?.Value == search_value)
                {
                    Console.WriteLine($"\nСравниваем первый в стеке '{now}' с искомым '{search_value}', " +
                        "\nОни равны, искомый элемент найден.");
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
                    Console.WriteLine($"\nСравниваем последний в стеке '{now}' с искомым '{search_value}', " +
                    $"Они не равны, поэтому вытаскиваем его и добавляем в стек двух его 'детей' (если они есть): {res.LeftChild?.Value} и {res.RightChild?.Value}.\n");
                }
                tsk.PrintStepStack(stack);
                i++;
            }
            Console.WriteLine("Искомый элемент не найден");
            return new TreeNode();
        }

#if false
        public void DFS(int s)
        {
            bool[] visited = new bool[Vertices];

            //For DFS use stack
            Stack<int> stack = new Stack<int>();
            visited[s] = true;
            stack.Push(s);

            while (stack.Count != 0)
            {
                s = stack.Pop();
                Console.WriteLine("next->" + s);
                foreach (int i in adj[s])
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        stack.Push(i);
                    }
                }
            }
        }
#endif
    }
}
