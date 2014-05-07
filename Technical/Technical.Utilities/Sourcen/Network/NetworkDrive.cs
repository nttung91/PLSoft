using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Technical.Utilities.Network
{
    /// <summary>
    /// Network Drive Interface
    /// </summary>
    public class NetworkDrive
    {
        #region API

        [DllImport("mpr.dll")]
        private static extern int WNetAddConnection2A(ref structNetResource pstNetRes, string psPassword,
            string psUsername, int piFlags);

        [DllImport("mpr.dll")]
        private static extern int WNetCancelConnection2A(string psName, int piFlags, int pfForce);

        [DllImport("mpr.dll")]
        private static extern int WNetConnectionDialog(int phWnd, int piType);

        [DllImport("mpr.dll")]
        private static extern int WNetDisconnectDialog(int phWnd, int piType);

        [DllImport("mpr.dll")]
        private static extern int WNetRestoreConnectionW(int phWnd, string psLocalDrive);

        [StructLayout(LayoutKind.Sequential)]
        private struct structNetResource
        {
            public int iScope;
            public int iType;
            public int iDisplayType;
            public int iUsage;
            public string sLocalName;
            public string sRemoteName;
            public string sComment;
            public string sProvider;
        }

        private const int RESOURCETYPE_DISK = 0x1;

        //Standard	
        //private const int CONNECT_INTERACTIVE = 0x00000008;
        //private const int CONNECT_PROMPT = 0x00000010;
        private const int CONNECT_UPDATE_PROFILE = 0x00000001;
        //IE4+
        //private const int CONNECT_REDIRECT = 0x00000080;
        //NT5 only
        //private const int CONNECT_COMMANDLINE = 0x00000800;
        //private const int CONNECT_CMD_SAVECRED = 0x00001000;

        #endregion

        #region Propertys and options

        /// <summary>
        /// Option to reconnect drive after log off / reboot ...
        /// </summary>
        public bool Persistent { get; set; }

        /// <summary>
        /// Option to force connection if drive is already mapped...
        /// or force disconnection if network path is not responding...
        /// </summary>
        public bool Force { get; set; }

        private string _localDrive;

        /// <summary>
        /// Drive to be used in mapping / unmapping...
        /// </summary>
        public string LocalDrive
        {
            get { return (_localDrive); }
            set
            {
                if (value.Length >= 1)
                {
                    _localDrive = value.Substring(0, 1) + ":";
                }
                else
                {
                    _localDrive = null;
                }
            }
        }

        /// <summary>
        /// Share address to map drive to.
        /// </summary>
        public string ShareName { get; set; }

        #endregion

        #region Function mapping

        /// <summary>
        /// Map network drive
        /// </summary>
        public bool MapDrive()
        {
            return MapDrive(null, null);
        }

        /// <summary>
        /// Map network drive (using supplied Password)
        /// </summary>
        public bool MapDrive(string password)
        {
            return MapDrive(null, password);
        }

        /// <summary>
        /// Map network drive (using supplied Username and Password)
        /// </summary>
        public bool MapDrive(string username, string password)
        {
            Debug.Assert(!string.IsNullOrEmpty(ShareName), "ShareName ist null");
            //create struct data
            var stNetRes = new structNetResource
            {
                iScope = 2,
                iType = RESOURCETYPE_DISK,
                iDisplayType = 3,
                iUsage = 1,
                sRemoteName = ShareName
            };
            if (!string.IsNullOrEmpty(_localDrive))
            {
                stNetRes.sLocalName = _localDrive;
            }
            //prepare params
            int iFlags = 0;
            //if (lf_SaveCredentials) { iFlags += CONNECT_CMD_SAVECRED; }
            if (Persistent)
            {
                iFlags += CONNECT_UPDATE_PROFILE;
            }
            //if (ls_PromptForCredentials) { iFlags += CONNECT_INTERACTIVE + CONNECT_PROMPT; }
            if (username == "")
            {
                username = null;
            }
            if (password == "")
            {
                password = null;
            }
            //if force, unmap ready for new connection
            if (Force)
            {
                try
                {
                    UnMapDrive();
                }
                catch
                {
                }
            }
            //call and return
            int i = WNetAddConnection2A(ref stNetRes, password, username, iFlags);
            return (i == 0);
        }

        /// <summary>
        /// Unmap network drive
        /// </summary>
        public bool UnMapDrive()
        {
            //call unmap and return
            int iFlags = 0;
            if (Persistent)
            {
                iFlags += CONNECT_UPDATE_PROFILE;
            }
            int i = WNetCancelConnection2A(_localDrive, iFlags, Convert.ToInt32(Force));
            if (i != 0)
                i = WNetCancelConnection2A(ShareName, iFlags, Convert.ToInt32(Force));
                    //disconnect if localname was null
            return (i == 0);
        }

        /// <summary>
        /// Check / restore persistent network drive
        /// </summary>
        public bool RestoreDrives()
        {
            int i = WNetRestoreConnectionW(0, null);
            return (i == 0);
        }

        #endregion
    }
}