namespace Technical.Utilities.Threading
{
    public interface IWorkerThread
    {
        void Abort();
        void Start(bool sendCompletedEvent);
        void Stop(bool destroyWorker);
        Worker Worker { get; set; }
    }
}