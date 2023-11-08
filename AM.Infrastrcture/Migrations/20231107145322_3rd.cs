﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastrcture.Migrations
{
    /// <inheritdoc />
    public partial class _3rd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyReservation");

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    PassengerFk = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FlightFk = table.Column<int>(type: "int", nullable: false),
                    Prix = table.Column<double>(type: "float", nullable: false),
                    Siege = table.Column<int>(type: "int", nullable: false),
                    Vip = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => new { x.FlightFk, x.PassengerFk });
                    table.ForeignKey(
                        name: "FK_Ticket_Flights_FlightFk",
                        column: x => x.FlightFk,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Passengers_PassengerFk",
                        column: x => x.PassengerFk,
                        principalTable: "Passengers",
                        principalColumn: "PassengerNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PassengerFk",
                table: "Ticket",
                column: "PassengerFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");

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
                name: "IX_MyReservation_PassengersPassengerNumber",
                table: "MyReservation",
                column: "PassengersPassengerNumber");
        }
    }
}
