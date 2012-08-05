using System;

namespace Thor.Net.Hamma
{
    public class CloudFoundryCommunicator : ICloudFoundryCommunicator
    {
        public bool SetTarget(Uri cloudUri)
        {
            throw new NotImplementedException();
        }
    }

    public class CloudFoundry
    {
        private readonly ICloudFoundryCommunicator _cloudFoundryCommunicator;

        public CloudFoundry(ICloudFoundryCommunicator cloudFoundryCommunicator)
        {
            _cloudFoundryCommunicator = cloudFoundryCommunicator;
        }

        public bool SetTarget(Uri cloudUri)
        {
            return _cloudFoundryCommunicator.SetTarget(cloudUri);
        }

    }
}