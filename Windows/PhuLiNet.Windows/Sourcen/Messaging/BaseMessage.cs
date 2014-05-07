namespace Windows.Core.Messaging
{
    public abstract class BaseMessage : IMessage
    {
        protected string _id;
        protected string _name;
        protected bool _active;

        protected BaseMessage(string id, string name)
        {
            _id = id;
            _name = name;
            _active = true;
        }

        #region IMessage Members

        public string Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
        }

        public bool Active
        {
            get { return _active; }
            internal set { _active = value; }
        }

        #endregion
    }
}