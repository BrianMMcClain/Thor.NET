using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace IronFoundry.Model
{
    [Serializable]
    public class Application : EntityBase, IMergeable<Application> 
    {
        private static class VcapStates
        {
            public const string Starting      = "STARTING";
            public const string Stopped       = "STOPPED";
            public const string Running       = "RUNNING";
            public const string Started       = "STARTED";
        }

        private string _name;
        private Staging _staging;
        private string _version;
        private int _instances;
        private int? _runningInstances;
        private AppResources _resources;
        private string _state;
        private readonly SafeObservableCollection<string> _uris = new SafeObservableCollection<string>();
        private readonly SafeObservableCollection<string> _services = new SafeObservableCollection<string>();        
        private readonly SafeObservableCollection<string> _environment = new SafeObservableCollection<string>();
        private readonly SafeObservableCollection<Instance> _instanceCollection = new SafeObservableCollection<Instance>();

        public Application()
        {
            _uris.CollectionChanged += (s,e) => RaisePropertyChanged("Uris");
            _services.CollectionChanged += (s,e) => RaisePropertyChanged("Services");
            _environment.CollectionChanged += (s,e) => RaisePropertyChanged("Environment");
            _instanceCollection.CollectionChanged += (s,e) => RaisePropertyChanged("InstanceCollection");

            Staging = new Staging();
            Resources = new AppResources();
        }

        [JsonProperty(PropertyName = "name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged("Name"); }
        }

        [JsonProperty(PropertyName = "staging")]
        public Staging Staging
        {
            get { return _staging; }
            set { _staging = value; RaisePropertyChanged("Staging"); }
        }

        [JsonProperty(PropertyName = "uris")]
        public SafeObservableCollection<string> Uris
        {
            get { return _uris; }
        }

        [JsonProperty(PropertyName = "instances")]
        public int Instances
        {
            get { return _instances; }
            set { _instances = value; RaisePropertyChanged("Instances"); }
        }

        [JsonProperty(PropertyName = "runningInstances")]
        public int? RunningInstances
        {
            get { return _runningInstances; }
            set { _runningInstances = value; RaisePropertyChanged("RunningInstances"); }
        }

        [JsonProperty(PropertyName = "resources")]
        public AppResources Resources
        {
            get { return _resources; }
            set { _resources = value; RaisePropertyChanged("Resources"); }
        }

        [JsonProperty(PropertyName = "state")]
        public string State
        {
            get { return _state; }
            set { _state = value; RaisePropertyChanged("State"); }
        }

        [JsonProperty(PropertyName = "services")]
        public SafeObservableCollection<string> Services 
        {
            get { return _services; }
        }

        [JsonProperty(PropertyName = "version")]
        public string Version
        {
            get { return _version; }
            set { _version = value; RaisePropertyChanged("Version"); }
        }

        [JsonProperty(PropertyName = "env")]
        public SafeObservableCollection<string> Environment
        {
            get { return _environment; }
        }

        [JsonIgnore]
        public SafeObservableCollection<Instance> InstanceCollection
        {
            get { return _instanceCollection; }
        }
        
        [JsonIgnore]
        public Cloud Parent { get; set; }

        [JsonIgnore]
        public VcapUser User { get; set; }

        [JsonIgnore]
        public bool IsStarted
        {
            get { return State == VcapStates.Started; }
        }

        [JsonIgnore]
        public bool IsStopped
        {
            get { return State == VcapStates.Stopped; }
        }

        [JsonIgnore]
        public bool CanStart
        {
            get
            {
                return ! (State == VcapStates.Running || State == VcapStates.Started || State == VcapStates.Starting);
            }
        }

        [JsonIgnore]
        public bool CanStop
        {
            get
            {
                return State == VcapStates.Running || State == VcapStates.Started || State == VcapStates.Starting;
            }
        }

        public void Merge(Application obj)
        {
            Staging          = obj.Staging;
            Resources        = obj.Resources;
            Version          = obj.Version;
            Instances        = obj.Instances;
            RunningInstances = obj.RunningInstances;
            State            = obj.State;
            Uris.Synchronize(obj.Uris,StringComparer.InvariantCulture);
            InstanceCollection.Synchronize(obj.InstanceCollection,new InstanceEqualityComparer());
        }

        public void Start()
        {
            State = VcapStates.Started;
        }

        public void Stop()
        {
            State = VcapStates.Stopped;
        }
    }
}
