using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectCollab.BusinessLayer.BusinessObjects
{
    public interface IDataRowBO
    {
        IDataObjectBO DataObject {get; set;}
        object this[ColumnDefinitionBO field] { get;set;}

    }

  
}
