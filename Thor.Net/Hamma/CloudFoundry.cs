using System;

namespace Thor.Net.Hamma
{
    public class CloudFoundry
    {
        private readonly ICloudFoundryCommunicator _mockedCommunicator;

        public CloudFoundry(ICloudFoundryCommunicator mockedCommunicator)
        {
            _mockedCommunicator = mockedCommunicator;
        }

        public bool SetTarget(Uri goodCloudUri)
        {
            return false;
        }
    }

    public interface ICloudFoundryCommunicator
    {
        bool SetTarget(Uri goodCloudUri);
    }
}
