using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SymJumbles.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IncomingMessage",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountSid = table.Column<string>(nullable: true),
                    ApiVersion = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    From = table.Column<string>(nullable: true),
                    FromCity = table.Column<string>(nullable: true),
                    FromCountry = table.Column<string>(nullable: true),
                    FromState = table.Column<string>(nullable: true),
                    FromZip = table.Column<string>(nullable: true),
                    MessageSid = table.Column<string>(nullable: true),
                    NumMedia = table.Column<string>(nullable: true),
                    NumSegments = table.Column<string>(nullable: true),
                    SmsMessageSid = table.Column<string>(nullable: true),
                    SmsSid = table.Column<string>(nullable: true),
                    SmsStatus = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    ToCity = table.Column<string>(nullable: true),
                    ToCountry = table.Column<string>(nullable: true),
                    ToState = table.Column<string>(nullable: true),
                    ToZip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomingMessage", x => x.ID);
                });

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
                name: "IncomingMessage");

            migrationBuilder.DropTable(
                name: "Jumble");
        }
    }
}
