using System;
using Newtonsoft.Json;

namespace IronFoundry.Model
{
    [Serializable]
    public class AppResources : EntityBase
    {
        private int memory;
        private int disk;
        private int fds;

        [JsonProperty(PropertyName = "memory")]
        public int Memory
        {
            get { return memory; }
            set { memory = value; RaisePropertyChanged("Memory"); }
        }

        [JsonProperty(PropertyName = "disk")]
        public int Disk
        {
            get { return disk; }
            set { disk = value; RaisePropertyChanged("Disk"); }
        }

        [JsonProperty(PropertyName = "fds")]
        public int Fds
        {
            get { return fds; }
            set { fds = value; RaisePropertyChanged("Fds"); }
        }
    }
}