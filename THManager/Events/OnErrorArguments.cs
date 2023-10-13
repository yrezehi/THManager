namespace THManager.Events
{
    public class OnErrorArguments : EventArgs
    {
        public DateTime ErrorTime { get; set; } = DateTime.Now;
    }
}
