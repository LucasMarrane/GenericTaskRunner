﻿using System.Reflection;
using System.Runtime.Loader;

namespace GenericTaskRunner.Controllers
{
    public class ExtensionContext : AssemblyLoadContext
    {
        private AssemblyDependencyResolver _resolver;
        public ExtensionContext(string pluginPath)
        {
            _resolver = new AssemblyDependencyResolver(pluginPath);
        }
        protected override Assembly? Load(AssemblyName assemblyName)
        {
            string assemblyPath = _resolver.ResolveAssemblyToPath(assemblyName);
            if (assemblyPath != null)
            {
                return LoadFromAssemblyPath(assemblyPath);
            }
            return null;
        }        
    }
}
