using System;
using System.Collections.Generic;
using Thor.Models.Jord;

namespace Thor.Asgard.Bridges
{
    public class ApplicationsBridge
    {
        private readonly ICuzSettingsIsSealedWrapper _wrapper;

        public ApplicationsBridge(ICuzSettingsIsSealedWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        public List<FoundryApplication> GetApplications()
        {
            return _wrapper.Get().Applications;
        }

        public FoundryApplication GetApplication(Uri applicationUri)
        {
            var applications = _wrapper.Get().Applications;
            return applications.Find(x => x.Path == applicationUri);
        }


    }
}