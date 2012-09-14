using System;
using System.Collections.ObjectModel;

namespace IronFoundry.Model
{
    [Serializable, Obsolete]
    public class Preferences
    {             
        private SafeObservableCollection<Cloud> _clouds;
        private SafeObservableCollection<CloudUrl> _cloudUrls;

        public SafeObservableCollection<Cloud> Clouds 
        {
            get { return this._clouds; }
            set
            {
                this._clouds = value.DeepCopy();
                foreach (var cloud in this._clouds)
                {
                    cloud.Services.Clear();
                    cloud.Applications.Clear();
                    cloud.AvailableServices.Clear();
                    cloud.IsConnected = false;
                    cloud.IsDisconnected = true;
                }
            }
        }

        public SafeObservableCollection<CloudUrl> CloudUrls
        {
            get { return _cloudUrls; }
            set
            {
                _cloudUrls = value.DeepCopy();
            }
        }
    }
}