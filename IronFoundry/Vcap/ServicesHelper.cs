using IronFoundry.Model;

namespace IronFoundry.Vcap
{
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using RestSharp;

    internal class ServicesHelper : BaseVmcHelper
    {
        public ServicesHelper(VcapUser proxyUser, VcapCredentialManager credentialManager)
            : base(proxyUser, credentialManager) { }

        public IEnumerable<SystemService> GetSystemServices()
        {
            var request = BuildVcapRequest(Constants.GlobalServicesPath);
            var response = request.Execute();
            var list = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, SystemService>>>>(response.Content);

            var dataStores = from val in list.Values
                             from val1 in val.Values
                             from val2 in val1.Values
                             select val2;
            
            return dataStores.ToList();
        }

        public IEnumerable<ProvisionedService> GetProvisionedServices()
        {            
            var request = BuildVcapRequest(Constants.ServicesPath);
            return request.Execute<ProvisionedService[]>();
        }

        public void CreateService(string serviceName, string provisionedServiceName)
        {
            var services = GetSystemServices();
            var service = services.FirstOrDefault(s => s.Vendor == serviceName);
            if (service != null)
            {
                // from vmc client.rb
                var data = new
                {
                    name    = provisionedServiceName,
                    type    = service.Type,
                    tier    = "free",
                    vendor  = service.Vendor,
                    version = service.Version,
                };
                var jsonRequest = BuildVcapJsonRequest(Method.POST, Constants.ServicesPath);
                jsonRequest.AddBody(data);
                jsonRequest.Execute();
            }
        }

        public void DeleteService(string provisionedServiceName)
        {
            var request = BuildVcapJsonRequest(Method.DELETE, Constants.ServicesPath, provisionedServiceName);
            request.Execute();
        }

        public void BindService(string provisionedServiceName, string appName)
        {
            var apps = new AppsHelper(proxyUser, credentialManager);

            var app = apps.GetApplication(appName);
            app.Services.Add(provisionedServiceName);

            var request = BuildVcapJsonRequest(Method.PUT, Constants.AppsPath, app.Name);
            request.AddBody(app);
            request.Execute();

            // Ruby code re-gets info
            app = apps.GetApplication(appName);
            if (app.IsStarted)
            {
                apps.Restart(app);
            }
        }

        public void UnbindService(string provisionedServiceName, string appName)
        {
            var apps = new AppsHelper(proxyUser, credentialManager);
            string appJson = apps.GetApplicationJson(appName);
            var appParsed = JObject.Parse(appJson);
            var services = (JArray)appParsed["services"];
            appParsed["services"] = new JArray(services.Where(s => ((string)s) != provisionedServiceName));

            var jsonRequest = BuildVcapJsonRequest(Method.PUT, Constants.AppsPath, appName);
            jsonRequest.AddBody(appParsed);
            jsonRequest.Execute();

            apps = new AppsHelper(proxyUser, credentialManager);
            apps.Restart(appName);
        }
    }
}
