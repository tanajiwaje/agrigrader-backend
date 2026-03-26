using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriGrader.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "user");

            migrationBuilder.EnsureSchema(
                name: "master");

            migrationBuilder.RenameTable(
                name: "SubCommodities",
                newName: "SubCommodities",
                newSchema: "master");

            migrationBuilder.RenameTable(
                name: "Sellers",
                newName: "Sellers",
                newSchema: "user");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Roles",
                newSchema: "user");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customers",
                newSchema: "user");

            migrationBuilder.RenameTable(
                name: "Commodities",
                newName: "Commodities",
                newSchema: "master");

            migrationBuilder.RenameTable(
                name: "Buyers",
                newName: "Buyers",
                newSchema: "user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "SubCommodities",
                schema: "master",
                newName: "SubCommodities");

            migrationBuilder.RenameTable(
                name: "Sellers",
                schema: "user",
                newName: "Sellers");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "user",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "Customers",
                schema: "user",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "Commodities",
                schema: "master",
                newName: "Commodities");

            migrationBuilder.RenameTable(
                name: "Buyers",
                schema: "user",
                newName: "Buyers");
        }
    }
}
