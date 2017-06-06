using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFNamedPipeExample.Services
{

    [ServiceBehavior(UseSynchronizationContext = false)]
    public class LogService : ILogService
    {
        public void Log(string message)
        {
            MainWindow.main.lstResult.Dispatcher.Invoke(() =>
            {
                MainWindow.main.lstResult.Items.Add(message);
            });
        }
    }
}
