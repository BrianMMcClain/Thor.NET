using System;
using System.Collections.Generic;
using System.Linq;
using Thor.Models.Jord;

namespace Thor.Asgard.Bridges
{
    public class TargetsBridge
    {
        private readonly ICuzSettingsIsSealedWrapper _wrapper;
     
        public TargetsBridge(ICuzSettingsIsSealedWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        public List<FoundryTarget> GetTargets()
        {
            return _wrapper.Get().Targets;
        }

        public FoundryTarget GetTarget(string targetName)
        {
            var targets = _wrapper.Get().Targets;
            var target = targets.Find(x => x.Name == targetName);
            return target;
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
                var verifiedTargetToDelete = foundry.Targets.Single(x => x.Name == target.Name);
                foundry.Targets.Remove(verifiedTargetToDelete);
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