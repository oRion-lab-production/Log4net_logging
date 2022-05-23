using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure._Log4net
{
    public static class LogBuilder
    {
        static LogBuilder() { }

        public static ILoggerFactory AddLog4net(this ILoggerFactory loggerFactory, string configFile, string configName)
        {
            loggerFactory.AddProvider(new LogProvider(configFile, configName));
            return loggerFactory;
        }
    }
}
