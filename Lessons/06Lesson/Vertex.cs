using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._06Lesson
{
    public class Vertex
    {
        public int Value { get; set; }
        public List<Edge> Edges = new List<Edge>();
    }
    public class Edge
    {
        public int Weight { get; set; }
        public Vertex Vert1 { get; set; }
        public Vertex Vert2 { get; set; }
    }
}
