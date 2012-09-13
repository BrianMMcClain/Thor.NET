namespace IronFoundry.Vcap
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;
    using Types;

    public class VcapClient : IVcapClient
    {
        private VcapCredentialManager _credentialManager;
        private readonly Cloud _cloud;
        private static readonly Regex FileRegex;
        private static readonly Regex DirectoryRegex;
        private VcapUser _proxyUser;

        static VcapClient()
        {
            var invalidFileNameChars = Path.GetInvalidFileNameChars();
            var validFileNameRegexStr = String.Format(@"^([^{0}]+)\s+([0-9]+(?:\.[0-9]+)?[KBMG])$", new String(invalidFileNameChars));
            FileRegex = new Regex(validFileNameRegexStr, RegexOptions.Compiled);

            var invalidPathChars = Path.GetInvalidPathChars();
            var validPathRegexStr = String.Format(@"^([^{0}]+)/\s+-$", new String(invalidPathChars));
            DirectoryRegex = new Regex(validPathRegexStr, RegexOptions.Compiled);
        }

        public VcapClient()
        {
            _credentialManager = new VcapCredentialManager();
        }

        public VcapClient(string uri)
        {
            Target(uri);
        }

        public VcapClient(Cloud cloud)
        {
            Target(cloud.Url);
            _cloud = cloud;
        }

        public VcapClient(Uri uri, IPAddress ipAddress)
        {
            _credentialManager = new VcapCredentialManager(uri, ipAddress);
        }

        public void ProxyAs(VcapUser user)
        {
            _proxyUser = user;
        }

        public string CurrentUri
        {
            get { return _credentialManager.CurrentTarget.AbsoluteUriTrimmed(); }
        }

        public string CurrentToken
        {
            get { return _credentialManager.CurrentToken; }
        }

        public Info GetInfo()
        {
            var helper = new MiscHelper(_proxyUser, _credentialManager);
            return helper.GetInfo();
        }

        internal VcapRequest GetRequestForTesting()
        {
            var helper = new MiscHelper(_proxyUser, _credentialManager);
            return helper.BuildInfoRequest();
        }

        public void Target(string uri)
        {
            Target(uri, null);
        }

        public void Target(string uri, IPAddress ipAddress)
        {
            if (string.IsNullOrWhiteSpace(uri))
            {
                throw new ArgumentException("uri");
            }

            Uri validatedUri;
            if (!Uri.TryCreate(uri, UriKind.Absolute, out validatedUri))
            {
                validatedUri = new Uri("http://" + uri);
            }

            _credentialManager = ipAddress == null ? new VcapCredentialManager(validatedUri) : new VcapCredentialManager(validatedUri, ipAddress);
        }

        public string CurrentTarget
        {
            get { return _credentialManager.CurrentTarget.AbsoluteUriTrimmed(); }
        }

        public void Login()
        {
            Login(_cloud.Email, _cloud.Password);
        }

        public void Login(string email, string password)
        {
            var helper = new UserHelper(_proxyUser, _credentialManager);
            helper.Login(email, password);
        }

        public void ChangePassword(string newPassword)
        {
            var helper = new UserHelper(_proxyUser, _credentialManager);
            var info = GetInfo();
            helper.ChangePassword(info.User, newPassword);
        }

        public void AddUser(string email, string password)
        {
            var helper = new UserHelper(_proxyUser, _credentialManager);
            helper.AddUser(email, password);
        }

        public void DeleteUser(string email)
        {
            var helper = new UserHelper(_proxyUser, _credentialManager);
            helper.DeleteUser(email);
        }

        public VcapUser GetUser(string email)
        {
            var helper = new UserHelper(_proxyUser, _credentialManager);
            return helper.GetUser(email);
        }

        public IEnumerable<VcapUser> GetUsers()
        {
            var helper = new UserHelper(_proxyUser, _credentialManager);
            return helper.GetUsers();
        }

        public void Push(string name, string deployFQDN, ushort instances,
            DirectoryInfo path, uint memoryMb, string[] provisionedServiceNames)
        {
            var helper = new AppsHelper(_proxyUser, _credentialManager);
            helper.Push(name, deployFQDN, instances, path, memoryMb, provisionedServiceNames);
        }

        public void Update(string name, DirectoryInfo path)
        {
            var helper = new AppsHelper(_proxyUser, _credentialManager);
            helper.Update(name, path);
        }

        public void BindService(string provisionedServiceName, string appName)
        {
            var services = new ServicesHelper(_proxyUser, _credentialManager);
            services.BindService(provisionedServiceName, appName);
        }

        public void UnbindService(string provisionedServiceName, string appName)
        {
            var services = new ServicesHelper(_proxyUser, _credentialManager);
            services.UnbindService(provisionedServiceName, appName);
        }

        public void CreateService(string serviceName, string provisionedServiceName)
        {
            var services = new ServicesHelper(_proxyUser, _credentialManager);
            services.CreateService(serviceName, provisionedServiceName);
        }

        public void DeleteService(string provisionedServiceName)
        {
            var services = new ServicesHelper(_proxyUser, _credentialManager);
            services.DeleteService(provisionedServiceName);
        }

        public IEnumerable<SystemService> GetSystemServices()
        {
            var services = new ServicesHelper(_proxyUser, _credentialManager);
            return services.GetSystemServices();
        }

        public IEnumerable<ProvisionedService> GetProvisionedServices()
        {
            var services = new ServicesHelper(_proxyUser, _credentialManager);
            return services.GetProvisionedServices();
        }

        public void Start(string appName)
        {
            var helper = new AppsHelper(_proxyUser, _credentialManager);
            helper.Start(appName);
        }

        public void Start(Application app)
        {
            var helper = new AppsHelper(_proxyUser, _credentialManager);
            helper.Start(app);
        }

        public void Stop(string appName)
        {
            var helper = new AppsHelper(_proxyUser, _credentialManager);
            helper.Stop(appName);
        }

        public void Stop(Application app)
        {
            var helper = new AppsHelper(_proxyUser, _credentialManager);
            helper.Stop(app);
        }

        public void Restart(string appName)
        {
            var helper = new AppsHelper(_proxyUser, _credentialManager);
            helper.Restart(appName);
        }

        public void Restart(Application application)
        {
            var helper = new AppsHelper(_proxyUser, _credentialManager);
            helper.Restart(application);
        }

        public void Delete(string appName)
        {
            var helper = new AppsHelper(_proxyUser, _credentialManager);
            helper.Delete(appName);
        }

        public void Delete(Application application)
        {
            var helper = new AppsHelper(_proxyUser, _credentialManager);
            helper.Delete(application);
        }

        public Application GetApplication(string name)
        {
            var helper = new AppsHelper(_proxyUser, _credentialManager);
            var rv =  helper.GetApplication(name);
            rv.Parent = _cloud; // TODO not thrilled about this
            return rv;
        }

        public IEnumerable<Application> GetApplications()
        {
            var helper = new AppsHelper(_proxyUser, _credentialManager);
            var apps = helper.GetApplications();
            foreach (var app in apps) // TODO not thrilled about this
            {
                app.Parent = _cloud;
                app.User = _proxyUser;
            } 
            return apps;
        }

        public byte[] FilesSimple(string appName, string path, ushort instance)
        {
            var helper = new AppsHelper(_proxyUser, _credentialManager);
            return helper.Files(appName, path, instance);
        }

        public VcapFilesResult Files(string appName, string path, ushort instance)
        {
            VcapFilesResult filesResult ;

            var helper = new AppsHelper(_proxyUser, _credentialManager);
            byte[] content = helper.Files(appName, path, instance);
            if (null == content)
            {
                filesResult = new VcapFilesResult(false);
            }
            else if (content.Length == 0)
            {
                filesResult = new VcapFilesResult(content);
            }
            else
            {
                var i = 0;
                for (i = 0; i < content.Length; ++i)
                {
                    if (content[i] == '\n')
                    {
                        break;
                    }
                }
                string firstLine = Encoding.ASCII.GetString(content, 0, i);
                if (FileRegex.IsMatch(firstLine) || DirectoryRegex.IsMatch(firstLine))
                {
                    // Probably looking at a listing, not a file
                    var contentAscii = Encoding.ASCII.GetString(content);
                    var contentAry = contentAscii.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    filesResult = new VcapFilesResult();
                    foreach (string item in contentAry)
                    {
                        var fileMatch = FileRegex.Match(item);
                        if (fileMatch.Success)
                        {
                            var fileName = fileMatch.Groups[1].Value; // NB: 0 is the entire matched string
                            var fileSize = fileMatch.Groups[2].Value;
                            filesResult.AddFile(fileName, fileSize);
                            continue;
                        }

                        var dirMatch = DirectoryRegex.Match(item);
                        if (dirMatch.Success)
                        {
                            var dirName = dirMatch.Groups[1].Value;
                            filesResult.AddDirectory(dirName);
                            continue;
                        }

                        throw new InvalidOperationException("Match failed.");
                    }
                }
                else
                {
                    filesResult = new VcapFilesResult(content);
                }
            }

            return filesResult;
        }

        public void UpdateApplication(Application app)
        {
            var helper = new AppsHelper(_proxyUser, _credentialManager);
            helper.UpdateApplication(app);
        }

        public string GetLogs(Application app, ushort instanceNumber)
        {
            var info = new InfoHelper(_proxyUser, _credentialManager);
            return info.GetLogs(app, instanceNumber);
        }

        public IEnumerable<StatInfo> GetStats(Application app)
        {
            var info = new InfoHelper(_proxyUser, _credentialManager);
            return info.GetStats(app);
        }

        public IEnumerable<ExternalInstance> GetInstances(Application app)
        {
            var info = new InfoHelper(_proxyUser, _credentialManager);
            return info.GetInstances(app);
        }

        public IEnumerable<Crash> GetAppCrash(Application app)
        {
            var helper = new AppsHelper(_proxyUser, _credentialManager);
            return helper.GetAppCrash(app);
        }
    }
}