using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public static class Logger
    {
        //private static IMessageLogger messageLogger;
        private const string baseAddress = "net.pipe://127.0.0.1/Loggger";

        private static ILogService _logService;
        static Logger()
        {
            ChannelFactory<ILogService> factory = new ChannelFactory<ILogService>(
                new NetNamedPipeBinding(NetNamedPipeSecurityMode.None),
                new EndpointAddress(baseAddress));

            _logService = factory.CreateChannel();
        }

        public static void Log(string log, object[] args)
        {
            //using (EventLog eventLog = new EventLog("Application"))
            //{
            //    eventLog.Source = "Application";
            //    eventLog.WriteEntry("Steve just before loggy", EventLogEntryType.Information, 101, 1);
            //}

            var timeStamp = Stopwatch.GetTimestamp();
            var frequency = Stopwatch.Frequency;

            _logService.Log(log + "******" + DateTime.Now);
        }
    }
}
