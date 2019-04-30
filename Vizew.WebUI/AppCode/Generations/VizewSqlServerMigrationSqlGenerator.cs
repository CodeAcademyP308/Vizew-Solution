using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.SqlServer;

namespace Vizew.WebUI
{
    public class VizewSqlServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator
    {
        protected override void Generate(AddColumnOperation operation)
        {
            SetColumnValue(operation.Column);

            base.Generate(operation);
        }

        protected override void Generate(AlterColumnOperation operation)
        {
            SetColumnValue(operation.Column);

            base.Generate(operation);
        }

        protected override void Generate(AlterTableOperation operation)
        {
            foreach (var column in operation.Columns)
                SetColumnValue(column);

            base.Generate(operation);
        }

        protected override void Generate(CreateTableOperation operation)
        {
            foreach (var column in operation.Columns)
                SetColumnValue(column);

            base.Generate(operation);
        }

        void SetColumnValue(ColumnModel column)
        {
            if (column.Annotations.TryGetValue("VizewDatabaseGenerated", out AnnotationValues vizewDatabaseValue))
            {
                column.DefaultValueSql = (vizewDatabaseValue.NewValue ?? "").ToString();
            }
            else if (column.Annotations.TryGetValue("VizewSqlDefaultValue", out AnnotationValues vizewSqlDefaultValue))
            {
                column.DefaultValueSql = (vizewSqlDefaultValue.NewValue ?? "").ToString();
            }
        }
    }
}