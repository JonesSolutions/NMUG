using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NMUG.Data.Migrations
{
    public partial class whateverjacobdidithink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Membership");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Type",
                table: "Membership",
                nullable: false,
                defaultValue: false);
        }
    }
}
