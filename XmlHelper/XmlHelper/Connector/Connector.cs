using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlHelper.XmlWorker;

namespace XmlHelper.Connector
{
    class Connector
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Connector));

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
                logger.Info("Connection connected");
                logger.Info("Connector can work....");
            }
            else
            {
                logger.Error("Could not connect, check config and source");
            }
            return connect;
            
        }
    }
}
