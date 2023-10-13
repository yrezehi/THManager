using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THManager
{
    public class WorkerManager
    {

        private ConcurrentQueue<Worker> workers = new();

        public void Add(string description, Action action) =>
            workers.Enqueue(new(description, action));
    }
}
