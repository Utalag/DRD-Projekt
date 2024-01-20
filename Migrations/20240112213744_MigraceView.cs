using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDV4.Migrations
{
    /// <inheritdoc />
    public partial class MigraceView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepeatView",
                table: "CharacterSkill");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RepeatView",
                table: "CharacterSkill",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
