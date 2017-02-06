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
        static void Main(string[] args)
        {
            Console.WriteLine(XmlWorker.XmlWorker.readXml());
            Console.ReadLine();
           

        }
    }
}
