using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectCollab.DAL;
using ObjectCollab.Domain;

namespace ObjectCollab.BusinessLayer.Engines
{
    public interface IDataObjectEngine
    {
        void GetDataObjectById(int dataObjectId);
    }

    public class DataObjectEngine
    {
        private IObjectCollabDAL _dal;

        public DataObjectEngine(IObjectCollabDAL dal)
        {
            this._dal = dal;
        }

        public void GetDataObjectById(int dataObjectId)
        {
            if (dataObjectId <= 0)
                throw new Exception("Invalid DataObject Id");

            DataObject data;
            using (var context = _dal.GetDataContext())
            {
                data = context.DataObjects.SingleOrDefault(obj => obj.DataObjectId == dataObjectId);
            }
        }
    }
}
