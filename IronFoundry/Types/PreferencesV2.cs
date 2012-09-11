namespace IronFoundry.Types
{
    using System;

    [Serializable]
    public class PreferencesV2
    {             
        private Cloud[] clouds;

        public Cloud[] Clouds 
        {
            get { return this.clouds; }
            set
            {
                this.clouds = value.DeepCopy();
                foreach (Cloud cloud in this.clouds)
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