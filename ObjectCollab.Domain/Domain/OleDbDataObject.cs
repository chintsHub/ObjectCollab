using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectCollab.Domain.Domain
{
    public interface IOleDbDataObject : IDataObject
    {
        
        int ConnectionId { get; set; }
        OledbConnection Connection { get; set; }

        string ObjectName { get; set; }
        ICollection<ColumnDefinition> ColumnDefinitions { get; set; }
        string WhereClause { get; set; }

        

    }

    public class OleDbDataObject : DataObject, IOleDbDataObject, IValidatableObject
    {
        public int ConnectionId { get; set; }
        public OledbConnection Connection { get; set; }

        public string ObjectName { get; set; }
        public ICollection<ColumnDefinition> ColumnDefinitions { get; set; }

        public string WhereClause { get; set; }

        public OledbProvider OledbProvider { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (String.IsNullOrWhiteSpace(ObjectName))
                validationResults.Add(new ValidationResult("TargetObjectName is required", new string[] { "TargetObjectName" }));

            if (ConnectionId <= 0)
                validationResults.Add(new ValidationResult("ConnectionId must be greater then zero", new string[] { "ConnectionId" }));

            return validationResults;
        }
    }

    public interface IOledbConnection
    {
        int ConnectionId { get; set; }
        OledbProvider Provider { get; set; }
        string ConnectionName { get; set; }
        string ConnectionString { get; set; }
        byte[] RowVersion { get; set; }
    }

    public class OledbConnection : IOledbConnection, IValidatableObject
    {
        public int ConnectionId { get; set; }
        public string ConnectionName { get; set; }
        public string ConnectionString { get; set; }
        public byte[] RowVersion { get; set; }
        public OledbProvider Provider { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (String.IsNullOrWhiteSpace(ConnectionName))
                validationResults.Add(new ValidationResult("ConnectionName is required", new string[] { "ConnectionName" }));

            if (String.IsNullOrWhiteSpace(ConnectionString))
                validationResults.Add(new ValidationResult("ConnectionString is required", new string[] { "ConnectionString" }));

            return validationResults;
        }
    }

    public interface IColumnDefinition
    {
        int ColumnId { get; set; }
        string SourceColumn { get; set; }
        string Label { get; set; }
        int OleDbDataObjectId { get; set; }
        OleDbDataObject OleDbDataObject { get; set; }
        byte[] RowVersion { get; set; }
    }

    public class ColumnDefinition : IColumnDefinition, IValidatableObject
    {
        public int ColumnId { get; set; }
        public string SourceColumn { get; set; }
        public string Label { get; set; }

        public int OleDbDataObjectId { get; set; }
        public OleDbDataObject OleDbDataObject { get; set; }

        public byte[] RowVersion { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (String.IsNullOrWhiteSpace(SourceColumn))
                validationResults.Add(new ValidationResult("ConnectionName is required", new string[] { "ConnectionName" }));

            if (String.IsNullOrWhiteSpace(Label))
                validationResults.Add(new ValidationResult("ConnectionString is required", new string[] { "ConnectionString" }));

            if (OleDbDataObjectId <= 0)
                validationResults.Add(new ValidationResult("OleDbDataObjectId must be greater then zero", new string[] { "OleDbDataObjectId" }));


            return validationResults;
        }
    }
}
