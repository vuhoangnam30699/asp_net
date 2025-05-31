using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingCart.Migrations
{
    /// <inheritdoc />
    public partial class MobilesDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mobiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MobileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZoomUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MobileDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MobileId = table.Column<int>(type: "int", nullable: true),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MobileDetails_Mobiles_MobileId",
                        column: x => x.MobileId,
                        principalTable: "Mobiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MobileDetails_MobileId",
                table: "MobileDetails",
                column: "MobileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MobileDetails");

            migrationBuilder.DropTable(
                name: "Mobiles");
        }
    }
}
