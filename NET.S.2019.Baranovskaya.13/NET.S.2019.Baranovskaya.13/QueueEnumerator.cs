using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenericQueue
{
    /// <summary>
    /// Consists of IEnumerator methods
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueueEnumerator<T> : IEnumerator<T>
    {
        private LinkedList<T> queue;
        private LinkedListNode<T> current;

        public QueueEnumerator(LinkedList<T> queue)
        {
            this.queue = queue;
        }

        public T Current
        {
            get
            {
                if (current == null)
                {
                    throw new Exception();
                }

                return current.Value;
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (queue == null)
            {
                return false;
            }
            else
            {
                current = current == null ? queue.First : current.Next;
            }

            if (current != null)
            {
                return true;
            }

            queue = null;
            return false;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
