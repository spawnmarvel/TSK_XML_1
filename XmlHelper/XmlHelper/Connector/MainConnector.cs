using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlHelper.XmlWorker;

namespace XmlHelper.Connector
{
    class MainConnector
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(MainConnector));

        public static Boolean doWork()
        {
            logger.Info("Started do work... put in states here");
            bool connect = false;
            if(XmlWorkerNode.readXml() == true)
            { 
                logger.Info("Configuration is valid");
                logger.Info("Connector can try to establish connection");
                if(connectToSource() == true)
                {
                    logger.Info("State is connected..work");
                }
            }
            else
            {
                logger.Error("Check config and source, stopping work...");
            }
            return connect;
            
        }

        public static bool connectToSource()
        {
            logger.Info("Connecting......");
            return true;//if connections is ok...
            //return false if not and reconnect while config is valid...

        }
    }
}
