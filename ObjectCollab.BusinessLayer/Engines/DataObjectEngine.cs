using System;
using System.Data.Entity;
using System.Linq;
using ObjectCollab.DAL;
using ObjectCollab.Domain;
using ObjectCollab.Enums;


namespace ObjectCollab.BusinessLayer.Engines
{
    public interface IDataObjectEngine
    {
        IDataObject GetDataObjectById(int dataObjectId);
    }

    public class DataObjectEngine : IDataObjectEngine
    {
        private IObjectCollabDAL _dal;

        public DataObjectEngine(IObjectCollabDAL dal)
        {
            this._dal = dal;
        }

        public IDataObject GetDataObjectById(int dataObjectId)
        {
            if (dataObjectId <= 0)
                throw new Exception("Invalid DataObject Id");

            DataObject dataObject;
            using (var context = _dal.GetDataContext())
            {
                dataObject = context.DataObjects
                    .Single(obj => obj.DataObjectId == dataObjectId);

                //this feels like bit of hack.
                //now load the dervied object

                if (dataObject.DataObjectType == DataObjectType.Oledb)
                    dataObject = context.OleDbDataObjects
                        .Include(obj => obj.Connection)
                        .Single(obj => obj.DataObjectId == dataObjectId);
            }

            return dataObject;

        }
    }
}
