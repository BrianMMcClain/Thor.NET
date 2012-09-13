using System.IO;
using Microsoft.VisualBasic.Devices;

namespace IronFoundry.Utilities
{
    public static class Utility
    {
        public static void CopyDirectory(DirectoryInfo source, DirectoryInfo target)
        {
            var c = new Computer();
            c.FileSystem.CopyDirectory(source.FullName, target.FullName, true);
        }

        public static DirectoryInfo GetTempDirectory()
        {
            return Directory.CreateDirectory(
                Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()));
        }
    }
}