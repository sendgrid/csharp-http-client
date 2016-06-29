using NUnit.Common;
using NUnitLite;
using System;
using System.Reflection;

namespace UnitTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
#if DNX451
            new AutoRun().Execute(args);
#else
            var writter = new ExtendedTextWrapper(Console.Out);
            new AutoRun(typeof(Program).GetTypeInfo().Assembly).Execute(args, writter, Console.In);
#endif
        }
    }
}
