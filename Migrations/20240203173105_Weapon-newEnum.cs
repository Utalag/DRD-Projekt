using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRD.Migrations
{
    /// <inheritdoc />
    public partial class WeaponnewEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SizeWeapon",
                table: "Weapon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeWeapon",
                table: "Weapon",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SizeWeapon",
                table: "Weapon");

            migrationBuilder.DropColumn(
                name: "TypeWeapon",
                table: "Weapon");
        }
    }
}
