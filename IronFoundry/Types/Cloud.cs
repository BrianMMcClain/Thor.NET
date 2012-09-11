namespace IronFoundry.Types
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows;

    [Serializable]
    public class Cloud : EntityBase, IEquatable<Cloud>, IMergeable<Cloud>
    {
        private readonly Guid id;
        private string serverName;
        private string hostName;
        private string email;
        private string password;
        private string url;
        private bool isConnected;
        private bool isDisconnected;
        private int timeoutStart;
        private int timeoutStop;
        private string accessToken;

        private SafeObservableCollection<Application> applications = new SafeObservableCollection<Application>();

        private SafeObservableCollection<SystemService> availableServices =
            new SafeObservableCollection<SystemService>();

        private SafeObservableCollection<ProvisionedService> services =
            new SafeObservableCollection<ProvisionedService>();

        public Cloud() : this(Guid.NewGuid())
        {
        }

        public Cloud(Guid id)
        {
            applications.CollectionChanged += (s, e) => RaisePropertyChanged("Applications");
            services.CollectionChanged += (s, e) => RaisePropertyChanged("Services");
            availableServices.CollectionChanged += (s, e) => RaisePropertyChanged("AvailableServices");

            id = id;
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
            get { return id; }
        }

        public string ServerName
        {
            get { return serverName; }
            set
            {
                serverName = value;
                RaisePropertyChanged("ServerName");
            }
        }

        public string HostName
        {
            get { return hostName; }
            set
            {
                hostName = value;
                RaisePropertyChanged("HostName");
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                RaisePropertyChanged("Email");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged("Password");
            }
        }

        public string Url
        {
            get { return url; }
            set
            {
                url = value;
                RaisePropertyChanged("Url");
            }
        }

        public int TimeoutStart
        {
            get { return timeoutStart; }
            set
            {
                timeoutStart = value;
                RaisePropertyChanged("TimeoutStart");
            }
        }

        public int TimeoutStop
        {
            get { return timeoutStop; }
            set
            {
                timeoutStop = value;
                RaisePropertyChanged("TimeoutStop");
            }
        }

        public string AccessToken
        {
            get { return accessToken; }
            set
            {
                accessToken = value;
                RaisePropertyChanged("AccessToken");
                if (!String.IsNullOrEmpty(accessToken))
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
            get { return isConnected; }
            set
            {
                isConnected = value;
                RaisePropertyChanged("IsConnected");
            }
        }

        public bool IsDisconnected
        {
            get { return isDisconnected; }
            set
            {
                isDisconnected = value;
                RaisePropertyChanged("IsDisconnected");
            }
        }

        public SafeObservableCollection<Application> Applications
        {
            get
            {
                if (applications == null)
                {
                    applications = new SafeObservableCollection<Application>();
                }
                return applications;
            }
        }

        public SafeObservableCollection<ProvisionedService> Services
        {
            get
            {
                if (services == null)
                {
                    services = new SafeObservableCollection<ProvisionedService>();
                }
                return services;
            }
        }

        public SafeObservableCollection<SystemService> AvailableServices
        {
            get
            {
                if (availableServices == null)
                {
                    availableServices = new SafeObservableCollection<SystemService>();
                }
                return availableServices;
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