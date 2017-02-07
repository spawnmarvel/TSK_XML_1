using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlHelper.XmlWorker;

namespace XmlHelper
{
    class Program
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            logger.Info("Started");
            XmlWorker.XmlWorker.readXml();
            foreach(string s in XmlWorker.XmlWorker.readXml())
            {
                logger.Debug(s);
                string[] queue = s.Split(';');
                string n = queue[0];
                bool dur = Convert.ToBoolean(queue[1]);
                logger.Debug("From reader to connect " + n + dur);
            }
            Console.ReadLine();


        }
    }
}
