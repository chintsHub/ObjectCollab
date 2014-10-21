using System.Configuration;
using ObjectCollab.BusinessLayer.Automapper;
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
            extDataMang.GetDataForDataObject(1);
        }
    }
}
