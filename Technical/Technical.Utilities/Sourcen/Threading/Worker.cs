using System.Threading;

namespace Technical.Utilities.Threading
{
    /// <summary>
    /// Skeleton for a worker thread. Another thread would typically set up
    /// an instance with some work to do, and invoke the Run method (eg with
    /// new Thread(new ThreadStart(job.Run)).Start())
    /// </summary>
    public abstract class Worker
    {
        /// <summary>
        /// Delegate and event for external messages
        /// </summary>
        public delegate void WorkHandler(string msg);

        public static event WorkHandler WorkEvent;

        public delegate void WorkCompletedHandler();

        public static event WorkCompletedHandler WorkCompletedEvent;

        /// <summary>
        /// Lock covering stopping and stopped
        /// </summary>
        private readonly object _stopLock = new object();

        /// <summary>
        /// Whether or not the worker thread has been asked to stop
        /// </summary>
        private bool _stopping = false;

        /// <summary>
        /// Whether or not the worker thread has stopped
        /// </summary>
        private bool _stopped = false;

        /// <summary>
        /// Whether or not the worker thread has completed the work
        /// </summary>
        private bool _completed = false;

        /// <summary>
        /// Returns whether the worker thread has been asked to stop.
        /// This continues to return true even after the thread has stopped.
        /// </summary>
        public bool Stopping
        {
            get
            {
                lock (_stopLock)
                {
                    return _stopping;
                }
            }
        }

        /// <summary>
        /// Returns whether the worker thread has stopped.
        /// </summary>
        public bool Stopped
        {
            get
            {
                lock (_stopLock)
                {
                    return _stopped;
                }
            }
        }

        /// <summary>
        /// Returns whether the worker thread has completed the work.
        /// </summary>
        public bool Completed
        {
            get
            {
                lock (_stopLock)
                {
                    return _completed;
                }
            }
        }

        /// <summary>
        /// Tells the worker thread to stop, typically after completing its 
        /// current work item. (The thread is *not* guaranteed to have stopped
        /// by the time this method returns.)
        /// </summary>
        protected void Complete()
        {
            lock (_stopLock)
            {
                _completed = true;
                _stopping = true;
                if (WorkCompletedEvent != null) WorkCompletedEvent();
            }
        }

        /// <summary>
        /// Tells the worker thread to stop, typically after completing its 
        /// current work item. (The thread is *not* guaranteed to have stopped
        /// by the time this method returns.)
        /// </summary>
        public void Stop()
        {
            lock (_stopLock)
            {
                _stopping = true;
            }
        }

        /// <summary>
        /// Called by the worker thread to indicate when it has stopped.
        /// </summary>
        private void SetStopped()
        {
            lock (_stopLock)
            {
                _stopped = true;
            }
        }

        /// <summary>
        /// Main work loop of the class.
        /// </summary>
        public void Start()
        {
            try
            {
                while (!Stopping)
                {
                    DoWork();
                }
            }
            finally
            {
                SetStopped();
            }
        }

        protected virtual void DoWork()
        {
            // Insert work here. Make sure it doesn't tight loop!
            // (If work is arriving periodically, use a queue and Monitor.Wait,
            // changing the Stop method to pulse the monitor as well as setting
            // stopping.)

            // Note that you may also wish to break out *within* the loop
            // if work items can take a very long time but have points at which
            // it makes sense to check whether or not you've been asked to stop.
            // Do this with just:
            // if (Stopping)
            // {
            //     return;
            // }
            // The finally block will make sure that the stopped flag is set.

            if (WorkEvent != null) WorkEvent("Do some work here!");
            Thread.Sleep(1000);
        }
    }
}