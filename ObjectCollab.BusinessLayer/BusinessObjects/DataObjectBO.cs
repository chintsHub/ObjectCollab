using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectCollab.BusinessLayer.BusinessObjects
{
    public interface IDataObjectBO
    {
        int DataObjectId { get; set; }
        string DataObjectLabel { get; set; }
        int GroupId { get; set; }
        DataObjectGroupBO Group { get; set; }
        
    }




    public class DataObjectBO : IDataObjectBO
    {
        public int DataObjectId { get; set; }
        public string DataObjectLabel { get; set; }


        public int GroupId { get; set; }
        public DataObjectGroupBO Group { get; set; }

        
    }
}
