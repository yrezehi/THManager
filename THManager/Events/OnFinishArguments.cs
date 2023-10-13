namespace THManager.Events
{
    public class OnFinishArguments : EventArgs
    {
        public DateTime FinishTime { get; set; } = DateTime.Now;
    }
}
