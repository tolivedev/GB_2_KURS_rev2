using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._05Lesson
{
    class BreadthFS
    {
        private BreadthFS()
        {

        }
        public BreadthFS(task01 tsk)
        {
            this.tsk = tsk;
        }
        task01 tsk = null;
        internal TreeNode BFS(Tree tree, int search_value)
        {
            int i = 0;
            TreeNode res;

            Console.WriteLine();
            
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(tree.GetRoot()); //обходим дерево в ширину с помощью очереди в поисках нужного значения, если его нет, возвращаем пустой элемент
            tsk.PrintStepQueue(queue);
            Console.WriteLine($"\nСравниваем первый в очереди '{tree.GetRoot().Value}' с искомым '{search_value}', " +
                $"\nОни не равны, поэтому вытаскиваем его и добавляем в очередь двух его 'детей': {tree.GetRoot().LeftChild.Value} и {tree.GetRoot().RightChild.Value}\n");
            while (queue.Count != 0)
            {
                int now = queue.Peek().Value;
                res = queue.Dequeue();
                if (res?.Value == search_value)
                {
                    Console.WriteLine($"\nСравниваем первый в очереди '{now}' с искомым '{search_value}', " +
                        "\nОни равны, искомый элемент найден.");
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
                if (i != 0)
                {
                    Console.WriteLine($"\nСравниваем первый в очереди '{now}' с искомым '{search_value}', " +
                        $"\nОни не равны, поэтому вытаскиваем его и добавляем в очередь двух его 'детей' (если они есть): {res.LeftChild?.Value} и {res.RightChild?.Value}.\n");
                }
                tsk.PrintStepQueue(queue);
                i++;
            }
            Console.WriteLine("Искомый элемент не найден");
            return new TreeNode();
        }
#if false
        public HashSet<T> BFS<T>(Graph<T> graph, T start)
        {
            HashSet<T> visited = new HashSet<T>();

            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;

            Queue<T> queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);

                foreach (var neighbor in graph.AdjacencyList[vertex])
                    if (!visited.Contains(neighbor))
                        queue.Enqueue(neighbor);
            }

            return visited;
        }

    
#endif
    }
}
