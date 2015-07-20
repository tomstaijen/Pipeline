using System;
using System.Diagnostics;

namespace WebDeploy
{
    public class PublishSettings
    {
        private string _publishUrl = "";
        private RemoteAgent _agentType = RemoteAgent.None;
        private bool? _ntlm = null;
        private bool _allowUntrusted;

        private string _computerName = "";
        private int _port;
        private string _siteName = "";

        private string _username = "";
        private string _password = "";

        private TraceLevel _traceLevel;
        private bool _delete;
        private bool _whatIf;

        private FilePath _sourcePath;
        private FilePath _destinationPath;

        #region Constructor (1)
        public PublishSettings()
        {
            _publishUrl = "";
            _agentType = RemoteAgent.None;
            _ntlm = null;
            _allowUntrusted = true;

            _computerName = "localhost";
            _port = DeployUtils.DefaultPort;
            _siteName = "";

            _username = "";
            _password = "";

            _traceLevel = TraceLevel.Info;
            _delete = true;
            _whatIf = false;

            _sourcePath = null;
            _destinationPath = null;
        }
        #endregion


        #region Properties (10)
        /// <summary>
        /// Gets or sets the url to publish that package to
        /// </summary>
        public string PublishUrl
        {
            get
            {
                if (!String.IsNullOrEmpty(_publishUrl))
                {
                    return _publishUrl;
                }
                else
                {
                    if ((_agentType == RemoteAgent.WMSvc) || (_agentType == RemoteAgent.None))
                    {
                        return DeployUtils.GetWmsvcUrl(_computerName, _port, _siteName);
                    }
                    else
                    {
                        return _computerName;
                    }
                }
            }
            set
            {
                _publishUrl = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of remote agent to connect to
        /// </summary>
        public RemoteAgent AgentType
        {
            get
            {
                return _agentType;
            }
            set
            {
                _agentType = value;
            }
        }

        /// <summary>
        /// Gets or sets if NTLM authentication should be used
        /// </summary>
        public bool NTLM
        {
            get
            {

                if (!_ntlm.HasValue)
                {
                    if ((_agentType == RemoteAgent.WMSvc) || (_agentType == RemoteAgent.None))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

                return _ntlm.Value;
            }
            set
            {
                _ntlm = value;
            }
        }

        /// <summary>
        /// Gets or sets if untrusted certificates should be allowed
        /// </summary>
        public bool AllowUntrusted
        {
            get
            {
                return _allowUntrusted;
            }
            set
            {
                _allowUntrusted = value;
            }
        }


        /// <summary>
        /// Gets or sets the computer name to publish to
        /// </summary>
        public string ComputerName
        {
            get
            {
                return _computerName;
            }
            set
            {
                _computerName = value;
            }
        }

        /// <summary>
        /// Sets the remote port to connect on
        /// </summary>
        public int Port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
            }
        }

        /// <summary>
        /// Sets the name of the website to publish
        /// </summary>
        public string SiteName
        {
            get
            {
                return _siteName;
            }
            set
            {
                _siteName = value;
            }
        }


        /// <summary>
        /// Gets or sets the credentials to use when connecting
        /// </summary>
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }

        /// <summary>
        /// Gets or sets the credentials to use when connecting
        /// </summary>
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }


        /// <summary>
        /// Gets or sets the logging trace level
        /// </summary>
        public TraceLevel TraceLevel
        {
            get
            {
                return _traceLevel;
            }
            set
            {
                _traceLevel = value;
            }
        }

        /// <summary>
        /// Gets or sets if files that no longer exist should be deleted
        /// </summary>
        public bool Delete
        {
            get
            {
                return _delete;
            }
            set
            {
                _delete = value;
            }
        }

        /// <summary>
        /// Gets or sets if operations will not be executed but events will still be fired
        /// </summary>
        public bool WhatIf
        {
            get
            {
                return _whatIf;
            }
            set
            {
                _whatIf = value;
            }
        }



        /// <summary>
        /// Gets or sets the source of the package to publish
        /// </summary>
        public FilePath SourcePath
        {
            get
            {
                return _sourcePath;
            }
            set
            {
                _sourcePath = value;
            }
        }

        /// <summary>
        /// Gets or sets the destination of the package to publish to
        /// </summary>
        public FilePath DestinationPath
        {
            get
            {
                return _destinationPath;
            }
            set
            {
                _destinationPath = value;
            }
        }
        #endregion
    }
}