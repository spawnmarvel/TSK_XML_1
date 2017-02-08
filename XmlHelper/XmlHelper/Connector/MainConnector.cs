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

        public static Boolean connectToSource()
        {
            bool connect = false;
            if(XmlWorker.XmlWorker.readXml() == true)
            {
                string qu = XmlWorker.XmlWorker.queueName;
                bool dur = XmlWorker.XmlWorker.qDurable;
                bool per = XmlWorker.XmlWorker.qPersistent;
                string ex = XmlWorker.XmlWorker.qExchange;
                string ur = XmlWorker.XmlWorker.qUri;
                string source = XmlWorker.XmlWorker.dataSource;
                logger.Info("Connection connected");
                logger.Info("Connector can work with queue: " + qu + " And data source: " + source);
            }
            else
            {
                logger.Error("Could not connect, check config and source");
            }
            return connect;
            
        }
    }
}
