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
            Console.ReadLine();


        }
    }
}
