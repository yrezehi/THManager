using System.Collections.Concurrent;

namespace THManager
{
    public static class WorkerManager
    {
        private static ConcurrentQueue<Worker> workers = new();

        public static void Spawn(string description, Action action)
        {
            Worker worker = new(description, action);

            worker.Trigger();

            workers.Enqueue(worker);
        }

        public static string GetReport() =>
            string.Join("\n", workers.AsEnumerable().Select(worker => worker.ToString()).ToList());
    }
}
