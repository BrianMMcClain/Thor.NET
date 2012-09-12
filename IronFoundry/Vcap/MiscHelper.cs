namespace IronFoundry.Vcap
{
    using System;
    using Types;

    internal class MiscHelper : BaseVmcHelper
    {
        public MiscHelper(VcapUser proxyUser, VcapCredentialManager credentialManager)
            : base(proxyUser, credentialManager) { }

        public Info GetInfo()
        {
            var request = BuildVcapRequest(Constants.InfoPath);
            return request.Execute<Info>();
        }

        internal VcapRequest BuildInfoRequest()
        {
            return BuildVcapRequest(Constants.InfoPath);
        }

        public void Target(Uri uri)
        {
            // "target" does the same thing as "info", but not logged in
            // considered valid if name, build, version and support are all non-null
            var request = BuildVcapRequest(false, uri, Constants.InfoPath);
            var info = request.Execute<Info>();

            var success = info != null &&
                          !string.IsNullOrWhiteSpace(info.Name) &&
                          !string.IsNullOrWhiteSpace(info.Build) &&
                          !string.IsNullOrWhiteSpace(info.Version) &&
                          !string.IsNullOrWhiteSpace(info.Support);

            if (success)
            {
                credentialManager.SetTarget(uri);
                credentialManager.StoreTarget();
            }
            else
            {
                throw new VcapTargetException(request.ErrorMessage);
            }
        }
    }
}