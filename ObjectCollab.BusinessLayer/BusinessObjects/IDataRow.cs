using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using ObjectCollab.Domain;

namespace ObjectCollab.BusinessLayer.BusinessObjects
{
    public interface IOledbDataRowBO
    {
        IOleDbDataObjectBO DataObject {get; set;}
        object this[IColumnDefinitionBO field] { get;}
        

    }

    public class OledbDataRowBo : IOledbDataRowBO
    {
        private DataRow _row;

        public IOleDbDataObjectBO DataObject { get; set; }
        public object this[IColumnDefinitionBO field] 
        { 
            get
            {
                return _row[field.SourceColumn];
            }
            
        }

        public OledbDataRowBo(DataRow row, IOleDbDataObjectBO dataObject)
        {
            _row = row;
            DataObject = dataObject;

        }
        
    }

  
}
