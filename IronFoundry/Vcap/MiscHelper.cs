namespace IronFoundry.Vcap
{
    using System;
    using IronFoundry.Types;

    internal class MiscHelper : BaseVmcHelper
    {
        public MiscHelper(VcapUser proxyUser, VcapCredentialManager credMgr)
            : base(proxyUser, credMgr) { }

        public Info GetInfo()
        {
            VcapRequest r = BuildVcapRequest(Constants.INFO_PATH);
            return r.Execute<Info>();
        }

        internal VcapRequest BuildInfoRequest()
        {
            return BuildVcapRequest(Constants.INFO_PATH);
        }

        public void Target(Uri uri)
        {
            // "target" does the same thing as "info", but not logged in
            // considered valid if name, build, version and support are all non-null
            VcapRequest request = BuildVcapRequest(false, uri, Constants.INFO_PATH);
            Info info = request.Execute<Info>();

            var success = info != null &&
                          !string.IsNullOrWhiteSpace(info.Name) &&
                          !string.IsNullOrWhiteSpace(info.Build) &&
                          !string.IsNullOrWhiteSpace(info.Version) &&
                          !string.IsNullOrWhiteSpace(info.Support);

            if (success)
            {
                credMgr.SetTarget(uri);
                credMgr.StoreTarget();
            }
            else
            {
                throw new VcapTargetException(request.ErrorMessage);
            }
        }
    }
}