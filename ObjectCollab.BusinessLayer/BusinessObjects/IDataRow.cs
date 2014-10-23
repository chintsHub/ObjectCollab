using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using ObjectCollab.Domain;

namespace ObjectCollab.BusinessLayer.BusinessObjects
{
    public interface IDataRowBO
    {
        IDataObject DataObject {get; set;}
        object this[ColumnDefinitionBO field] { get;}
        

    }

    public class DataRowBO : IDataRowBO
    {
        private DataRow _row;
        
        public IDataObject DataObject { get; set; }
        public object this[ColumnDefinitionBO field] 
        { 
            get
            {
                return _row[field.SourceColumn];
            }
            
        }

        public DataRowBO(DataRow row, IDataObject dataObject)
        {
            _row = row;
            DataObject = dataObject;

        }
        
    }

  
}
