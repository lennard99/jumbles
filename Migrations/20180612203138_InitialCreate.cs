using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace myApp1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jumble",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MessageIn = table.Column<string>(nullable: true),
                    MessageOut = table.Column<string>(nullable: true),
                    NumberFrom = table.Column<string>(nullable: true),
                    NumberTo = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jumble", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jumble");
        }
    }
}
