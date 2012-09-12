namespace IronFoundry.Vcap
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using Types;
    using Newtonsoft.Json;

    /*
     * Access token file is a dictionary of 
     {
        "http://api.vcap.me": "04085b0849221a6c756b652e62616b6b656e4074696572332e636f6d063a0645546c2b078b728b4e2219000104ec0d65746833caddd87eac48b0b2989604"},
        "http://api.vcap.me": "04085b0849221a6c756b652e62616b6b656e4074696572332e636f6d063a0645546c2b078b728b4e2219000104ec0d65746833caddd87eac48b0b2989604"}
     }
     */
    public class VcapCredentialManager
    {
        private const string TokenFile = ".vmc_token";
        private const string TargetFile = ".vmc_target";

        private readonly string _tokenFile;
        private readonly string _targetFile;

        private bool shouldWrite = true;

        private readonly IDictionary<Uri, AccessToken> _tokenDict = new Dictionary<Uri, AccessToken>();

        private Uri _currentTarget;
        private IPAddress _currentTargetIp;

        private VcapCredentialManager(string json)
        {
            string userProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            _tokenFile = Path.Combine(userProfilePath, TokenFile);
            _targetFile = Path.Combine(userProfilePath, TargetFile);

            ParseJson(string.IsNullOrWhiteSpace(json) ? ReadTokenFile() : json);

            _currentTarget = ReadTargetFile();
        }

        public VcapCredentialManager() : this((string)null) { }

        public VcapCredentialManager(Uri currentTarget) : this((string)null)
        {
            if (null == currentTarget)
            {
                throw new ArgumentNullException("currentTarget");
            }
            SetTarget(currentTarget);
        }

        public VcapCredentialManager(Uri currentTarget, IPAddress currentTargetIp) : this((string)null)
        {
            if (null == currentTarget)
            {
                throw new ArgumentNullException("currentTarget");
            }
            if (null == currentTargetIp)
            {
                throw new ArgumentNullException("currentTargetIp");
            }
            SetTarget(currentTarget, currentTargetIp);
        }

        internal VcapCredentialManager(string tokenJson, bool shouldWrite) : this(tokenJson)
        {
            this.shouldWrite = shouldWrite;
        }

        public Uri CurrentTarget
        {
            get { return _currentTarget ?? Constants.DefaultLocalTarget; }
        }

        public IPAddress CurrentTargetIP
        {
            get { return _currentTargetIp; }
        }

        public string CurrentToken
        {
            get
            {
                string rv = null;
                var accessToken = GetFor(CurrentTarget);
                if (null != accessToken)
                {
                    rv = accessToken.Token;
                }
                return rv;
            }
        }

        public void SetTarget(string uri)
        {
            SetTarget(new Uri(uri));
        }

        public void SetTarget(Uri uri)
        {
            _currentTarget = uri;
            _currentTargetIp = null;
        }

        public void SetTarget(Uri uri, IPAddress ip)
        {
            if (null == uri)
            {
                throw new ArgumentNullException("uri");
            }
            if (null == ip)
            {
                throw new ArgumentNullException("ip");
            }
            _currentTarget = uri;
            _currentTargetIp = ip;
        }

        public void RegisterToken(string token)
        {
            var accessToken = new AccessToken(CurrentTarget, token);
            _tokenDict[accessToken.Uri] = accessToken;
            WriteTokenFile();
        }

        public bool HasToken
        {
            get { return false == string.IsNullOrWhiteSpace(CurrentToken); }
        }

        public void StoreTarget()
        {
            if (shouldWrite)
            {
                File.WriteAllText(_targetFile, CurrentTarget.AbsoluteUriTrimmed()); // NB: trim end!
            }
        }

        private AccessToken GetFor(Uri uri)
        {
            AccessToken rv;
            _tokenDict.TryGetValue(uri, out rv);
            return rv;
        }

        private void ParseJson(string tokenJson, bool shouldWrite = false)
        {
            if (false == string.IsNullOrWhiteSpace(tokenJson))
            {
                var allTokens = JsonConvert.DeserializeObject<Dictionary<string, string>>(tokenJson);
                foreach (var kvp in allTokens)
                {
                    var uriStr = kvp.Key;
                    var token = kvp.Value;
                    var accessToken = new AccessToken(uriStr, token);
                    _tokenDict[accessToken.Uri] = accessToken;
                }
                if (shouldWrite)
                {
                    WriteTokenFile();
                }
            }
        }

        [System.Diagnostics.DebuggerStepThrough]
        private string ReadTokenFile()
        {
            string rv = null;

            try
            {
                rv = File.ReadAllText(_tokenFile);
            }
            catch (FileNotFoundException) { }

            return rv;
        }

        private void WriteTokenFile()
        {
            if (shouldWrite)
            {
                // NB: ruby vmc writes target uris without trailing slash
                try
                {
                    Dictionary<string, string> tmp = _tokenDict.ToDictionary(e => e.Key.AbsoluteUriTrimmed(), e => e.Value.Token);
                    File.WriteAllText(_tokenFile, JsonConvert.SerializeObject(tmp));
                }
                catch (IOException)
                {
                }
            }
        }

        [System.Diagnostics.DebuggerStepThrough]
        private Uri ReadTargetFile()
        {
            Uri rv = null;

            try
            {
                string contents = File.ReadAllText(_targetFile);
                rv = new Uri(contents);
            }
            catch (FileNotFoundException)
            {
            }
            catch (UriFormatException)
            {
                rv = Constants.DefaultTarget;
            }

            return rv;
        }
    }
}