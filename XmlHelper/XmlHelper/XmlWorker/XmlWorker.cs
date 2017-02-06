using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlHelper.XmlWorker
{
    class XmlWorker
    {
        //from home 1.1
        //from home 1.2
        //from work 1.3
        public static string queueName;
        public static bool qDurable;
        public static string qPersistent;
        public static string qExchange;
        public static string qUri;

        public static string readXml()
        {
            string res = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("config/amqp.xml");
                XmlNodeList queuconfig = doc.SelectNodes("//AmqpQueueConfig");
                foreach (XmlNode q in queuconfig)
                {
                    //make a list or hasmap, put the shit in that

                    queueName = q["QueueName"].InnerText;
                    qDurable = Convert.ToBoolean(q["Durable"].InnerText);
                    qPersistent = q["PersistentMessages"].InnerText;
                    qExchange = q["ExchangeName"].InnerText;
                    qUri = q["URI"].InnerText;
                    res = queueName + qDurable + qPersistent + qExchange + qUri;


                }
            }
            catch (Exception n)
            {
                Console.WriteLine("There was an error i xml: " + n.Message);
                res  = "Error " + n.Message;
            }
            return res;
            //Console.ReadLine();

        }
    }
}
