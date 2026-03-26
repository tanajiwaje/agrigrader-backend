using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriGrader.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCommodityAndSubCommodity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commodities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommodityCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommodityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commodities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCommodities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCommodityCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCommodityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommodityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCommodities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCommodities_Commodities_CommodityId",
                        column: x => x.CommodityId,
                        principalTable: "Commodities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubCommodities_CommodityId",
                table: "SubCommodities",
                column: "CommodityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubCommodities");

            migrationBuilder.DropTable(
                name: "Commodities");
        }
    }
}
