using System;
using System.Collections.Generic;

namespace Thor.Net.Asgard.Bridges
{
    public class Targets : BridgeBase
    {
        public override List<T> GetFoundryItems<T>()
        {
            return base.GetFoundryItems<T>();
        }
    }
}