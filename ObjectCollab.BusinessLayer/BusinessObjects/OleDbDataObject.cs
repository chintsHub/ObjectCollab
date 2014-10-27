using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectCollab.Enums;

namespace ObjectCollab.BusinessLayer.BusinessObjects
{
    public interface IOleDbDataObjectBO : IDataObjectBO
    {
        
        int ConnectionId { get; set; }
        IOledbConnectionBO Connection { get; set; }

        string ObjectName { get; set; }
        ICollection<IColumnDefinitionBO> ColumnDefinitions { get; set; }
        string WhereClause { get; set; }

        

    }

    public class OleDbDataObjectBO : DataObjectBO, IOleDbDataObjectBO
    {
        public int ConnectionId { get; set; }
        public IOledbConnectionBO Connection { get; set; }

        public string ObjectName { get; set; }
        public ICollection<IColumnDefinitionBO> ColumnDefinitions { get; set; }

        public string WhereClause { get; set; }

        public OledbProvider OledbProvider { get; set; }

     
    }

    public interface IOledbConnectionBO
    {
        int ConnectionId { get; set; }
        OledbProvider Provider { get; set; }
        string ConnectionName { get; set; }
        string ConnectionString { get; set; }
        
    }

    public class OledbConnectionBO : IOledbConnectionBO
    {
        public int ConnectionId { get; set; }
        public string ConnectionName { get; set; }
        public string ConnectionString { get; set; }
        public byte[] RowVersion { get; set; }
        public OledbProvider Provider { get; set; }

     
    }

    public interface IColumnDefinitionBO
    {
        int ColumnId { get; set; }
        string SourceColumn { get; set; }
        string Label { get; set; }
        int OleDbDataObjectId { get; set; }
        OleDbDataObjectBO OleDbDataObjectBO { get; set; }
        
    }

    public class ColumnDefinitionBO : IColumnDefinitionBO
    {
        public int ColumnId { get; set; }
        public string SourceColumn { get; set; }
        public string Label { get; set; }

        public int OleDbDataObjectId { get; set; }
        public OleDbDataObjectBO OleDbDataObjectBO { get; set; }

   
    }
}
