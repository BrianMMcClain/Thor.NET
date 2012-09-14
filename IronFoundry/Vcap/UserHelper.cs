using IronFoundry.Model;

namespace IronFoundry.Vcap
{
    using System.Collections.Generic;
    using Properties;
    using Newtonsoft.Json.Linq;
    using RestSharp;

    internal class UserHelper : BaseVmcHelper
    {
        public UserHelper(VcapUser proxyUser, VcapCredentialManager credentialManager)
            : base(proxyUser, credentialManager) { }

        public void Login(string email, string password)
        {
            var jsonRequest = BuildVcapJsonRequest(Method.POST, Constants.UsersPath, email, "tokens");
            jsonRequest.AddBody(new { password });

            try
            {
                var response = jsonRequest.Execute();
                var parsed = JObject.Parse(response.Content);
                var token = parsed.Value<string>("token");
                credentialManager.RegisterToken(token);
            }
            catch (VcapAuthException)
            {
                throw new VcapAuthException(string.Format(Resources.Vmc_LoginFail_Fmt, credentialManager.CurrentTarget));
            }
        }

        public void ChangePassword(string user, string newPassword)
        {
            var request = BuildVcapRequest(Constants.UsersPath, user);
            var response = request.Execute();

            var parsed = JObject.Parse(response.Content);
            parsed["password"] = newPassword;

            var put = BuildVcapJsonRequest(Method.PUT, Constants.UsersPath, user);
            put.AddBody(parsed);
            put.Execute();
        }

        public void AddUser(string email, string password)
        {
            var jsonRequest = BuildVcapJsonRequest(Method.POST, Constants.UsersPath);
            jsonRequest.AddBody(new { email, password });
            jsonRequest.Execute();
        }

        public void DeleteUser(string email)
        {
            // TODO: doing this causes a "not logged in" failure when the user
            // doesn't exist, which is kind of misleading.

            var appsHelper = new AppsHelper(proxyUser, credentialManager);
            foreach (Application a in appsHelper.GetApplications(email))
            {
                appsHelper.Delete(a.Name);
            }

            var servicesHelper = new ServicesHelper(proxyUser, credentialManager);
            foreach (var ps in servicesHelper.GetProvisionedServices())
            {
                servicesHelper.DeleteService(ps.Name);
            }

            var jsonRequest = BuildVcapJsonRequest(Method.DELETE, Constants.UsersPath, email);
            jsonRequest.Execute();
        }

        public VcapUser GetUser(string email)
        {
            var jsonRequest = BuildVcapJsonRequest(Method.GET, Constants.UsersPath, email);
            return jsonRequest.Execute<VcapUser>();
        }

        public IEnumerable<VcapUser> GetUsers()
        {
            var jsonRequest = BuildVcapJsonRequest(Method.GET, Constants.UsersPath);
            return jsonRequest.Execute<VcapUser[]>();
        }
    }
}