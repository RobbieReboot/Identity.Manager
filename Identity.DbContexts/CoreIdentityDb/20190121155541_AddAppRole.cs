using System;
using System.Data;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.DbContexts
{
    public partial class AddAppRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.AddColumn<Guid>(
                name: "SubjectId",
                schema: "Security",
                table: "AspNetUser",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
            migrationBuilder.AddUniqueConstraint("UC_SubjectId", "AspNetUser", "SubjectId", "Security");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectId",
                schema: "Security",
                table: "AspNetUser");
        }
    }
}
