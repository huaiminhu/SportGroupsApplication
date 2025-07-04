using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportGroups.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColToEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sport",
                table: "ClubEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sport",
                table: "ClubEvents");
        }
    }
}
