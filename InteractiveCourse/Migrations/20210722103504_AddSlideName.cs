using Microsoft.EntityFrameworkCore.Migrations;

namespace InteractiveCourse.Migrations
{
    public partial class AddSlideName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SlideName",
                table: "Slides",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SlideName",
                table: "Slides");
        }
    }
}
