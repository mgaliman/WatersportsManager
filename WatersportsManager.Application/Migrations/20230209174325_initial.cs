using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WatersportsManager.Application.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Camp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriorityTpes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriorityTpes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSkipper = table.Column<bool>(type: "bit", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Person_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    TimeTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prices_TimeTypes_TimeTypeId",
                        column: x => x.TimeTypeId,
                        principalTable: "TimeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    PriorityTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_PriorityTpes_PriorityTypeId",
                        column: x => x.PriorityTypeId,
                        principalTable: "PriorityTpes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoatType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Registration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Length = table.Column<double>(type: "float", nullable: true),
                    MaxCapacity = table.Column<int>(type: "int", nullable: true),
                    HorsePower = table.Column<int>(type: "int", nullable: true),
                    FuelPercentage = table.Column<int>(type: "int", nullable: true),
                    LifeJackets = table.Column<int>(type: "int", nullable: true),
                    IsFunctional = table.Column<bool>(type: "bit", nullable: false),
                    PriceId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoatType_Prices_PriceId",
                        column: x => x.PriceId,
                        principalTable: "Prices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    BoatTypeId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_BoatType_BoatTypeId",
                        column: x => x.BoatTypeId,
                        principalTable: "BoatType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservation_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Star = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    ReservationId = table.Column<int>(type: "int", nullable: true),
                    ResevationId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Camp", "City", "Latitude", "Longitude" },
                values: new object[,]
                {
                    { 1, "Amarin", "Rovinj", 45.102400000000003, 13.624499999999999 },
                    { 2, "Veštar", "Rovinj", 45.045000000000002, 13.6778 },
                    { 3, "Vilas", "Rovinj", 45.061999999999998, 13.663500000000001 },
                    { 4, "Lanterna", "Poreč", 45.296999999999997, 13.5944 }
                });

            migrationBuilder.InsertData(
                table: "PriorityTpes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Critical" },
                    { 2, "High" },
                    { 3, "Moderate" },
                    { 4, "Low" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Date", "Description", "Name", "PersonId", "ReservationId", "ResevationId", "Star" },
                values: new object[] { 1, new DateTime(2023, 2, 9, 18, 43, 25, 363, DateTimeKind.Local).AddTicks(3948), "Great boat, it sank during the trip", "Austin22", null, null, 2, 3 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                    { 1, "USER" },
                    { 2, "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "TimeTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "15 Min" },
                    { 2, "30 Min" },
                    { 3, "60 Min" },
                    { 4, "1/2 Day" },
                    { 5, "1 Day" },
                    { 6, "Sunset" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Email", "FirstName", "IsSkipper", "LastName", "LocationId", "Password", "RoleId", "Token", "Username" },
                values: new object[,]
                {
                    { 1, "dinop@gmail.com", "Dino", true, "Pejić", 1, "cc/fPftYw6FMM2JUEAwTCVWTbkduQUB/OGjg6fBq24KRtcVg", 1, "", "dpejic" },
                    { 2, "lukas@gmail.com", "Luka", true, "Simić", 2, "+0NdS3qrFh/2fG4DjeVv+0f8Mmjz2qUZcpUsmJo093i3JHMG", 2, "", "lsimic" },
                    { 3, "markog@gmail.com", "Marko", false, "Galiman", null, "+ISSutLrMesoLKQdNXlR3LMGD2AqRLN9Y9gjaN4G8mmZ9xKI", 2, "", "mgaliman" },
                    { 4, "iivic@gmail.com", "Ivo", false, "Ivic", null, "2brs42UnA7pVKmMkONMmlfRGXbC7zjgRi0QVK+KuLDjFfoI3", 1, "", "iivic" },
                    { 5, "pperic@gmail.com", "Pero", false, "Peric", null, "XN9RParphd4gb4HFklcrcCxUlW6r2Xgf2znx20+VdL0Ozpuw", 1, "", "pperic" },
                    { 6, "aporopat@gmail.com", "Anthony", true, "Poropat", null, "Xw6Tap8f0WIO0bywoBP3CYkVOOQPT/tOTiKN2SI4YbtdvFVL", 2, "", "aporopat" },
                    { 7, "mpoljak@gmail.com", "Matia", false, "Poljak", null, "+ISSutLrMesoLKQdNXlR3LMGD2AqRLN9Y9gjaN4G8mmZ9xKI", 1, "", "mpoljak" }
                });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "TimeTypeId", "Value" },
                values: new object[,]
                {
                    { 1, 1, 50 },
                    { 2, 2, 70 },
                    { 3, 3, 100 },
                    { 4, 4, 70 },
                    { 5, 5, 120 },
                    { 6, 6, 150 },
                    { 7, 4, 150 },
                    { 8, 5, 200 }
                });

            migrationBuilder.InsertData(
                table: "BoatType",
                columns: new[] { "Id", "FuelPercentage", "HorsePower", "IsFunctional", "Length", "LifeJackets", "MaxCapacity", "Name", "PriceId", "Registration" },
                values: new object[,]
                {
                    { 1, 100, 5, true, 6.0, 5, 5, "Pasara", 5, "RV324" },
                    { 2, 100, 5, true, 6.0, 5, 5, "Pasara", 4, "RV372" },
                    { 3, 100, 5, true, 6.0, 5, 5, "Pasara", 4, "RV826" },
                    { 4, 100, 5, true, 6.0, 5, 5, "Pasara", 5, "RV437" },
                    { 5, 100, 120, true, 6.75, 10, 8, "QS 675", 7, "RV652" },
                    { 6, 100, 100, true, 6.0, 7, 5, "QS 600", 5, "RV354" },
                    { 7, 70, 60, false, 5.0, 5, 5, "Fisher", 5, "RV917" }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "Description", "PersonId", "PriorityTypeId", "Title" },
                values: new object[,]
                {
                    { 1, "Fix Jet Ski", 1, 1, "Jet Ski problem" },
                    { 2, "Need more paper", 2, 3, "Paper problem" },
                    { 3, "Need more gasoline", 3, 2, "Gasoline" },
                    { 4, "Need to check money count", 5, 4, "Check register" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Date", "Description", "Name", "PersonId", "ReservationId", "ResevationId", "Star" },
                values: new object[,]
                {
                    { 2, new DateTime(2023, 2, 9, 18, 43, 25, 363, DateTimeKind.Local).AddTicks(3952), "Akward service", "Mirko66", 1, null, 1, 1 },
                    { 3, new DateTime(2023, 2, 9, 18, 43, 25, 363, DateTimeKind.Local).AddTicks(3954), "Good service", "Marin28", 3, null, 3, 2 },
                    { 4, new DateTime(2023, 2, 9, 18, 43, 25, 363, DateTimeKind.Local).AddTicks(3956), "Everything was awesome", "Peter55", 5, null, 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "BoatTypeId", "Date", "IsPaid", "LocationId", "PersonId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 2, 9, 18, 43, 25, 363, DateTimeKind.Local).AddTicks(3801), true, 1, 1 },
                    { 2, 2, new DateTime(2023, 2, 9, 18, 43, 25, 363, DateTimeKind.Local).AddTicks(3845), false, 2, 2 },
                    { 3, 3, new DateTime(2023, 2, 9, 18, 43, 25, 363, DateTimeKind.Local).AddTicks(3847), false, 3, 3 },
                    { 4, 4, new DateTime(2023, 2, 9, 18, 43, 25, 363, DateTimeKind.Local).AddTicks(3849), true, 4, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoatType_PriceId",
                table: "BoatType",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_LocationId",
                table: "Person",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_RoleId",
                table: "Person",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_TimeTypeId",
                table: "Prices",
                column: "TimeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_PersonId",
                table: "Reports",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_PriorityTypeId",
                table: "Reports",
                column: "PriorityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_BoatTypeId",
                table: "Reservation",
                column: "BoatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_LocationId",
                table: "Reservation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_PersonId",
                table: "Reservation",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PersonId",
                table: "Reviews",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReservationId",
                table: "Reviews",
                column: "ReservationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "PriorityTpes");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "BoatType");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "TimeTypes");
        }
    }
}
