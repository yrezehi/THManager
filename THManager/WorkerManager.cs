using System.Collections.Concurrent;
using THManager.Events;

namespace THManager
{
    public static class WorkerManager
    {
        private static ConcurrentQueue<Worker> workers = new();

        public static void Spawn(string description, Action action)
        {
            Worker worker = new(description, action);
            
            workers.Enqueue(worker);

            worker.Trigger();
        }

        public static void Append(Worker worker)
        {
            workers.Enqueue(worker);

            worker.Trigger();
        }

        public static void Append(Worker worker, EventHandler<OnStartArguments> onStartArguments, EventHandler<OnErrorArguments> onErrorArguments, EventHandler<OnFinishArguments> onFinishArguments)
        {
            workers.Enqueue(worker);

            worker.OnStart += onStartArguments;
            worker.OnError += onErrorArguments;
            worker.OnFinish += onFinishArguments;

            worker.Trigger();
        }

        public static void Spawn(string description, Action action, EventHandler<OnStartArguments> onStartArguments, EventHandler<OnErrorArguments> onErrorArguments, EventHandler<OnFinishArguments> onFinishArguments)
        {
            Worker worker = new(description, action);

            worker.OnStart += onStartArguments;
            worker.OnError += onErrorArguments;
            worker.OnFinish += onFinishArguments;

            workers.Enqueue(worker);

            worker.Trigger();
        }

        public static string GetReport() =>
            string.Join("\n", workers.AsEnumerable().Select(worker => worker.ToString()).ToList());
    }
}
