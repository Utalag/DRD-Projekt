using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDV4.Migrations
{
    /// <inheritdoc />
    public partial class Rename_Range_CharacterSkill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SkillEnum",
                table: "CharacterSkill",
                newName: "Rank");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rank",
                table: "CharacterSkill",
                newName: "SkillEnum");
        }
    }
}
