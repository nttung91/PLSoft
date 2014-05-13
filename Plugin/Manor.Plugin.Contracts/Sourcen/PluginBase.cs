using System;
using System.Drawing;
using Manor.Plugin.Contracts;
using Technical.Utilities.Extensions;

namespace PhuLiNet.Plugin.Contracts
{
    public abstract class PluginBase : IPlugin
    {
        private int _artId;
        private string _id;
        private string _shortcut;
        private string _description;
        private Image _image;
        private bool _visible;
        private string[] _previousShortcuts;

        protected PluginBase()
        {
            _visible = false;
        }

        #region IPlugin Members

        public int ArtId
        {
            get { return _artId; }
            set { _artId = value; }
        }

        public string Id
        {
            get
            {
                if (_id == null)
                    _id = GetType().Name;

                return _id;
            }
            protected set { _id = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Shortcut
        {
            get { return _shortcut; }
            set { _shortcut = value; }
        }

        /// <summary>
        /// Shortcuts of previous program e.g. Form-Ids of previous oracle form modules
        /// </summary>
        public string[] PreviousShortcuts
        {
            get { return _previousShortcuts; }
            set { _previousShortcuts = value; }
        }

        public Version Version { get; set; }

        public Image Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public virtual bool IsValid
        {
            get { return (Id != null && _description != null && _shortcut != null && HasValidId && HasValidShortcut); }
        }

        public bool IsVisible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public bool HasValidId
        {
            get
            {
                if (string.IsNullOrEmpty(Id)) return false;
                if (!Id.StartsWith("Plugin")) return false;
                return true;
            }
        }

        public bool IsExternal { get; protected set; }

        public virtual bool HasValidShortcut
        {
            get
            {
                if (string.IsNullOrEmpty(_shortcut)) return false;
                if (_shortcut.HasWhitespace()) return false;
                if (!_shortcut.IsUpper()) return false;
                if (_shortcut.Length > 20) return false;
                return true;
            }
        }

        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }

        public bool IsActiveByDate
        {
            get
            {
                return (ValidFrom == null || DateTime.Today >= ValidFrom.Value.Date) && (ValidTo == null || DateTime.Today <= ValidTo.Value.Date);
            }
        }

        public virtual string GetProgramType()
        {
            return "PLUGIN";
        }

        public virtual void Configure()
        {
        }

        public virtual void Start(IStartParameter parameter)
        {
            throw new NotImplementedException();
        }

        #endregion

        public override string ToString()
        {
            return "Id: " + Id + ", Name: " + Description;
        }
    }
}