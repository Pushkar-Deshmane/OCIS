using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Omnichannel.Migrations
{
    /// <inheritdoc />
    public partial class SUSIAssitInteraction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FurtherDetails_SubCategories_SubCategoryId",
                table: "FurtherDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_CallReasons_CallReasonId",
                table: "SubCategories");

            migrationBuilder.CreateTable(
                name: "SUSIAssistlineInteractions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CallId = table.Column<long>(type: "bigint", nullable: false),
                    CallReasonId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    FurtherDetailId = table.Column<int>(type: "int", nullable: false),
                    CallDriverId = table.Column<int>(type: "int", nullable: false),
                    InfoToAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QueryStatusId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUSIAssistlineInteractions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SUSIAssistlineInteractions_CallDrivers_CallDriverId",
                        column: x => x.CallDriverId,
                        principalTable: "CallDrivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SUSIAssistlineInteractions_CallReasons_CallReasonId",
                        column: x => x.CallReasonId,
                        principalTable: "CallReasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SUSIAssistlineInteractions_FurtherDetails_FurtherDetailId",
                        column: x => x.FurtherDetailId,
                        principalTable: "FurtherDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SUSIAssistlineInteractions_QueryStatuses_QueryStatusId",
                        column: x => x.QueryStatusId,
                        principalTable: "QueryStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SUSIAssistlineInteractions_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SUSIAssistlineInteractions_CallDriverId",
                table: "SUSIAssistlineInteractions",
                column: "CallDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_SUSIAssistlineInteractions_CallReasonId",
                table: "SUSIAssistlineInteractions",
                column: "CallReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_SUSIAssistlineInteractions_FurtherDetailId",
                table: "SUSIAssistlineInteractions",
                column: "FurtherDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SUSIAssistlineInteractions_QueryStatusId",
                table: "SUSIAssistlineInteractions",
                column: "QueryStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SUSIAssistlineInteractions_SubCategoryId",
                table: "SUSIAssistlineInteractions",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_FurtherDetails_SubCategories_SubCategoryId",
                table: "FurtherDetails",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_CallReasons_CallReasonId",
                table: "SubCategories",
                column: "CallReasonId",
                principalTable: "CallReasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FurtherDetails_SubCategories_SubCategoryId",
                table: "FurtherDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_CallReasons_CallReasonId",
                table: "SubCategories");

            migrationBuilder.DropTable(
                name: "SUSIAssistlineInteractions");

            migrationBuilder.AddForeignKey(
                name: "FK_FurtherDetails_SubCategories_SubCategoryId",
                table: "FurtherDetails",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_CallReasons_CallReasonId",
                table: "SubCategories",
                column: "CallReasonId",
                principalTable: "CallReasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
