using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDV4.Migrations
{
    /// <inheritdoc />
    public partial class FightValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AtackNr",
                table: "CharacterWeapon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DefenseNr",
                table: "CharacterWeapon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DemageNr",
                table: "CharacterWeapon",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AtackNr",
                table: "CharacterWeapon");

            migrationBuilder.DropColumn(
                name: "DefenseNr",
                table: "CharacterWeapon");

            migrationBuilder.DropColumn(
                name: "DemageNr",
                table: "CharacterWeapon");
        }
    }
}
