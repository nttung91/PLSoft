using System;

namespace Technical.Utilities.Threading
{
    public interface IWorkerThreadDescription
    {
        string WorkerId { get; }
        string WorkerName { get; }
        string WorkerDescription { get; }
        DateTime? WorkerStarted { get; }
        DateTime? WorkerStopped { get; }
        bool WorkerFinished { get; }
    }
}