using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.DbContexts
{
    public partial class AddMultiTenantUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.AddColumn<Guid>(
                name: "Tenant",
                schema: "Security",
                table: "AspNetUser",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tenant",
                schema: "Security",
                table: "AspNetUser");
        }
    }
}
