using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;

namespace AtBlogAPI.Models.Repository
{
    public class CustomSqlServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator
    {
        protected override void Generate(CreateIndexOperation createIndexOperation)
        {
            using (var writer = Writer())
            {
                writer.Write("CREATE ");

                //if (createIndexOperation.IsUnique)
                //{
                //    writer.Write("UNIQUE ");
                //}

                writer.Write("INDEX ");
                writer.Write(Quote(createIndexOperation.Name));
                writer.Write(" ON ");
                writer.Write(Name(createIndexOperation.Table));
                writer.Write("(");

                // Calculate sort order
                object sortOrder;
                createIndexOperation.AnonymousArguments.TryGetValue("SortOrder", out sortOrder);
                var sortOrderSql = sortOrder != null && sortOrder.ToString() == "Descending"
                    ? "DESC"
                    : "ASC";

                // Specify columns, including sort order
                writer.Write(string.Join(",", createIndexOperation.Columns.Select(c => Quote(c) + " " + sortOrderSql)));

                writer.Write(")");
                Statement(writer);
            }
        }
    }
}