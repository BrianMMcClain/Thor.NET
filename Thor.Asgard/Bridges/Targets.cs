using System;
using System.Collections.Generic;
using System.Linq;
using Thor.Models.Jörð;

namespace Thor.Asgard.Bridges
{
    public class Targets
    {
        private readonly ICuzSettingsIsSealedWrapper _wrapper;
     
        public Targets(ICuzSettingsIsSealedWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        public List<FoundryTarget> GetTargets()
        {
            try
            {
                return _wrapper.Get().Targets;
            }
            catch (Exception)
            {
                // Log Message.
                throw;
            }
        }

        public bool ValidateTargetNameExists(string name)
        {
            var names = GetTargetNames();
            return names.Count > 0 && names.Contains(name);
        }

        public bool ValidateTargetUriExists(Uri uri)
        {
            var uris = GetTargetUris();
            return uris.Count > 0 && uris.Contains(uri);
        }

        private List<string> GetTargetNames()
        {
            return GetTargets().Select(foundryTarget => foundryTarget.Name).ToList();
        }

        private List<Uri> GetTargetUris()
        {
            return GetTargets().Select(foundryTarget => foundryTarget.Path).ToList();
        }

        public bool DeleteTarget(FoundryTarget target)
        {
            try
            {
                var foundry = _wrapper.Get();
                foundry.Targets.Remove(target);
                _wrapper.Save(foundry);
                return true;
            }
            catch (Exception ex)
            {
                // Log Message.

                return false;
            }
        }

        public bool PutTarget(FoundryTarget target)
        {
            try
            {
                var foundry = _wrapper.Get();
                foundry.Targets.Add(target);
                _wrapper.Save(foundry);
                return true;
            }
            catch (Exception ex)
            {
                // Log Message.

                return false;
            }
        }
    }
}