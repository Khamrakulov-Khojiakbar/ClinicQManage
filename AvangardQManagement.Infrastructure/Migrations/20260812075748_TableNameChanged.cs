using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvangardQManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TableNameChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receptions_Users_UserId",
                table: "Receptions");

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
                name: "FK_Users_Rooms_RoomId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receptions",
                table: "Receptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "tickets");

            migrationBuilder.RenameTable(
                name: "Receptions",
                newName: "receptions");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "tables");

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
                name: "IX_Receptions_UserId",
                table: "receptions",
                newName: "IX_receptions_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tickets",
                table: "tickets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_receptions",
                table: "receptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tables",
                table: "tables",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_receptions_Users_UserId",
                table: "receptions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_Users_UserId",
                table: "tickets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_receptions_ReceptionId",
                table: "tickets",
                column: "ReceptionId",
                principalTable: "receptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_tables_RoomId",
                table: "tickets",
                column: "RoomId",
                principalTable: "tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_tables_RoomId",
                table: "Users",
                column: "RoomId",
                principalTable: "tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_receptions_Users_UserId",
                table: "receptions");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_Users_UserId",
                table: "tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_receptions_ReceptionId",
                table: "tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_tables_RoomId",
                table: "tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_tables_RoomId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tickets",
                table: "tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_receptions",
                table: "receptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tables",
                table: "tables");

            migrationBuilder.RenameTable(
                name: "tickets",
                newName: "Tickets");

            migrationBuilder.RenameTable(
                name: "receptions",
                newName: "Receptions");

            migrationBuilder.RenameTable(
                name: "tables",
                newName: "Rooms");

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
                name: "IX_receptions_UserId",
                table: "Receptions",
                newName: "IX_Receptions_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receptions",
                table: "Receptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receptions_Users_UserId",
                table: "Receptions",
                column: "UserId",
                principalTable: "Users",
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
                name: "FK_Users_Rooms_RoomId",
                table: "Users",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
