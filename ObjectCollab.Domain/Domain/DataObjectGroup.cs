using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectCollab.Domain.Domain;

namespace ObjectCollab.Domain
{
    public interface IDataObjectGroup
    {
        int Id { get; set; }
        string Name { get; set; }


        

        int? ParentId { get; set; }
        DataObjectGroup ParentGroup { get; set; }
        ICollection<DataObject> ChildrenDataObjects { get; set; }
        ICollection<DataObjectGroup> ChildrenGroups { get; set; }
        byte[] RowVersion { get; set; }
    }

    public class DataObjectGroup : IDataObjectGroup, IValidatableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }


        

        public int? ParentId { get; set; }
        public virtual DataObjectGroup ParentGroup { get; set; }
        public virtual ICollection<DataObject> ChildrenDataObjects { get; set; }
        public virtual ICollection<DataObjectGroup> ChildrenGroups { get; set; }

        public byte[] RowVersion { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (String.IsNullOrWhiteSpace(Name))
                validationResults.Add(new ValidationResult("Name is required", new string[] { "Name" }));


            return validationResults;
        }
    }
}
