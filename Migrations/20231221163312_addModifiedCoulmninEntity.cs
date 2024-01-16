using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SessionNine.Migrations
{
    /// <inheritdoc />
    public partial class addModifiedCoulmninEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataModified",
                table: "Security",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataModified",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataModified",
                table: "Security");

            migrationBuilder.DropColumn(
                name: "DataModified",
                table: "Product");
        }
    }
}
