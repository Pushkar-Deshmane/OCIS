using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Omnichannel.Migrations
{
    /// <inheritdoc />
    public partial class changedCallIDToContactId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CallId",
                table: "SUSIAssistlineInteractions");

            migrationBuilder.AddColumn<Guid>(
                name: "ContactId",
                table: "SUSIAssistlineInteractions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "SUSIAssistlineInteractions");

            migrationBuilder.AddColumn<long>(
                name: "CallId",
                table: "SUSIAssistlineInteractions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
