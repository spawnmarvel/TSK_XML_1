using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using log4net.Config;

namespace XmlHelper.XmlWorker
{
    class XmlWorker
    {
        //from home 1.1
        //from home 1.2
        //from work 1.3
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(XmlWorker));
        public static string queueName;
        public static bool qDurable;
        public static bool qPersistent;
        public static string qExchange;
        public static string qUri;

        public static string readXml()
        {

            logger.Info("readXml()");
            string res = "";
            int count = 0;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("config/amqp.xml");
                //click on file and change to copy always (copy to output dir)
                XmlNodeList queuconfig = doc.SelectNodes("//AmqpQueueConfig");
                foreach (XmlNode q in queuconfig)
                {
                    //make a list or hasmap, put the shit in that
                    queueName = q["QueueName"].InnerText;
                    qDurable = Convert.ToBoolean(q["Durable"].InnerText);
                    qPersistent = Convert.ToBoolean(q["PersistentMessages"].InnerText);
                    qExchange = q["ExchangeName"].InnerText;
                    qUri = q["URI"].InnerText;
                    res += queueName + " ; " + qDurable + " ; " + qPersistent + " ; " + qExchange + " ; "+ qUri + ";";
                    count += 1;
                    logger.Debug(res);

                }
            }
            catch (Exception n)
            {
                logger.Error("Error:" + n.Message);
            }
            res = count + ";" + res;
            logger.Debug(res);
            return res;
        }

    }
}
