using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._06Lesson
{
    public interface IGraph
    {
        void AddVertex(int value); 
        void AddEdge(int value1, int value2, int weight);
        Vertex GetVertexByValue(int value); 
        void PrintGraph(); 
    }

    public class Graph : IGraph
    {
        public List<Vertex> Vertexes = new List<Vertex>();
        public Graph()
        {
        }
        public Graph(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                AddVertex(i);
            }
        }
        public void AddEdge(int startvalue, int endvalue, int weight)
        {
            var vertex1 = GetVertexByValue(startvalue);
            var vertex2 = GetVertexByValue(endvalue);
            if (vertex1 == null || vertex2 == null)
                return;
            var edge = new Edge() { Vert1 = vertex1, Vert2 = vertex2, Weight = weight };
            vertex1.Edges.Add(edge);
            vertex2.Edges.Add(edge);
        }

        public void AddVertex(int value)
        {
            var vertex = new Vertex() { Value = value };
            Vertexes.Add(vertex);
        }

        public Vertex GetVertexByValue(int value)
        {
            foreach (var item in Vertexes)
            {
                if (item.Value == value)
                    return item;
            }
            Vertex zero = new Vertex();
            return zero;
        }
        public void PrintGraph()
        {
            foreach (var v in Vertexes)
            {
                Console.WriteLine($"Вершина со значением - {v.Value}");
                foreach (var edge in v.Edges)
                {
                    Console.WriteLine($"Имеет ребро между вершинами со значениями - {edge.Vert1.Value} и {edge.Vert2.Value}, вес ребра  - {edge.Weight}.");
                }
                Console.Write(String.Empty);

            }
        }
    }

}
