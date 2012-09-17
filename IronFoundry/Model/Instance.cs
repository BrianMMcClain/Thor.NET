using System;
using System.Collections.Generic;

namespace IronFoundry.Model
{ 
    [Serializable]
    public class Instance : EntityBase, IMergeable<Instance>
    {
        private int _id;
        private string _state;
        private int _cores;
        private long _memoryQuota;
        private long _diskQuota;
        private string _host;
        private float _cpu;
        private long _memory;
        private long _disk;
        private TimeSpan _uptime;
        private Application _parent;

        public int Id {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("ID"); }
        }
        public string State
        {
            get { return _state; }
            set { _state = value; RaisePropertyChanged("State"); }
        }
        public int Cores
        {
            get { return _cores; }
            set { _cores = value; RaisePropertyChanged("Cores"); }
        }
        public long MemoryQuota
        {
            get { return _memoryQuota; }
            set { _memoryQuota = value; RaisePropertyChanged("MemoryQuota"); }
        }
        public long DiskQuota
        {
            get { return _diskQuota; }
            set { _diskQuota = value; RaisePropertyChanged("DiskQuota"); }
        }
        public string Host
        {
            get { return _host; }
            set { _host = value; RaisePropertyChanged("Host"); }
        }
        public float Cpu
        {
            get { return _cpu; }
            set { _cpu = value; RaisePropertyChanged("Cpu"); }
        }
        public long Memory
        {
            get { return _memory; }
            set { _memory = value; RaisePropertyChanged("Memory"); }
        }
        public long Disk
        {
            get { return _disk; }
            set { _disk = value; RaisePropertyChanged("Disk"); }
        }
        public TimeSpan Uptime
        {
            get { return _uptime; }
            set { _uptime = value; RaisePropertyChanged("Uptime"); }
        }
        public Application Parent
        {
            get { return _parent; }
            set { _parent = value; RaisePropertyChanged("Parent"); }
        }

        public void Merge(Instance obj)
        {
            Cores = obj.Cores;
            MemoryQuota = obj.MemoryQuota;
            DiskQuota = obj.DiskQuota;
            Host = obj.Host;
            Cpu = obj.Cpu;
            Memory = obj.Memory;
            Disk = obj.Disk;
            Uptime = obj.Uptime;
            State = obj.State;
        }
    }

    public class InstanceEqualityComparer : IEqualityComparer<Instance>
    {
        public bool Equals(Instance instanceOne, Instance instanceTwo)
        {
            return instanceOne.Id.Equals(instanceTwo.Id);
        }

        public int GetHashCode(Instance instance)
        {
            return instance.Id.GetHashCode();
        }
    }
}
