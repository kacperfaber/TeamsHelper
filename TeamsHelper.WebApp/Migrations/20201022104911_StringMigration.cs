using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamsHelper.WebApp.Migrations
{
    public partial class StringMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authorizations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessToken = table.Column<string>(nullable: true),
                    RenewToken = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authorizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoogleCalendars",
                columns: table => new
                {
                    CalendarId = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoogleCalendars", x => x.CalendarId);
                });

            migrationBuilder.CreateTable(
                name: "GoogleEvents",
                columns: table => new
                {
                    EventId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoogleEvents", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "TeamsEvents",
                columns: table => new
                {
                    EventId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsEvents", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    GoogleAuthorizationId = table.Column<string>(nullable: true),
                    MicrosoftAuthorizationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Authorizations_GoogleAuthorizationId",
                        column: x => x.GoogleAuthorizationId,
                        principalTable: "Authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Authorizations_MicrosoftAuthorizationId",
                        column: x => x.MicrosoftAuthorizationId,
                        principalTable: "Authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meets",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    GeneratedAt = table.Column<DateTime>(nullable: false),
                    ScheduledAt = table.Column<DateTime>(nullable: false),
                    GoogleEventId = table.Column<string>(nullable: true),
                    TeamsEventId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meets_GoogleEvents_GoogleEventId",
                        column: x => x.GoogleEventId,
                        principalTable: "GoogleEvents",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meets_TeamsEvents_TeamsEventId",
                        column: x => x.TeamsEventId,
                        principalTable: "TeamsEvents",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Days_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DayId = table.Column<string>(nullable: true),
                    TeamsEventId = table.Column<string>(nullable: true),
                    GoogleEventId = table.Column<string>(nullable: true),
                    GeneratedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Days_DayId",
                        column: x => x.DayId,
                        principalTable: "Days",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_GoogleEvents_GoogleEventId",
                        column: x => x.GoogleEventId,
                        principalTable: "GoogleEvents",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_TeamsEvents_TeamsEventId",
                        column: x => x.TeamsEventId,
                        principalTable: "TeamsEvents",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Days_OwnerId",
                table: "Days",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_DayId",
                table: "Events",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_GoogleEventId",
                table: "Events",
                column: "GoogleEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_TeamsEventId",
                table: "Events",
                column: "TeamsEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Meets_GoogleEventId",
                table: "Meets",
                column: "GoogleEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Meets_TeamsEventId",
                table: "Meets",
                column: "TeamsEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GoogleAuthorizationId",
                table: "Users",
                column: "GoogleAuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MicrosoftAuthorizationId",
                table: "Users",
                column: "MicrosoftAuthorizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "GoogleCalendars");

            migrationBuilder.DropTable(
                name: "Meets");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "GoogleEvents");

            migrationBuilder.DropTable(
                name: "TeamsEvents");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Authorizations");
        }
    }
}
