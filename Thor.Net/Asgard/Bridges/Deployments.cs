using System;
using System.Collections.Generic;

namespace Thor.Net.Asgard.Bridges
{
    public class Deployments : BridgeBase
    {
        public T GetFoundryItem<T>(Guid id)
        {
            throw new NotImplementedException();
        }

        public override List<T> GetFoundryItems<T>(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool PutFoundryItem<T>(T target)
        {
            throw new NotImplementedException();
        }

        public bool DeleteFoundryItem<T>(T target)
        {
            throw new NotImplementedException();
        }
    }
}