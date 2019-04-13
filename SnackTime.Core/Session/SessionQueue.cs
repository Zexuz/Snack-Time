using System.Collections.Generic;

namespace SnackTime.Core.Session
{
    public class SessionQueue
    {
        private readonly object      _lock;
        private readonly IList<Item> _queue;

        public SessionQueue()
        {
            _lock = new object();
            _queue = new List<Item>();
        }

        public void AddToQueue(Item request)
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

        public Item Pop()
        {
            lock (_lock)
            {
                var item = _queue[0];
                _queue.RemoveAt(0);
                return item;
            }
        }

        public class Item
        {
            public string MediaId { get; set; }
            public string Path { get; set; }
        }
    }
}