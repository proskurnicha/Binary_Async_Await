using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Binary_Project_Structure_DataAccess.Migrations
{
    public partial class Added_seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Stewardess",
                columns: new[] { "Id", "CrewId", "DateBirth", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Natali", "Sidorova" },
                    { 2, null, new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kate", "Petrova" },
                    { 3, null, new DateTime(1993, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tanya", "Durova" }
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
                values: new object[] { 1, 1, 1, new DateTime(2018, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Departure",
                columns: new[] { "Id", "AircraftId", "CrewId", "DepartureTime", "FlightId" },
                values: new object[] { 3, 1, 3, new DateTime(2018, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 });

            migrationBuilder.InsertData(
                table: "Departure",
                columns: new[] { "Id", "AircraftId", "CrewId", "DepartureTime", "FlightId" },
                values: new object[] { 2, 2, 2, new DateTime(2018, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departure",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departure",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departure",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pilot",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pilot",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stewardess",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stewardess",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stewardess",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ticket",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ticket",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ticket",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Aircraft",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Aircraft",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Crew",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Crew",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Crew",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flight",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pilot",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TypeAircraft",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TypeAircraft",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
