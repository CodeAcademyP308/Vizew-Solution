using System;

namespace Vizew.WebUI
{
    public class VizewSqlDefaultValueAttribute : Attribute
    {
        public string DefaultValueSql { get; set; }
    }
}