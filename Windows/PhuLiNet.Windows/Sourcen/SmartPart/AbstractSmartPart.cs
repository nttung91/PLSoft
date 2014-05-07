using System;

namespace Windows.Core.SmartPart
{
    /// <summary>
    /// Abstract smart part base class
    /// </summary>
    public abstract class AbstractSmartPart : ISmartPart
    {
        protected string _key;
        protected bool _visible;
        protected bool _readOnly;
        protected string _displayName;
        protected string _description;
        protected object _control;
        protected bool _initDone = false;

        protected AbstractSmartPart(object control)
        {
            _control = control;
        }

        #region ISmartPart Members

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public bool ReadOnly
        {
            get { return _readOnly; }
            set { _readOnly = value; }
        }

        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public object Control
        {
            get { return _control; }
        }

        public bool InitDone
        {
            get { return _initDone; }
        }

        public virtual void Init()
        {
            throw new NotImplementedException();
        }

        public virtual void Deinit()
        {
            throw new NotImplementedException();
        }

        public virtual void Destroy()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}