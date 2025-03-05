using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

#nullable disable

namespace Solution.Database.Migrations
{
    /// <inheritdoc />
    public partial class CoolerType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var query = @$"
                insert into
                    [CoolerType]
                    ([Name])
               VALUES
                    ('Water'),
                    ('Air'),
                    ('Oil');

            ";

            migrationBuilder.Sql(query);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var query = $"truncate table [Manufacturer]";

            migrationBuilder.Sql(query);
        }
    }
}
