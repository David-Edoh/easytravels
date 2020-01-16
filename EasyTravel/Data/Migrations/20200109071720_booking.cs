using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EasyTravel.Data.Migrations
{
    public partial class booking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Age = table.Column<string>(nullable: true),
                    Depature_Time = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Fare = table.Column<string>(nullable: true),
                    First_Name = table.Column<string>(nullable: true),
                    From = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Last_Name = table.Column<string>(nullable: true),
                    Motor_park = table.Column<string>(nullable: true),
                    Payment_Ref = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Prefered_Seat = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    Travel_Date = table.Column<string>(nullable: true),
                    Vehicle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
