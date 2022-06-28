using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZTM.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<int>(type: "INTEGER", nullable: false),
                    Surname = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DriverId = table.Column<int>(type: "INTEGER", nullable: false),
                    Line = table.Column<int>(type: "INTEGER", nullable: false),
                    Destination = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bus_Driver_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Driver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Side = table.Column<bool>(type: "INTEGER", nullable: false),
                    BusId = table.Column<int>(type: "INTEGER", nullable: true),
                    BusId1 = table.Column<int>(type: "INTEGER", nullable: true),
                    DriverId = table.Column<int>(type: "INTEGER", nullable: true),
                    StopId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stop_Bus_BusId",
                        column: x => x.BusId,
                        principalTable: "Bus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Stop_Bus_BusId1",
                        column: x => x.BusId1,
                        principalTable: "Bus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Stop_Driver_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Driver",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Stop_Stop_StopId",
                        column: x => x.StopId,
                        principalTable: "Stop",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Timetable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArriveTime = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    LeaveTime = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    DayOfWeek = table.Column<int>(type: "INTEGER", nullable: false),
                    LineId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timetable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timetable_Bus_LineId",
                        column: x => x.LineId,
                        principalTable: "Bus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StopTimetable",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "INTEGER", nullable: false),
                    TimetablesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StopTimetable", x => new { x.ScheduleId, x.TimetablesId });
                    table.ForeignKey(
                        name: "FK_StopTimetable_Stop_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Stop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StopTimetable_Timetable_TimetablesId",
                        column: x => x.TimetablesId,
                        principalTable: "Timetable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bus_DriverId",
                table: "Bus",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Stop_BusId",
                table: "Stop",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_Stop_BusId1",
                table: "Stop",
                column: "BusId1");

            migrationBuilder.CreateIndex(
                name: "IX_Stop_DriverId",
                table: "Stop",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Stop_StopId",
                table: "Stop",
                column: "StopId");

            migrationBuilder.CreateIndex(
                name: "IX_StopTimetable_TimetablesId",
                table: "StopTimetable",
                column: "TimetablesId");

            migrationBuilder.CreateIndex(
                name: "IX_Timetable_LineId",
                table: "Timetable",
                column: "LineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StopTimetable");

            migrationBuilder.DropTable(
                name: "Stop");

            migrationBuilder.DropTable(
                name: "Timetable");

            migrationBuilder.DropTable(
                name: "Bus");

            migrationBuilder.DropTable(
                name: "Driver");
        }
    }
}
