using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoApi.Migrations
{
    public partial class fixedUserJobRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tasks");

            migrationBuilder.DropTable(
                name: "user_Has_Tasks");

            migrationBuilder.CreateTable(
                name: "jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caption = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Urgency = table.Column<int>(type: "int", nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user_Has_jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Job_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_Has_jobs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "jobs");

            migrationBuilder.DropTable(
                name: "user_Has_jobs");

            migrationBuilder.CreateTable(
                name: "tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caption = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false),
                    Urgency = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user_Has_Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Task_Id = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_Has_Tasks", x => x.Id);
                });
        }
    }
}
