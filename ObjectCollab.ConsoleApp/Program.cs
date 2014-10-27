using System;
using System.Configuration;
using System.Linq;
using ObjectCollab.BusinessLayer.Automapper;
using ObjectCollab.BusinessLayer.BusinessObjects;
using ObjectCollab.BusinessLayer.Engines;
using ObjectCollab.BusinessLayer.Factory;
using ObjectCollab.BusinessLayer.Manager;
using ObjectCollab.BusinessLayer.Managers;
using ObjectCollab.DAL;

namespace ObjectCollab.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // set up code
            AutoMapperConfiguration.Configure();
            var objectCollabDal = new ObjectCollabDAL(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            var extMang = new ExternalDataManager(new DataProvider());


            var extDataMang = new DataObjectManager(extMang, new DataObjectEngine(objectCollabDal));
            var assetData = extDataMang.GetDataForDataObject(1);

            

            foreach (var dataRowBo in assetData)
            {
                var oledbObj = dataRowBo.DataObject as IOleDbDataObjectBO;
                var col = oledbObj.ColumnDefinitions.First(c => c.SourceColumn == "Name");
                Console.WriteLine(dataRowBo[col].ToString());
            }

            Console.ReadLine();

        }
    }
}
