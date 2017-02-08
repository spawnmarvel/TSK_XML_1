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
        public static string dataSource;

        public static bool readXml()
        {
            bool connect = false;
            logger.Info("Reading config");
            string res = "";
            try
            {
                //amqp
                XmlDocument sourceAmqp = new XmlDocument();
                sourceAmqp.Load("config/amqp.xml");
                //click on file and change to copy always (copy to output dir)
                XmlNodeList queuconfigAMQP = sourceAmqp.SelectNodes("//AmqpQueueConfig");

                //data source
                XmlDocument sourceData = new XmlDocument();
                sourceData.Load("config/amqp.xml");
                //click on file and change to copy always (copy to output dir)
                XmlNodeList queuconfigData = sourceData.SelectNodes("//DataSourceConfig");
                //AMQP
                logger.Info("Read AMQP");
                foreach (XmlNode q in queuconfigAMQP)
                {
                    //make a list or hasmap, put the shit in that
                    queueName = q["QueueName"].InnerText;
                    qDurable = Convert.ToBoolean(q["Durable"].InnerText);
                    qPersistent = Convert.ToBoolean(q["PersistentMessages"].InnerText);
                    qExchange = q["ExchangeName"].InnerText;
                    qUri = q["URI"].InnerText;
                    res = queueName + " ; " + qDurable + " ; " + qPersistent + " ; " + qExchange + " ; "+ qUri + ";";
                    logger.Debug(res);
                    connect = true;
                    logger.Info("Connection = " + connect);

                }
                logger.Info("Read DataSource");
                foreach (XmlNode q in queuconfigData)
                {
                    //make a list or hasmap, put the shit in that
                    dataSource = q["Source"].InnerText;
                    res = dataSource;
                    logger.Debug(res);
                    connect = true;
                    logger.Info("Connection = " + connect);

                }
            }
            catch (Exception n)
            {
                logger.Error("Error:" + n.Message);
            }
            return connect;
        }

    }
}
