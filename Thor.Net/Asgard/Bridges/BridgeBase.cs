using System;
using System.Collections.Generic;
using System.Configuration;

namespace Thor.Net.Asgard.Bridges
{
    public class BridgeBase : IRainbowBridge
    {
        public virtual T GetFoundryItem<T>(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual List<T> GetFoundryItems<T>()
        {
            throw new NotImplementedException();
        }

        public virtual List<T> GetFoundryItems<T>(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual bool PutFoundryItem<T>(T target)
        {
            throw new NotImplementedException();
        }

        public virtual bool DeleteFoundryItem<T>(T target)
        {
            throw new NotImplementedException();
        }

        public bool RunLocal()
        {
            return !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["local"]) &&
                   Convert.ToBoolean(ConfigurationManager.AppSettings["local"]);
        }
    }
}