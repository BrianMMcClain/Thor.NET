namespace IronFoundry.Vcap
{
    using System;

    public class Constants
    {
        public static readonly Uri DefaultTarget = new Uri("http://api.cloudfoundry.com");
        public static readonly Uri DefaultLocalTarget = new Uri("http://api.vcap.me");

        // General Paths
        public const string InfoPath = "/info";
        public const string GlobalServicesPath = "/info/services";
        public const string ResourcesPath = "/resources";

        // User specific paths
        public const string AppsPath = "/apps";
        public const string ServicesPath = "/services";
        public const string UsersPath = "/users";
    }
}
