using System;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using ObjectCollab.BusinessLayer.BusinessObjects;
using ObjectCollab.DAL;
using ObjectCollab.Domain;
using ObjectCollab.Enums;


namespace ObjectCollab.BusinessLayer.Engines
{
    public interface IDataObjectEngine
    {
        IDataObjectBO GetDataObjectById(int dataObjectId);
    }

    public class DataObjectEngine : IDataObjectEngine
    {
        private IObjectCollabDAL _dal;

        public DataObjectEngine(IObjectCollabDAL dal)
        {
            this._dal = dal;
        }

        public IDataObjectBO GetDataObjectById(int dataObjectId)
        {
            if (dataObjectId <= 0)
                throw new Exception("Invalid DataObject Id");

            IDataObjectBO retVal;

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
                        .Include(obj => obj.ColumnDefinitions)
                        .Single(obj => obj.DataObjectId == dataObjectId);

                retVal = Mapper.Map<OleDbDataObject, IOleDbDataObjectBO>(dataObject as OleDbDataObject);
            }

            return retVal;

        }
    }
}
