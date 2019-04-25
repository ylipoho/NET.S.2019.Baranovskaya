using NUnit.Framework;
using GenericQueue;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Queue<int> queue = new Queue<int>();
            
            Assert.That(queue.Size == 0);

            queue.Enqueue(3);

            Assert.That(queue.Size == 1);

            queue.Enqueue(7);
            queue.Enqueue(9);

            Assert.That(queue.Dequeue() == 3);

            Assert.That(queue.Top == 7);

            queue.Enqueue(-1);

            Assert.That(queue.Top == 7);

            int sum = 0;

            foreach (int num in queue)
            {
                sum += num;
            }

            Assert.That(sum == 15);
        }
    }
}