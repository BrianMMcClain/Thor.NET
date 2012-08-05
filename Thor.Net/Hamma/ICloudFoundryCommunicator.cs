using System;

namespace Thor.Net.Hamma
{
    public interface ICloudFoundryCommunicator
    {
        bool SetTarget(Uri cloudUri);
    }
}