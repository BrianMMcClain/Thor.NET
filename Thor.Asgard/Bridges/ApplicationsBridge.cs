using System;
using System.Collections.Generic;
using System.Linq;
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

        public void PutApplication(FoundryApplication foundryApplication)
        {
            var foundry = _wrapper.Get();

            var foundryApplicationToReplace =
                foundry.Applications.SingleOrDefault(foundryTarget => foundryTarget.Path == foundryApplication.Path);

            foundry.Applications.Remove(foundryApplicationToReplace);

            foundry.Applications.Add(foundryApplication);
            _wrapper.Save(foundry);
        }
    }
}