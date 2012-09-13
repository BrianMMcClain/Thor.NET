using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace IronFoundry.Utilities
{
    public class CustomSerializationBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            var handler = new ResolveEventHandler(CurrentDomainAssemblyResolve);
            AppDomain.CurrentDomain.AssemblyResolve += handler;

            Type returnedType;
            try
            {
                var asmName = new AssemblyName(assemblyName);
                var assembly = Assembly.Load(asmName);
                returnedType = assembly.GetType(typeName);
            }
            catch
            {
                returnedType = null;
            }
            finally
            {
                AppDomain.CurrentDomain.AssemblyResolve -= handler;
            }

            return returnedType;
        }

        static Assembly CurrentDomainAssemblyResolve(object sender, ResolveEventArgs args)
        {
            var truncatedAssemblyName = args.Name.Split(',')[0];
            var assembly = Assembly.Load(truncatedAssemblyName);
            return assembly;
        }
    }
}
