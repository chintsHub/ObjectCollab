using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectCollab.BusinessLayer.Factory;
using ObjectCollab.BusinessLayer.Manager;
using ObjectCollab.BusinessLayer.Managers;

namespace ObjectCollab.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // set up code
            var extMang = new ExternalDataManager(new DataProvider());

            //var extDataMang = new DataObjectManager(extMang);
        }
    }
}
