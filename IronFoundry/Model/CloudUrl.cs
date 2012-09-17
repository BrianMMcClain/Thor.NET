using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IronFoundry.Model
{
    [Serializable, Obsolete]
    public class CloudUrl : EntityBase, IMergeable<CloudUrl>
    {
        private string _serverName;
        private string _url;
        private bool _isConfigurable;
        private bool _isRemovable;
        private bool _isDefault;
        private bool _isMicroCloud;
        
        private static SafeObservableCollection<CloudUrl> defaultCloudUrls = new SafeObservableCollection<CloudUrl>
        {
            new CloudUrl { ServerName = "Iron Foundry", Url = "http://api.ironfoundry.me", IsDefault = true, IsConfigurable = false },
            new CloudUrl { ServerName = "Local cloud", Url = "http://api.vcap.me", IsConfigurable = false},
            new CloudUrl { ServerName = "Microcloud", Url = "http://api.{mycloud}.cloudfoundry.me", IsConfigurable = true, IsMicroCloud = true },
            new CloudUrl { ServerName = "VMWare Cloud Foundry", Url = "https://api.cloudfoundry.com", IsConfigurable = false, IsDefault = false },
        };

        public string ServerName
        {
            get { return _serverName; }
            set { _serverName = value; RaisePropertyChanged("ServerName"); }
        }

        public string Url
        {
            get { return _url; }
            set { _url = value; RaisePropertyChanged("Url"); }
        }

        public bool IsConfigurable
        {
            get { return _isConfigurable; }
            set { _isConfigurable = value; RaisePropertyChanged("IsConfigurable"); }
        }

        public bool IsRemovable
        {
            get { return _isRemovable; }
            set { _isRemovable = value; RaisePropertyChanged("IsRemovable"); }
        }

        public bool IsDefault
        {
            get { return _isDefault; }
            set { _isDefault = value; RaisePropertyChanged("IsDefault"); }
        }

        public bool IsMicroCloud
        {
            get { return _isMicroCloud; }
            set { _isMicroCloud = value; RaisePropertyChanged("IsMicroCloud"); }
        }

        public static SafeObservableCollection<CloudUrl> DefaultCloudUrls
        {
            get { return defaultCloudUrls; }
        }
    
        public void Merge(CloudUrl obj)
        {
            Url            = obj.Url;
            IsConfigurable = obj.IsConfigurable;
            IsRemovable    = obj.IsRemovable;
            IsDefault      = obj.IsDefault;
            IsMicroCloud   = obj.IsMicroCloud;
        }
    }

    public class CloudUrlEqualityComparer : IEqualityComparer<CloudUrl>
    {
        public bool Equals(CloudUrl c1, CloudUrl c2)
        {
            return c1.ServerName.Equals(c2.ServerName);
        }

        public int GetHashCode(CloudUrl c)
        {
            return c.ServerName.GetHashCode();
        }
    }
}