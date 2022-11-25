using log4net.Repository;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SDETAPI_CSharp.Tests
{
    //Configures the logs
    public abstract class BaseTestClass<T> where T : BaseTestClass<T>, new()
    {
        public static ILog Log { get => LogManager.GetLogger(typeof(T)); }

        private void LoggingTests()
        {
            ILoggerRepository repository = LogManager.GetRepository(Assembly.GetCallingAssembly());

            var fileInfo = new FileInfo(@"log4net.config");

            log4net.Config.XmlConfigurator.Configure(repository, fileInfo);
        }

        protected BaseTestClass()
        {
            this.LoggingTests();
        }
    }
}
