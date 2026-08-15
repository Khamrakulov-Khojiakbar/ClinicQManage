using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvangardQManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_roles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_users_UserId",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "userroles");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_RoleId",
                table: "userroles",
                newName: "IX_userroles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userroles",
                table: "userroles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_userroles_roles_RoleId",
                table: "userroles",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userroles_users_UserId",
                table: "userroles",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userroles_roles_RoleId",
                table: "userroles");

            migrationBuilder.DropForeignKey(
                name: "FK_userroles_users_UserId",
                table: "userroles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userroles",
                table: "userroles");

            migrationBuilder.RenameTable(
                name: "userroles",
                newName: "UserRoles");

            migrationBuilder.RenameIndex(
                name: "IX_userroles_RoleId",
                table: "UserRoles",
                newName: "IX_UserRoles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_roles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
