using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDV4.Migrations
{
    /// <inheritdoc />
    public partial class Weapon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weapon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameWeapon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SZ = table.Column<int>(type: "int", nullable: false),
                    UT = table.Column<int>(type: "int", nullable: false),
                    OZ = table.Column<int>(type: "int", nullable: false),
                    ClassWeapon = table.Column<int>(type: "int", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ManufacturerBonus = table.Column<int>(type: "int", nullable: false),
                    Metal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Demon = table.Column<int>(type: "int", nullable: false),
                    MinimalControllability = table.Column<int>(type: "int", nullable: false),
                    ControlAttribute = table.Column<int>(type: "int", nullable: false),
                    LengthWeapon = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    WeightWeapon = table.Column<int>(type: "int", nullable: false),
                    InitiativeWeapon = table.Column<int>(type: "int", nullable: false),
                    MinGunshot = table.Column<int>(type: "int", nullable: false),
                    MiddleGunshot = table.Column<int>(type: "int", nullable: false),
                    MaxGunshot = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapon", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weapon");
        }
    }
}
