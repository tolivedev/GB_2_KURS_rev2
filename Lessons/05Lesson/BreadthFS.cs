using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._05Lesson
{
    class BreadthFS
    {
            public HashSet<T> BFS<T>(Graph<T> graph, T start)
            {
                var visited = new HashSet<T>();

                if (!graph.AdjacencyList.ContainsKey(start))
                    return visited;

                var queue = new Queue<T>();
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
        
    }
}
