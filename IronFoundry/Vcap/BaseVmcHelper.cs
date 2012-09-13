namespace IronFoundry.Vcap
{
    using System;
    using System.Collections.Generic;
    using Types;
    using Newtonsoft.Json;
    using RestSharp;

    internal abstract class BaseVmcHelper
    {
        protected readonly VcapCredentialManager credentialManager;
        protected readonly VcapUser proxyUser;

        public BaseVmcHelper(VcapUser proxyUser, VcapCredentialManager credentialManager)
        {
            this.proxyUser = proxyUser;
            this.credentialManager = credentialManager;
        }

        public string GetApplicationJson(string name)
        {
            var request = BuildVcapRequest(Constants.AppsPath, name);
            return request.Execute().Content;
        }

        public Application GetApplication(string name)
        {
            var json = GetApplicationJson(name);
            return JsonConvert.DeserializeObject<Application>(json);
        }

        public IEnumerable<Application> GetApplications(string proxy_user = null)
        {
            var request = BuildVcapRequest(Constants.AppsPath);
            return request.Execute<Application[]>();
        }

        protected bool AppExists(string name)
        {
            var returnValue = true;
            try
            {
                var appJson = GetApplicationJson(name);
            }
            catch (VcapNotFoundException)
            {
                returnValue = false;
            }
            return returnValue;
        }

        protected VcapRequest BuildVcapRequest(params object[] resourceParams)
        {
            return new VcapRequest(ProxyUserEmail, credentialManager, resourceParams);
        }

        protected VcapRequest BuildVcapRequest(bool useAuth, Uri uri, params object[] resourceParams)
        {
            return new VcapRequest(ProxyUserEmail, credentialManager, useAuth, uri, resourceParams);
        }

        protected VcapRequest BuildVcapRequest(Method method, params string[] resourceParams)
        {
            return new VcapRequest(ProxyUserEmail, credentialManager, method, resourceParams);
        }

        protected VcapJsonRequest BuildVcapJsonRequest(Method method, params string[] resourceParams)
        {
            return new VcapJsonRequest(ProxyUserEmail, credentialManager, method, resourceParams);
        }

        private string ProxyUserEmail
        {
            get
            {
                string proxyUserEmail = null;
                if (null != proxyUser)
                {
                    proxyUserEmail = proxyUser.Email;
                }
                return proxyUserEmail;
            }
        }
    }
}