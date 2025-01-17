using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackArm.API.Migrations
{
    /// <inheritdoc />
    public partial class databaseUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "WinnerId",
                table: "Fight",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Fight_WinnerId",
                table: "Fight",
                column: "WinnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fight_ArmWrestler_WinnerId",
                table: "Fight",
                column: "WinnerId",
                principalTable: "ArmWrestler",
                principalColumn: "ArmWrestlerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fight_ArmWrestler_WinnerId",
                table: "Fight");

            migrationBuilder.DropIndex(
                name: "IX_Fight_WinnerId",
                table: "Fight");

            migrationBuilder.DropColumn(
                name: "WinnerId",
                table: "Fight");
        }
    }
}
