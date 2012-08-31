using System;
using System.Collections.Generic;

namespace Thor.Net.Asgard.Bridges
{
    public interface IRainbowBridge
    {
        T GetFoundryItem<T>(Guid id);
        List<T> GetFoundryItems<T>(Guid id);
        bool PutFoundryItem<T>(T target);
        bool DeleteFoundryItem<T>(T target);
    }
}