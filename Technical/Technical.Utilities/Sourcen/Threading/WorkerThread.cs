using System;
using System.Diagnostics;
using System.Threading;
using ThreadState = System.Threading.ThreadState;

namespace Technical.Utilities.Threading
{
    /// <summary>
    /// A thread with a worker inside
    /// </summary>
    public class WorkerThread : IWorkerThread, IWorkerThreadDescription
    {
        public delegate void WorkCompletedHandler();

        public static event WorkCompletedHandler WorkCompletedEvent;

        private Worker _worker;
        private Thread _thread;

        private string _workerId;
        private string _workerName;
        private string _workerDescription;
        private DateTime? _workerStarted;
        private DateTime? _workerStopped;

        public Worker Worker
        {
            get { return _worker; }
            set
            {
                if (_thread != null)
                {
                    Debug.Assert(_thread.ThreadState != ThreadState.Running, "Worker changed while thread is running!");
                }
                Debug.Assert(_worker == null, "Clear work first!");

                _worker = value;
            }
        }

        public WorkerThread()
        {
        }

        public WorkerThread(string id, string name, string description)
        {
            _workerId = id;
            _workerName = name;
            _workerDescription = description;
        }

        private void CreateThread()
        {
            Debug.Assert(_worker != null, "Worker is null!");

            _thread = new Thread(new ThreadStart(_worker.Start));
        }

        public void Start(bool sendCompletedEvent)
        {
            Debug.Assert(_worker != null, "Worker is null!");

            if (_thread != null)
                Debug.Assert(_thread.ThreadState != ThreadState.Running, "Current Thread is running!");

            if (_thread == null)
                CreateThread();

            if (sendCompletedEvent)
                Worker.WorkCompletedEvent += new Worker.WorkCompletedHandler(Worker_WorkCompletedHandler);

            _thread.Start();
            _workerStarted = DateTime.Now;
        }

        private void Worker_WorkCompletedHandler()
        {
            if (WorkCompletedEvent != null) WorkCompletedEvent();
        }

        public void Stop(bool destroyWorker)
        {
            if (_worker != null)
            {
                _worker.Stop();
            }

            //disable delegates before executing thread stop
            Worker.WorkCompletedEvent -= new Worker.WorkCompletedHandler(Worker_WorkCompletedHandler);

            if (_thread != null)
            {
                //waiting for worker
                if (_worker != null)
                {
                    while (!_worker.Stopped)
                    {
                        Thread.Sleep(500);
                    }
                }

                //worker stopped, abort thread
                if (destroyWorker)
                    _worker = null;

                if (!_thread.Join(1000))
                {
                    //abort thread
                    _thread.Abort();
                }
                _workerStopped = DateTime.Now;
            }
        }

        public void Abort()
        {
            Stop(true);
            _thread = null;
        }

        public string WorkerId
        {
            get { return _workerId; }
        }

        public string WorkerName
        {
            get { return _workerName; }
        }

        public string WorkerDescription
        {
            get { return _workerDescription; }
        }

        public DateTime? WorkerStarted
        {
            get { return _workerStarted; }
        }

        public DateTime? WorkerStopped
        {
            get { return _workerStopped; }
        }

        public bool WorkerFinished
        {
            get
            {
                bool finished = false;

                if (_worker != null && _worker.Completed)
                    finished = true;

                return finished;
            }
        }
    }
}