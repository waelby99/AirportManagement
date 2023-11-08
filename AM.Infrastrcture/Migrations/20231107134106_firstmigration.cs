using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastrcture.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyPlanes",
                columns: table => new
                {
                    PlaneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaneType = table.Column<int>(type: "int", nullable: false),
                    ManufactureDate = table.Column<DateTime>(type: "date", nullable: false),
                    PlaneCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyPlanes", x => x.PlaneId);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    PassengerNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PassFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PassLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    TelNumber = table.Column<int>(type: "int", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.PassengerNumber);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirlineLogo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FlightDate = table.Column<DateTime>(type: "date", nullable: false),
                    EstimatedDuration = table.Column<int>(type: "int", nullable: false),
                    EffectiveArrival = table.Column<DateTime>(type: "date", nullable: false),
                    Departure = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PlaneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flights_MyPlanes_PlaneId",
                        column: x => x.PlaneId,
                        principalTable: "MyPlanes",
                        principalColumn: "PlaneId");
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    PassengerNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Function = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployementDate = table.Column<DateTime>(type: "date", nullable: false),
                    Salary = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.PassengerNumber);
                    table.ForeignKey(
                        name: "FK_Staffs_Passengers_PassengerNumber",
                        column: x => x.PassengerNumber,
                        principalTable: "Passengers",
                        principalColumn: "PassengerNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Travellers",
                columns: table => new
                {
                    PassengerNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HealthInformation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travellers", x => x.PassengerNumber);
                    table.ForeignKey(
                        name: "FK_Travellers_Passengers_PassengerNumber",
                        column: x => x.PassengerNumber,
                        principalTable: "Passengers",
                        principalColumn: "PassengerNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MyReservation",
                columns: table => new
                {
                    FlightsFlightId = table.Column<int>(type: "int", nullable: false),
                    PassengersPassengerNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyReservation", x => new { x.FlightsFlightId, x.PassengersPassengerNumber });
                    table.ForeignKey(
                        name: "FK_MyReservation_Flights_FlightsFlightId",
                        column: x => x.FlightsFlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyReservation_Passengers_PassengersPassengerNumber",
                        column: x => x.PassengersPassengerNumber,
                        principalTable: "Passengers",
                        principalColumn: "PassengerNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PlaneId",
                table: "Flights",
                column: "PlaneId");

            migrationBuilder.CreateIndex(
                name: "IX_MyReservation_PassengersPassengerNumber",
                table: "MyReservation",
                column: "PassengersPassengerNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyReservation");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Travellers");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "MyPlanes");
        }
    }
}
