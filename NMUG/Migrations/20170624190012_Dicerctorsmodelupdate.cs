using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NMUG.Migrations
{
    public partial class Dicerctorsmodelupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Directors");

            migrationBuilder.AddColumn<bool>(
                name: "IsCurrent",
                table: "Membership",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Membership",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Biography",
                table: "Directors",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RoleDescription",
                table: "Directors",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Membership",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Membership",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Membership",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCurrent",
                table: "Membership");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Membership");

            migrationBuilder.DropColumn(
                name: "Biography",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "RoleDescription",
                table: "Directors");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Directors",
                maxLength: 75,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Membership",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Membership",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Membership",
                nullable: true);
        }
    }
}
