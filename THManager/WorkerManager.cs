using System.Collections.Concurrent;

namespace THManager
{
    public class WorkerManager
    {
        private ConcurrentQueue<Worker> workers = new();

        public void Spawn(string description, Action action) =>
            workers.Enqueue(new(description, action));

        public IEnumerable<string?> GetReport() =>
            workers.AsEnumerable().Select(worker => worker.ToString());
    }
}
