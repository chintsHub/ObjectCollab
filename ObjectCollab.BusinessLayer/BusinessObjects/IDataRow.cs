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
        IDataObjectBO DataObject {get; set;}
        object this[IColumnDefinitionBO field] { get;}
        

    }

    public class DataRowBO : IDataRowBO
    {
        private DataRow _row;
        
        public IDataObjectBO DataObject { get; set; }
        public object this[IColumnDefinitionBO field] 
        { 
            get
            {
                return _row[field.SourceColumn];
            }
            
        }

        public DataRowBO(DataRow row, IDataObjectBO dataObject)
        {
            _row = row;
            DataObject = dataObject;

        }
        
    }

  
}
