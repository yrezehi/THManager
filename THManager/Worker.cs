using THManager.Events;
using THManager.Extensions;

namespace THManager
{
    public class Worker
    {
        private int Id { get; set; }

        private readonly string Description;
        private readonly DateTime CreationTime;

        private Thread Thread { get; set; }
        private ThreadStart Job { get; set; }
        private Action Action { get; set; }

        public event EventHandler<OnFinishArguments> OnFinish;
        public event EventHandler<OnErrorArguments> OnError;
        public event EventHandler<OnStartArguments> OnStart;

        public Worker(string description, Action action)
        {
            CreationTime = DateTime.Now;
            Description = description ?? "";
            Action = action ?? throw new ArgumentNullException($"{nameof(Action)} must be provided!");
        }

        public void Trigger()
        {

            Job = new ThreadStart(() => { 
                Action();
                if(OnFinish is not null)
                    OnFinish(this, new OnFinishArguments());
            });

            Thread = new Thread(Job);
            Thread.IsBackground = false;
            Id = Thread.ManagedThreadId;

            if (Thread.ThreadState == ThreadState.Unstarted)
            {
                if (OnStart is not null)
                    OnStart(this, new OnStartArguments());
                Thread.Start();
            }
        }

        public override string ToString() =>
            $"{Id}: Status-{Thread.ThreadState.AsString()}";
    }
}
