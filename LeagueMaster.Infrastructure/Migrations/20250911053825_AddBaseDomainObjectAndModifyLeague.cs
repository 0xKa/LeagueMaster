using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeagueMaster.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseDomainObjectAndModifyLeague : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "Leagues",
            //    keyColumn: "Id",
            //    keyValue: 1);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Leagues",
                type: "datetime2",
                nullable: false,
                defaultValue: DateTime.Now);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Leagues",
                type: "datetime2",
                nullable: false,
                defaultValue: DateTime.Now);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Leagues",
                type: "datetime2",
                nullable: false,
                defaultValue: DateTime.Now);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Leagues");

        //    migrationBuilder.InsertData(
        //        table: "Leagues",
        //        columns: new[] { "Id", "Country", "CreatedAt", "Name", "Season" },
        //        values: new object[] { 1, "Earth", new DateTime(2025, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reda League", "2025" });
        }
    }
}
