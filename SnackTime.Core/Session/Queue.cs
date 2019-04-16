using System.Collections.Generic;

namespace SnackTime.Core.Session
{
    public class Queue<T>
    {
        private readonly object   _lock;
        private readonly IList<T> _queue;

        public Queue()
        {
            _lock = new object();
            _queue = new List<T>();
        }

        public void AddToQueue(T request)
        {
            lock (_lock)
            {
                _queue.Add(request);
            }
        }

        public bool HasItems()
        {
            lock (_lock)
            {
                return _queue.Count > 0;
            }
        }

        public T Pop()
        {
            lock (_lock)
            {
                var item = _queue[0];
                _queue.RemoveAt(0);
                return item;
            }
        }
    }
}