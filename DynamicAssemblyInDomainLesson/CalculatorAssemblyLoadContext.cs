﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace DynamicAssemblyInDomainLesson
{
    class CalculatorAssemblyLoadContext : AssemblyLoadContext
    {
        //private AssemblyDependencyResolver _resolver;

        public CalculatorAssemblyLoadContext(/*string mainAssemblyToLoadPath*/) : base(isCollectible: true)
        {
            //_resolver = new AssemblyDependencyResolver(mainAssemblyToLoadPath);
        }

        protected override Assembly Load(AssemblyName name)
        {
            //var assemblyPath = _resolver.ResolveAssemblyToPath(name);
            //if (assemblyPath != null)
            //{
            //    return LoadFromAssemblyPath(assemblyPath);
            //}

            return null;
        }
    }
}
