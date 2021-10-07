using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._02Lesson
{
    class task01
    {
        public task01()
        {
            LinkedList<string> LL = new LinkedList<string>();

            LL.AddNode(new Node<string>("AAAA"));
            LL.AddNode(new Node<string>("BBBB"));
            LL.AddNode(new Node<string>("CCCC"));
            LL.AddNode(new Node<string>("DDDD"));

            LL.RemoveNode(2);
            Console.WriteLine("Удалим ноду по индексу 2, итого осталось: " + LL.GetCount());

        }
    }
}
