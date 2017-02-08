using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlHelper.Connector;

namespace XmlHelper.Controller
{
    class MainController
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(MainController));

        public MainController()
        {
            startConnection();
        }
        public void startConnection()
        {
            MainConnector.connectToSource();
            logger.Info("Started work from Controller");
            logger.Info("Call Connector methods and work");
        }
        //add while connection == true
    }
}
