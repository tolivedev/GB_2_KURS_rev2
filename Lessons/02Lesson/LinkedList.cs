using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._02Lesson
{
    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList<T>
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(Node<T> value);  // добавляет новый элемент списка
        void AddNodeAfter(Node<T> node, Node<T> value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node<T> node); // удаляет указанный элемент
        Node<T> FindNode(T searchValue); // ищет элемент по его значению
    }
    class LinkedList<T> : ILinkedList<T>
    {
        internal Node<T> head;
        internal int count;
        internal int version;

        public Node<T> First
        {
            get { return head; }
        }

        public Node<T> Last
        {
            get { return head == null ? null : head.Previous; }
        }

        public void AddNode(Node<T> value)
        {
            AddLast(value);
        }

        public void AddLast(Node<T> node)
        {
            if (head == null)
            {
                InternalInsertNodeToEmptyList(node);
            }
            else
            {
                InternalInsertNodeBefore(head, node);
            }
        }

        public void AddNodeAfter(Node<T> node, Node<T> newNode)
        {
            InternalInsertNodeBefore(node.Next, newNode);
        }

        public Node<T> FindNode(T searchValue)
        {
            Node<T> node = head;
            EqualityComparer<T> c = EqualityComparer<T>.Default;
            if (node != null)
            {
                if (searchValue != null)
                {
                    do
                    {
                        if (c.Equals(node.Data, searchValue))
                        {
                            return node;
                        }
                        node = node.Next;
                    } while (node != head);
                }
                else
                {
                    do
                    {
                        if (node.Data == null)
                        {
                            return node;
                        }
                        node = node.Next;
                    } while (node != head);
                }
            }
            return null;
        }

        public int GetCount()
        {
            return count;
        }

        public void RemoveNode(int index)
        {
            Node<T> current = head;

            for (int i = 0; i != index; i++)
            {
                current = current.Next;
            }
            current.Previous.Next = current.Next;
            current.Next.Previous = current.Previous;
            count--;

        }

        public void RemoveNode(Node<T> node)
        {
            if (node.Next == node)
            {
                head = null;
            }
            else
            {
                node.Next.Previous = node.Previous;
                node.Previous.Next = node.Next;
                if (head == node)
                {
                    head = node.Next;
                }
            }
            count--;
        }

        private void InternalInsertNodeBefore(Node<T> node, Node<T> newNode)
        {
            newNode.Next = node;
            newNode.Previous = node.Previous;
            node.Previous.Next = newNode;
            node.Previous = newNode;
            count++;
        }
        private void InternalInsertNodeToEmptyList(Node<T> newNode)
        {
            newNode.Next = newNode;
            newNode.Previous = newNode;
            head = newNode;
            count++;

        }


        //public bool MoveNext()
        //{
        //    if (position < count)
        //    {
        //        position++;
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        // Установить указатель (position) перед началом набора.
        //public void Reset()
        //{
        //    position = -1;
        //}

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}

        //// Получить текущий элемент набора. 
        //public object Current
        //{
        //    get { return elementsArray[position]; }
        //}

        //T IEnumerator<T>.Current => throw new NotImplementedException();
    }

}
