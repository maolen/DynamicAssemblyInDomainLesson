using System;

namespace DynamicAssemblyInDomainLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            //var domain = AppDomain.CurrentDomain;
            //Console.WriteLine($"{domain}");

            WeakReference reference;

            var currentDomain = AppDomain.CurrentDomain;
            Console.WriteLine("**********************************");

            foreach (var assembly in currentDomain.GetAssemblies())
            {
                Console.WriteLine($"{assembly.GetName()}");
            }

            ProcessCalculator(out reference);

            for (var i = 0; reference.IsAlive && (i < 10); i++)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            Console.WriteLine("**********************************");
            foreach (var assembly in currentDomain.GetAssemblies())
            {
                Console.WriteLine($"{assembly.GetName()}");
            }
        }

        static void ProcessCalculator(out WeakReference weakReference)
        {
            var assemblyPath = @"C:\Users\ЖакуповаК\source\repos\Calculator\Calculator\bin\Debug\netcoreapp3.0\Calculator.dll";
            var context = new CalculatorAssemblyLoadContext();

            var calculatorAssembly = context.LoadFromAssemblyPath(assemblyPath);

            weakReference = new WeakReference(context, true);

            var currentDomain = AppDomain.CurrentDomain;
            Console.WriteLine("**********************************");

            foreach (var assembly in currentDomain.GetAssemblies())
            {
                Console.WriteLine($"{assembly.GetName()}");
            }

            var args = new object[] { new string[] { "1", "5" } };
            calculatorAssembly.EntryPoint.Invoke(null, args);

            context.Unload();

        }
    }
}
