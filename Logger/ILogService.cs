using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    [ServiceContract]
    public interface ILogService
    {
        [OperationContract]
        void Log(string message);
    }
}
