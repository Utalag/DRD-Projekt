using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDV4.Migrations
{
    /// <inheritdoc />
    public partial class Dangerousness_CharacterSkill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Dangerousness",
                table: "CharacterSkill",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dangerousness",
                table: "CharacterSkill");
        }
    }
}
