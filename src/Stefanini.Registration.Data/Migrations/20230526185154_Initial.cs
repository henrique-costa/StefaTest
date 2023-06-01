using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Stefanini.Registration.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: true, defaultValue: true),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    AvailableSeats = table.Column<int>(type: "INTEGER", nullable: false),
                    EventLocationId = table.Column<int>(type: "INTEGER", nullable: true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: true, defaultValue: true),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_events_locations_EventLocationId",
                        column: x => x.EventLocationId,
                        principalTable: "locations",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "locations",
                columns: new[] { "Id", "City", "State" },
                values: new object[,]
                {
                    { 1, "Horseshoe Bay", "Texas" },
                    { 2, "Moab", "Utah" },
                    { 3, "Gilford", "New Hampshire" },
                    { 4, "Las Vegas", "Nevada" }
                });

            migrationBuilder.InsertData(
                table: "events",
                columns: new[] { "Id", "AvailableSeats", "Description", "EventLocationId", "Name" },
                values: new object[,]
                {
                    { 1, 5, "ADVENTURE IS BIGGER IN TEXAS", 1, "Texas Event" },
                    { 2, 5, "MIGHT AS WELL BE DRIVING ON MARS", 2, "Moab Event" },
                    { 3, 5, "OVER RUGGED HILLS & THROUGH DENSE WOODS", 3, "New Hampshire Event" },
                    { 4, 5, "UNFORGIVING ROCKY DESERT LANDCAPE", 4, "Nevada Event" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_events_EventLocationId",
                table: "events",
                column: "EventLocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "locations");
        }
    }
}
