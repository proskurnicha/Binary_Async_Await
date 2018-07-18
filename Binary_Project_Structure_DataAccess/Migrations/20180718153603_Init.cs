using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Binary_Project_Structure_DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeparturePoint = table.Column<string>(nullable: false),
                    DepartureTime = table.Column<TimeSpan>(nullable: false),
                    ArrivalPoint = table.Column<string>(nullable: false),
                    ArrivalTime = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pilot",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    DateBirth = table.Column<DateTime>(nullable: false),
                    Experience = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeAircraft",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AircraftModel = table.Column<int>(nullable: false),
                    NumberPlaces = table.Column<int>(nullable: false),
                    CarryingCapacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAircraft", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<double>(nullable: false),
                    FlightId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Crew",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PilotId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crew", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crew_Pilot_PilotId",
                        column: x => x.PilotId,
                        principalTable: "Pilot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aircraft",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AircraftName = table.Column<string>(nullable: false),
                    TypeAircraftId = table.Column<int>(nullable: false),
                    DateRelease = table.Column<DateTime>(nullable: false),
                    Lifetime = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircraft", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aircraft_TypeAircraft_TypeAircraftId",
                        column: x => x.TypeAircraftId,
                        principalTable: "TypeAircraft",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stewardess",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    DateBirth = table.Column<DateTime>(nullable: false),
                    CrewId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stewardess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stewardess_Crew_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crew",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departure",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlightId = table.Column<int>(nullable: false),
                    DepartureTime = table.Column<DateTime>(nullable: false),
                    CrewId = table.Column<int>(nullable: false),
                    AircraftId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departure_Aircraft_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircraft",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Departure_Crew_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crew",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Departure_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Flight",
                columns: new[] { "Id", "ArrivalPoint", "ArrivalTime", "DeparturePoint", "DepartureTime" },
                values: new object[,]
                {
                    { 1, "Berlin", new TimeSpan(0, 10, 29, 0, 0), "Kiev", new TimeSpan(0, 4, 46, 0, 0) },
                    { 2, "Riga", new TimeSpan(0, 8, 5, 0, 0), "Kiev", new TimeSpan(0, 11, 30, 0, 0) },
                    { 3, "Brussels", new TimeSpan(0, 3, 15, 0, 0), "Kiev", new TimeSpan(0, 5, 48, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Pilot",
                columns: new[] { "Id", "DateBirth", "Experience", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Ivan", "Ivanov" },
                    { 2, new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Petr", "Petrov" },
                    { 3, new DateTime(1993, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Sidr", "Sidorov" }
                });

            migrationBuilder.InsertData(
                table: "TypeAircraft",
                columns: new[] { "Id", "AircraftModel", "CarryingCapacity", "NumberPlaces" },
                values: new object[,]
                {
                    { 1, 7, 240000, 797 },
                    { 2, 9, 164000, 183 }
                });

            migrationBuilder.InsertData(
                table: "Aircraft",
                columns: new[] { "Id", "AircraftName", "DateRelease", "Lifetime", "TypeAircraftId" },
                values: new object[,]
                {
                    { 1, "Star", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), 1 },
                    { 2, "Cometa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), 2 }
                });

            migrationBuilder.InsertData(
                table: "Crew",
                columns: new[] { "Id", "PilotId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Ticket",
                columns: new[] { "Id", "FlightId", "Price" },
                values: new object[,]
                {
                    { 1, 1, 200.0 },
                    { 2, 2, 300.0 },
                    { 3, 3, 400.0 }
                });

            migrationBuilder.InsertData(
                table: "Departure",
                columns: new[] { "Id", "AircraftId", "CrewId", "DepartureTime", "FlightId" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2018, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 1, 3, new DateTime(2018, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 2, 2, 2, new DateTime(2018, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "Stewardess",
                columns: new[] { "Id", "CrewId", "DateBirth", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Natali", "Sidorova" },
                    { 3, 1, new DateTime(1993, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tanya", "Durova" },
                    { 2, 2, new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kate", "Petrova" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aircraft_TypeAircraftId",
                table: "Aircraft",
                column: "TypeAircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_Crew_PilotId",
                table: "Crew",
                column: "PilotId");

            migrationBuilder.CreateIndex(
                name: "IX_Departure_AircraftId",
                table: "Departure",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_Departure_CrewId",
                table: "Departure",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_Departure_FlightId",
                table: "Departure",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Stewardess_CrewId",
                table: "Stewardess",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_FlightId",
                table: "Ticket",
                column: "FlightId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departure");

            migrationBuilder.DropTable(
                name: "Stewardess");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Aircraft");

            migrationBuilder.DropTable(
                name: "Crew");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "TypeAircraft");

            migrationBuilder.DropTable(
                name: "Pilot");
        }
    }
}
