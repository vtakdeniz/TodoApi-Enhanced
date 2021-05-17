using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoApi.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caption = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Urgency = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Passwd = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tasks");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
