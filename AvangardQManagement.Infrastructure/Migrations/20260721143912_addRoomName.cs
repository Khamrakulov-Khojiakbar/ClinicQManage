using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvangardQManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addRoomName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_receptions_users_UserId",
                table: "receptions");

            migrationBuilder.DropForeignKey(
                name: "FK_rolePermissions_permissions_PermissionId",
                table: "rolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_rolePermissions_roles_RoleId",
                table: "rolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_receptions_ReceptionId",
                table: "tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_rooms_RoomId",
                table: "tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_users_UserId",
                table: "tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_userRoles_roles_RoleId",
                table: "userRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_userRoles_users_UserId",
                table: "userRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_users_rooms_RoomId",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userRoles",
                table: "userRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tickets",
                table: "tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rooms",
                table: "rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rolePermissions",
                table: "rolePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_receptions",
                table: "receptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_permissions",
                table: "permissions");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "userRoles",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "tickets",
                newName: "Tickets");

            migrationBuilder.RenameTable(
                name: "rooms",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "rolePermissions",
                newName: "RolePermissions");

            migrationBuilder.RenameTable(
                name: "receptions",
                newName: "Receptions");

            migrationBuilder.RenameTable(
                name: "permissions",
                newName: "Permissions");

            migrationBuilder.RenameIndex(
                name: "IX_users_RoomId",
                table: "Users",
                newName: "IX_Users_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_userRoles_RoleId",
                table: "UserRoles",
                newName: "IX_UserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_tickets_UserId",
                table: "Tickets",
                newName: "IX_Tickets_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_tickets_RoomId",
                table: "Tickets",
                newName: "IX_Tickets_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_tickets_ReceptionId",
                table: "Tickets",
                newName: "IX_Tickets_ReceptionId");

            migrationBuilder.RenameIndex(
                name: "IX_rolePermissions_PermissionId",
                table: "RolePermissions",
                newName: "IX_RolePermissions_PermissionId");

            migrationBuilder.RenameIndex(
                name: "IX_receptions_UserId",
                table: "Receptions",
                newName: "IX_Receptions_UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CalledAt",
                table: "Tickets",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedAt",
                table: "Tickets",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RoomName",
                table: "Rooms",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolePermissions",
                table: "RolePermissions",
                columns: new[] { "RoleId", "PermissionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receptions",
                table: "Receptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receptions_Users_UserId",
                table: "Receptions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Permissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Roles_RoleId",
                table: "RolePermissions",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Receptions_ReceptionId",
                table: "Tickets",
                column: "ReceptionId",
                principalTable: "Receptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Rooms_RoomId",
                table: "Tickets",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_UserId",
                table: "Tickets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Rooms_RoomId",
                table: "Users",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receptions_Users_UserId",
                table: "Receptions");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Permissions_PermissionId",
                table: "RolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Roles_RoleId",
                table: "RolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Receptions_ReceptionId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Rooms_RoomId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_UserId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rooms_RoomId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RolePermissions",
                table: "RolePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receptions",
                table: "Receptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "CalledAt",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CompletedAt",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "RoomName",
                table: "Rooms");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "userRoles");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "tickets");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "rooms");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "roles");

            migrationBuilder.RenameTable(
                name: "RolePermissions",
                newName: "rolePermissions");

            migrationBuilder.RenameTable(
                name: "Receptions",
                newName: "receptions");

            migrationBuilder.RenameTable(
                name: "Permissions",
                newName: "permissions");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoomId",
                table: "users",
                newName: "IX_users_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_RoleId",
                table: "userRoles",
                newName: "IX_userRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_UserId",
                table: "tickets",
                newName: "IX_tickets_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_RoomId",
                table: "tickets",
                newName: "IX_tickets_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ReceptionId",
                table: "tickets",
                newName: "IX_tickets_ReceptionId");

            migrationBuilder.RenameIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "rolePermissions",
                newName: "IX_rolePermissions_PermissionId");

            migrationBuilder.RenameIndex(
                name: "IX_Receptions_UserId",
                table: "receptions",
                newName: "IX_receptions_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userRoles",
                table: "userRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_tickets",
                table: "tickets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rooms",
                table: "rooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rolePermissions",
                table: "rolePermissions",
                columns: new[] { "RoleId", "PermissionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_receptions",
                table: "receptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_permissions",
                table: "permissions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_receptions_users_UserId",
                table: "receptions",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rolePermissions_permissions_PermissionId",
                table: "rolePermissions",
                column: "PermissionId",
                principalTable: "permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rolePermissions_roles_RoleId",
                table: "rolePermissions",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_receptions_ReceptionId",
                table: "tickets",
                column: "ReceptionId",
                principalTable: "receptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_rooms_RoomId",
                table: "tickets",
                column: "RoomId",
                principalTable: "rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_users_UserId",
                table: "tickets",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_userRoles_roles_RoleId",
                table: "userRoles",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userRoles_users_UserId",
                table: "userRoles",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_rooms_RoomId",
                table: "users",
                column: "RoomId",
                principalTable: "rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
