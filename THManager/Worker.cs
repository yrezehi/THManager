using THManager.Events;

namespace THManager
{
    public class Worker
    {
        private int Id { get; set; }

        private readonly string Description;
        private readonly DateTime CreationTime;

        private Thread JobThread { get; }

        public event EventHandler<OnFinishArguments> OnFinish;
        public event EventHandler<OnErrorArguments> OnError;
        public event EventHandler<OnStartArguments> OnStart;

        public Worker(string description, ParameterizedThreadStart jobAction, bool triggerImmediately = false)
        {
            CreationTime = DateTime.Now;
            Description = description;

            JobThread = new Thread(jobAction);
            Id = JobThread.ManagedThreadId;

            if (triggerImmediately)
            {
                JobThread.Start();
            }
        }

        public void Trigger()
        {
            if (JobThread.ThreadState == ThreadState.Unstarted)
            {
                JobThread.Start();
            }
        }
    }
}
