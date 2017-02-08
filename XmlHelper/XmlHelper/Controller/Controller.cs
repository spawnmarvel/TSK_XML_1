using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlHelper.Connector;

namespace XmlHelper.Controller
{
    class Controller
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Controller));

        public Controller()
        {
            startConnection();
        }
        public void startConnection()
        {
            Connector.Connector.connectToSource();
            logger.Info("Started work from Controller");
            logger.Info("Call Connector methods and work");
        }
    }
}
