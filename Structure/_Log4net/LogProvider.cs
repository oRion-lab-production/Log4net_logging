using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Structure._Log4net
{
    public class LogProvider : ILoggerProvider
    {
        private readonly string _configFile;
        private readonly string _configName;
        private readonly ConcurrentDictionary<string, Logger> _loggers =
            new ConcurrentDictionary<string, Logger>();
        public LogProvider(string configFile, string configName)
        {
            _configFile = configFile;
            _configName = configName;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, CreateLoggerImplementation);
        }

        public void Dispose()
        {
            _loggers.Clear();
        }

        private Logger CreateLoggerImplementation(string name)
        {
            return new Logger(name, Parselog4NetConfigFile(_configFile, _configName));
        }

        private static XmlElement Parselog4NetConfigFile(string fileName, string configName)
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead(fileName));
            return log4netConfig[configName];
        }
    }
}
