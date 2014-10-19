using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ObjectCollab.BusinessLayer.BusinessObjects
{
    public interface IDataObjectGroupBO
    {
        int Id { get; set; }
        string Name { get; set; }


        

        int? ParentId { get; set; }
        DataObjectGroupBO ParentGroup { get; set; }
        ICollection<DataObjectBO> ChildrenDataObjects { get; set; }
        ICollection<DataObjectGroupBO> ChildrenGroups { get; set; }
        
    }

    public class DataObjectGroupBO : IDataObjectGroupBO
    {
        public int Id { get; set; }
        public string Name { get; set; }


        

        public int? ParentId { get; set; }
        public virtual DataObjectGroupBO ParentGroup { get; set; }
        public virtual ICollection<DataObjectBO> ChildrenDataObjects { get; set; }
        public virtual ICollection<DataObjectGroupBO> ChildrenGroups { get; set; }

        

        
    }
}
