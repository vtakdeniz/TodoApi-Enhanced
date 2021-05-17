using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoApi.Migrations
{
    public partial class AddedManyToManyUserJobRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_user_Has_jobs",
                table: "user_Has_jobs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "user_Has_jobs");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "user_Has_jobs",
                newName: "JobId");

            migrationBuilder.RenameColumn(
                name: "Job_Id",
                table: "user_Has_jobs",
                newName: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_Has_jobs",
                table: "user_Has_jobs",
                columns: new[] { "UserId", "JobId" });

            migrationBuilder.CreateIndex(
                name: "IX_user_Has_jobs_JobId",
                table: "user_Has_jobs",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_Has_jobs_jobs_JobId",
                table: "user_Has_jobs",
                column: "JobId",
                principalTable: "jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_Has_jobs_users_UserId",
                table: "user_Has_jobs",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_Has_jobs_jobs_JobId",
                table: "user_Has_jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_user_Has_jobs_users_UserId",
                table: "user_Has_jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_Has_jobs",
                table: "user_Has_jobs");

            migrationBuilder.DropIndex(
                name: "IX_user_Has_jobs_JobId",
                table: "user_Has_jobs");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "user_Has_jobs",
                newName: "User_Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user_Has_jobs",
                newName: "Job_Id");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "user_Has_jobs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_Has_jobs",
                table: "user_Has_jobs",
                column: "Id");
        }
    }
}
