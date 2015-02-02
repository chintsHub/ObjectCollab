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
    public interface IOleDbObjectEngine
    {
        IOleDbDataObjectBO GetOleDbObjectById(int dataObjectId);
    }

    public class OleDbObjectEngine : IOleDbObjectEngine
    {
        private IObjectCollabDAL _dal;

        public OleDbObjectEngine(IObjectCollabDAL dal)
        {
            this._dal = dal;
        }

        public IOleDbDataObjectBO GetOleDbObjectById(int dataObjectId)
        {
            if (dataObjectId <= 0)
                throw new Exception("Invalid Oledb Object Id");

            IOleDbDataObjectBO retVal;

            
            using (var context = _dal.GetDataContext())
            {
                
                var dataObject = context.OleDbDataObjects
                        .Include(obj => obj.Connection)
                        .Include(obj => obj.ColumnDefinitions)
                        .Single(obj => obj.Id == dataObjectId);

                retVal = Mapper.Map<OleDbDataObject, IOleDbDataObjectBO>(dataObject);
            }

            return retVal;

        }
    }
}
