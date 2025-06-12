using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserRegistration.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailOtpField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Otps",
                newName: "IcNumber");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Otps",
                newName: "PhoneOtp");

            migrationBuilder.AddColumn<int>(
                name: "EmailOtp",
                table: "Otps",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "IcNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmailOtp",
                table: "Otps");

            migrationBuilder.RenameColumn(
                name: "PhoneOtp",
                table: "Otps",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "IcNumber",
                table: "Otps",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }
    }
}
