using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDV4.Migrations
{
    /// <inheritdoc />
    public partial class Update_CharacterSkill_Repeat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SkillPoint_curent",
                table: "CharacterSkill",
                newName: "SkillPoint_curentValue");

            migrationBuilder.AddColumn<bool>(
                name: "RepeatView",
                table: "CharacterSkill",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepeatView",
                table: "CharacterSkill");

            migrationBuilder.RenameColumn(
                name: "SkillPoint_curentValue",
                table: "CharacterSkill",
                newName: "SkillPoint_curent");
        }
    }
}
