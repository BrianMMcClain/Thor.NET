namespace IronFoundry.Types
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows;

    [Serializable]
    public class Cloud : EntityBase, IEquatable<Cloud>, IMergeable<Cloud>
    {
        private readonly Guid _id;
        private string _serverName;
        private string _hostName;
        private string _email;
        private string _password;
        private string _url;
        private bool _isConnected;
        private bool _isDisconnected;
        private int _timeoutStart;
        private int _timeoutStop;
        private string _accessToken;

        private SafeObservableCollection<Application> _applications = new SafeObservableCollection<Application>();

        private SafeObservableCollection<SystemService> _availableServices =
            new SafeObservableCollection<SystemService>();

        private SafeObservableCollection<ProvisionedService> _services =
            new SafeObservableCollection<ProvisionedService>();

        public Cloud() : this(Guid.NewGuid())
        {
        }

        public Cloud(Guid id)
        {
            _applications.CollectionChanged += (s, e) => RaisePropertyChanged("Applications");
            _services.CollectionChanged += (s, e) => RaisePropertyChanged("Services");
            _availableServices.CollectionChanged += (s, e) => RaisePropertyChanged("AvailableServices");

            TimeoutStart = 600;
            TimeoutStop = 60;
            IsConnected = false;
            IsDisconnected = true;
        }

        public bool IsDataComplete
        {
            get
            {
                return
                    false == string.IsNullOrWhiteSpace(ServerName) &&
                    false == string.IsNullOrWhiteSpace(Url) &&
                    false == string.IsNullOrWhiteSpace(Email) &&
                    false == string.IsNullOrWhiteSpace(Password);
            }
        }

        public Guid ID
        {
            get { return _id; }
        }

        public string ServerName
        {
            get { return _serverName; }
            set
            {
                _serverName = value;
                RaisePropertyChanged("ServerName");
            }
        }

        public string HostName
        {
            get { return _hostName; }
            set
            {
                _hostName = value;
                RaisePropertyChanged("HostName");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisePropertyChanged("Email");
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged("Password");
            }
        }

        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                RaisePropertyChanged("Url");
            }
        }

        public int TimeoutStart
        {
            get { return _timeoutStart; }
            set
            {
                _timeoutStart = value;
                RaisePropertyChanged("TimeoutStart");
            }
        }

        public int TimeoutStop
        {
            get { return _timeoutStop; }
            set
            {
                _timeoutStop = value;
                RaisePropertyChanged("TimeoutStop");
            }
        }

        public string AccessToken
        {
            get { return _accessToken; }
            set
            {
                _accessToken = value;
                RaisePropertyChanged("AccessToken");
                if (!String.IsNullOrEmpty(_accessToken))
                {
                    IsConnected = true;
                    IsDisconnected = false;
                }
                else
                {
                    IsDisconnected = true;
                    IsConnected = false;
                }
            }
        }

        public bool IsConnected
        {
            get { return _isConnected; }
            set
            {
                _isConnected = value;
                RaisePropertyChanged("IsConnected");
            }
        }

        public bool IsDisconnected
        {
            get { return _isDisconnected; }
            set
            {
                _isDisconnected = value;
                RaisePropertyChanged("IsDisconnected");
            }
        }

        public SafeObservableCollection<Application> Applications
        {
            get
            {
                if (_applications == null)
                {
                    _applications = new SafeObservableCollection<Application>();
                }
                return _applications;
            }
        }

        public SafeObservableCollection<ProvisionedService> Services
        {
            get
            {
                if (_services == null)
                {
                    _services = new SafeObservableCollection<ProvisionedService>();
                }
                return _services;
            }
        }

        public SafeObservableCollection<SystemService> AvailableServices
        {
            get
            {
                if (_availableServices == null)
                {
                    _availableServices = new SafeObservableCollection<SystemService>();
                }
                return _availableServices;
            }
        }

        public void Merge(Cloud c)
        {
            ServerName = c.ServerName;
            HostName = c.HostName;
            Email = c.Email;
            Password = c.Password;
            TimeoutStart = c.TimeoutStart;
            TimeoutStop = c.TimeoutStop;
            AccessToken = c.AccessToken;
            IsConnected = c.IsConnected;
            IsDisconnected = c.IsDisconnected;

            Applications.Synchronize(c.Applications, new ApplicationEqualityComparer());
            Services.Synchronize(c.Services, new ProvisionedServiceEqualityComparer());
            AvailableServices.Synchronize(c.AvailableServices, new SystemServiceEqualityComparer());
        }

        public string BuildTypicalApplicationUrl(string applicationName)
        {
            string rv = String.Empty;

            if (false == string.IsNullOrWhiteSpace(Url))
            {
                var tmp = new Uri(Url);
                string host = tmp.GetComponents(UriComponents.Host, UriFormat.SafeUnescaped);
                if (host.Contains("api."))
                {
                    string scheme = tmp.GetComponents(UriComponents.Scheme, UriFormat.SafeUnescaped);
                    rv = scheme + "://" + host.Replace("api", applicationName);
                }
            }

            return rv;
        }

        public bool Equals(Cloud other)
        {
            if (null == other)
                return false;

            return GetHashCode() == other.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (null == obj)
                return false;

            if (DependencyProperty.UnsetValue == obj)
                return false;

            return Equals(obj as Cloud);
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}