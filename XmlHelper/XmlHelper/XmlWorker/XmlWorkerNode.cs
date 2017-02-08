using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlHelper.XmlWorker
{
    class XmlWorkerNode
    {
        //from home 1.1
        //from home 1.2
        //from work 1.3
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(XmlWorkerNode));
        public static string queueName;
        public static bool qDurable;
        public static bool qPersistent;
        public static string qExchange;
        public static string qUri;
        public static string dataSource;
        public XmlWorkerNode()
        {

        }

        /// <summary>
        /// faster and does not loead the hole file, but can only go forward in tree
        /// </summary>
        /// <returns></returns>
        public static bool readXml()
        {
            logger.Info("Started read xml configuration");
            bool readerState = true;
            logger.Debug("Started xml reader");
            //Create an XML reader for this file.
            try
            {
                XmlReader reader = XmlReader.Create("config/amqp.xml");
                while (reader.Read())
                {
                    // Only detect start elements.
                    if (reader.IsStartElement())
                    {
                        // Get element name and switch on it.
                        switch (reader.Name)
                        {
                            case "AmqpQueueConfig":
                                // Detect this element.
                                logger.Debug("Start <AmqpQueueConfig> element.");
                                break;
                            case "QueueName":
                                // Detect element.
                                logger.Debug("Start <QueueName> element.");
                                // Next read will contain text.
                                if (reader.Read())
                                    if (validateValueXml(reader.Value) == false)
                                    {
                                        logger.Error("Missing value in config -> " + reader.Value.Trim());
                                        readerState = false;
                                    }
                                    else
                                    {
                                        logger.Info("Value XML: " + reader.Value.Trim());
                                    }
                                break;
                            case "QueueType":
                                // Detect this element.
                                logger.Debug("Start <QueueType> element.");
                                // Next read will contain text.
                                if (reader.Read())
                                {
                                    if (validateValueXml(reader.Value) == false)
                                    {
                                        logger.Error("Missing value in config -> " + reader.Value.Trim());
                                        readerState = false;
                                    }
                                    else
                                    {
                                        logger.Info("Value XML: " + reader.Value.Trim());
                                    }
                                }
                                break;
                        }
                    }

                }
                reader.Close();
            }
            catch (XmlException msg)
            {

                readerState = false;
                logger.Error(msg);
            }

            logger.Info("Read xml state = " + readerState);
            return readerState;
        }

        /// <summary>
        /// helper for validating
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool validateValueXml(string val)
        {
            bool state = false;
            if (val.Length > 3)
            {
                state = true;
            }
            return state;

        }

    }

}
