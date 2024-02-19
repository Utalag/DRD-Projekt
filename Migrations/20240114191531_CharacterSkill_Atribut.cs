using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRD.Migrations
{
    /// <inheritdoc />
    public partial class CharacterSkill_Atribut : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Atribut",
                table: "CharacterSkill",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Atribut",
                table: "CharacterSkill");
        }
    }
}
