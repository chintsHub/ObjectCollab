using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectCollab.Domain
{
    public interface IDataObject
    {
        int DataObjectId { get; set; }
        string DataObjectLabel { get; set; }
        int GroupId { get; set; }
        DataObjectGroup Group { get; set; }
        byte[] RowVersion { get; set; }
    }




    public class DataObject : IDataObject
    {
        public int DataObjectId { get; set; }
        public string DataObjectLabel { get; set; }


        public int GroupId { get; set; }
        public DataObjectGroup Group { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
