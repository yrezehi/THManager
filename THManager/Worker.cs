using THManager.Events;

namespace THManager
{
    public class Worker
    {
        private int Id { get; set; }

        private readonly string Description;
        private readonly DateTime CreationTime;

        private Thread Job { get; }

        public event EventHandler<OnFinishArguments> OnFinish;
        public event EventHandler<OnErrorArguments> OnError;
        public event EventHandler<OnStartArguments> OnStart;

        public Worker(string description, ParameterizedThreadStart jobAction, bool triggerImmediately = false)
        {
            CreationTime = DateTime.Now;
            Description = description;

            Job = new Thread(jobAction);
            Job.IsBackground = false;
            Id = Job.ManagedThreadId;

            if (triggerImmediately)
            {
                StartJob();
            }
        }

        public void Trigger()
        {
            if (Job.ThreadState == ThreadState.Unstarted)
            {
                StartJob();
            }
        }

        private void StartJob()
        {
            if(OnStart is not null)
                OnStart(this, new OnStartArguments());

            Job.Start();
        }
    }
}
