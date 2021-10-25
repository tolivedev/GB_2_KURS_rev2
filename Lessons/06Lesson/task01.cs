using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._06Lesson
{
    class task01
    {
 
        public task01()
        {
            Start();
        }
        public delegate Vertex DFSandBFS(Graph a, int b);
        public void Start()
        {
            var graph = new Graph(7);
            graph.AddEdge(1, 2, 1);
            graph.AddEdge(2, 3, 3);
            graph.AddEdge(2, 4, 2);
            graph.AddEdge(2, 5, 1);
            graph.AddEdge(3, 4, 1);
            graph.AddEdge(3, 5, 4);
            graph.AddEdge(4, 1, 2);
            graph.AddEdge(4, 5, 2);
            graph.AddEdge(5, 6, 3);
            graph.AddEdge(7, 4, 1);
            graph.PrintGraph();
            int search = 6;
            Console.WriteLine();

            DFSandBFS do_search = BFS;
            Test(graph, do_search, search, ConsoleColor.Green);
            do_search = DFS;
            Test(graph, do_search, search, ConsoleColor.Red);
        }

        void Test(Graph graph, DFSandBFS do_search, int value, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            var res = do_search(graph, value);
            Console.WriteLine();
            Console.WriteLine($"Результат поиска вершины со значением {value} - {res.Value}");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
        public Vertex BFS(Graph graph, int search_value)
        {
            Console.WriteLine("                          Поиск в графе в ширину");
            Console.WriteLine();
            Queue<Vertex> q = new Queue<Vertex>();
            Vertex vertex;
            HashSet<Vertex> used = new HashSet<Vertex>();         //запоминаем какие вершины уже прошли
            used.Add(graph.Vertexes[0]);
            q.Enqueue(graph.Vertexes[0]);
            Console.WriteLine("Добавляем в очередь первую вершину со значением " + graph.Vertexes[0].Value);
            while (q.Count != 0)
            {

                vertex = q.Dequeue();
                used.Add(vertex);
                Console.WriteLine("Удаляем из очереди вершину со значением " + vertex.Value);
                if (vertex.Value == search_value)
                {
                    Console.WriteLine("Мы нашли искомую вершину со значением -  " + vertex.Value);
                    return vertex;
                }
                for (int i = 0; i < vertex.Edges.Count; i++)
                {
                    if (!used.Contains(vertex.Edges[i].Vert1))
                    {
                        Console.WriteLine("Добавляем в очередь ещё не помеченную связанную вершину со значением -  " + vertex.Edges[i].Vert1.Value);
                        used.Add(vertex.Edges[i].Vert1);
                        q.Enqueue(vertex.Edges[i].Vert1);
                    }
                    if (!used.Contains(vertex.Edges[i].Vert2))
                    {
                        Console.WriteLine("Добавляем в очередь ещё не помеченную связанную вершину со значением -  " + vertex.Edges[i].Vert2.Value);
                        used.Add(vertex.Edges[i].Vert2);
                        q.Enqueue(vertex.Edges[i].Vert2);
                    }
                }
            }
            vertex = null;
            Console.WriteLine("Вершины с таким значением не найдено");
            return vertex;
        }

        public Vertex DFS(Graph graph, int search_value)
        {
            Console.WriteLine("                          Поиск в графе в глубину");
            Console.WriteLine();
            Stack<Vertex> s = new Stack<Vertex>();
            Vertex vertex;
            HashSet<Vertex> used = new HashSet<Vertex>();         //запоминаем какие вершины уже прошли
            used.Add(graph.Vertexes[0]);
            s.Push(graph.Vertexes[0]);
            Console.WriteLine("Добавляем в стек первую вершину со значением " + graph.Vertexes[0].Value);
            while (s.Count != 0)
            {
                vertex = s.Pop();
                Console.WriteLine("Вынимаем из стека вершину со значением " + vertex.Value);
                used.Add(vertex);
                if (vertex.Value == search_value)
                {
                    Console.WriteLine("Мы нашли искомую вершину со значением -  " + vertex.Value);
                    return vertex;
                }

                for (int i = 0; i < vertex.Edges.Count; i++)
                {
                    if (!used.Contains(vertex.Edges[i].Vert1))
                    {
                        Console.WriteLine("Добавляем в стек ещё не помеченную связанную вершину со значением -  " + vertex.Edges[i].Vert1.Value);
                        used.Add(vertex.Edges[i].Vert1);
                        s.Push(vertex.Edges[i].Vert1);
                    }
                    if (!used.Contains(vertex.Edges[i].Vert2))
                    {
                        Console.WriteLine("Добавляем в стек ещё не помеченную связанную вершину со значением -  " + vertex.Edges[i].Vert2.Value);
                        used.Add(vertex.Edges[i].Vert2);
                        s.Push(vertex.Edges[i].Vert2);
                    }
                }
            }
            Console.WriteLine("Вершины с таким значением не найдено");
            vertex = null;
            return vertex;
        }
    }
}
