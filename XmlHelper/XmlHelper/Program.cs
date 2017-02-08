using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlHelper.Controller;

namespace XmlHelper
{
    class Program
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Program));
   
        static void Main(string[] args)
        {
            logger.Info("******************************");
            logger.Info("******************");
            logger.Info("*********");
            logger.Info("V 1.4");
            logger.Info("Started Main");
            MainController mc = new MainController();
            DateTime dt = DateTime.Now;
            Console.WriteLine("Testing " + dt);
            Console.ReadLine();


        }
    }
}
