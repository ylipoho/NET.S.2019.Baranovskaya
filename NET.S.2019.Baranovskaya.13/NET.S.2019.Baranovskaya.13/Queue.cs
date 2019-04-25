using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericQueue
{
    /// <summary>
    /// Describes queue of generic type elements 
    /// </summary>
    /// <typeparam name="T">generic type</typeparam>
    public class Queue<T> : IEnumerable<T>
    {
        private LinkedList<T> _queue;

        public Queue()
        {
            _queue = new LinkedList<T>(); 
        }

        public T Top
        {
            get
            {
                if (Size == 0)
                {
                    throw new InvalidOperationException("Queue is empty");
                }

                return _queue.First.Value;
            }
        }

        public int Size => _queue.Count;
        
        public void Enqueue(T data)
        {
            _queue.AddLast(data);
        }

        public T Dequeue()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T result = _queue.First.Value;
            _queue.RemoveFirst();

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator<T>(_queue);            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
