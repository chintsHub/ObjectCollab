using ObjectCollab.BusinessLayer.BusinessObjects;
using ObjectCollab.BusinessLayer.Engine;


namespace ObjectCollab.BusinessLayer.Factory
{
    public class DataProvider : IDataProvider
    {

        public IDataExtractor GetDataExtractor(IDataObjectBO dataObject)
        {
            IDataExtractor retVal = null;
            if(dataObject.GetType() == typeof(OleDbDataObjectBO))
            {
                retVal = new OledbDataExtractor(dataObject as OleDbDataObjectBO, new OleDbDataAccessEngine());
            }

            return retVal;
        }

       
    }
}