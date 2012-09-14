using System;

namespace IronFoundry.Model
{
    [Serializable]
    public class PreferencesV2
    {             
        private Cloud[] _clouds;

        public Cloud[] Clouds 
        {
            get { return this._clouds; }
            set
            {
                this._clouds = value.DeepCopy();
                foreach (Cloud cloud in this._clouds)
                {
                    cloud.Services.Clear();
                    cloud.Applications.Clear();
                    cloud.AvailableServices.Clear();
                    cloud.IsConnected = false;
                    cloud.IsDisconnected = true;
                }
            }
        }
    }
}