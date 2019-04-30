using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vizew.WebUI
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple = false)]
    public class VizewDatabaseGeneratedAttribute : DatabaseGeneratedAttribute
    {
        public string DefaultValueSql { get; set; }
        public VizewDatabaseGeneratedAttribute(DatabaseGeneratedOption databaseGeneratedOption)
            :base(databaseGeneratedOption)
        {

        }
    }
}