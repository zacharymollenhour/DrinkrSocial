using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkrSocial.Persistence.Migrations
{
    public partial class Tavern_TavernOperatingHours_DayInWeek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserRoles");

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateNameEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateNameES = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TavernHappyHours",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TavernId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TavernHappyHours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TavernOperatingHours",
                columns: table => new
                {
                    OperatingHoursId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TavernId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OpenTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CloseTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TavernOperatingHours", x => new { x.DayId, x.OperatingHoursId, x.TavernId });
                });

            migrationBuilder.CreateTable(
                name: "Taverns",
                columns: table => new
                {
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taverns", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "DayInWeek",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TavernOperatingHoursDayId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TavernOperatingHoursOperatingHoursId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TavernOperatingHoursTavernId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayInWeek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayInWeek_TavernOperatingHours_TavernOperatingHoursDayId_TavernOperatingHoursOperatingHoursId_TavernOperatingHoursTavernId",
                        columns: x => new { x.TavernOperatingHoursDayId, x.TavernOperatingHoursOperatingHoursId, x.TavernOperatingHoursTavernId },
                        principalTable: "TavernOperatingHours",
                        principalColumns: new[] { "DayId", "OperatingHoursId", "TavernId" });
                });

            migrationBuilder.InsertData(
                table: "DayInWeek",
                columns: new[] { "Id", "DayName", "TavernOperatingHoursDayId", "TavernOperatingHoursOperatingHoursId", "TavernOperatingHoursTavernId" },
                values: new object[,]
                {
                    { new Guid("0c6b2c73-d6b0-4f21-bb88-b55004120395"), "Friday", null, null, null },
                    { new Guid("1c326e9e-7a39-4c89-a755-dbe2dc63a428"), "Wednesday", null, null, null },
                    { new Guid("38799236-31e9-48e9-af78-970fc4f2ebf7"), "Saturday", null, null, null },
                    { new Guid("4f9bc7b1-fed3-4719-a7a9-e99d1b436202"), "Sunday", null, null, null },
                    { new Guid("721e9a99-b783-4dde-95fd-ee1baabd7f1c"), "Tuesday", null, null, null },
                    { new Guid("88ea84eb-8858-430d-a076-1c3d5251e0b9"), "Thursday", null, null, null },
                    { new Guid("b372a17b-1d6a-4944-bd40-1a077a303acd"), "Monday", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Id", "StateNameEN", "StateNameES" },
                values: new object[] { new Guid("122919d2-4235-4764-b995-409c64353208"), "Iowa", "Iowa" });

            migrationBuilder.InsertData(
                table: "TavernHappyHours",
                columns: new[] { "Id", "Day", "EndTime", "StartTime", "TavernId" },
                values: new object[] { new Guid("d7b563d0-1900-4e96-87b8-1040a9a606e1"), 0, "12:00 P.M", "8:00 A.M", new Guid("6e5d8fa8-fa96-419f-9c07-3e05b96b087e") });

            migrationBuilder.InsertData(
                table: "TavernOperatingHours",
                columns: new[] { "DayId", "OperatingHoursId", "TavernId", "CloseTime", "OpenTime" },
                values: new object[,]
                {
                    { new Guid("0c6b2c73-d6b0-4f21-bb88-b55004120395"), new Guid("b7c32dbe-5081-4004-8087-69f9c1101f01"), new Guid("6e5d8fa8-fa96-419f-9c07-3e05b96b087e"), "12:00 P.M", "8:00 A.M" },
                    { new Guid("1c326e9e-7a39-4c89-a755-dbe2dc63a428"), new Guid("56e510d6-4d4b-4596-926d-2f751dcb27b3"), new Guid("6e5d8fa8-fa96-419f-9c07-3e05b96b087e"), "12:00 P.M", "8:00 A.M" },
                    { new Guid("38799236-31e9-48e9-af78-970fc4f2ebf7"), new Guid("68c75036-5aaf-4937-ad54-f36d524e8e32"), new Guid("6e5d8fa8-fa96-419f-9c07-3e05b96b087e"), "12:00 P.M", "8:00 A.M" },
                    { new Guid("4f9bc7b1-fed3-4719-a7a9-e99d1b436202"), new Guid("a9705af2-48ff-40e1-a688-c61990ab7d86"), new Guid("6e5d8fa8-fa96-419f-9c07-3e05b96b087e"), "12:00 P.M", "8:00 A.M" },
                    { new Guid("721e9a99-b783-4dde-95fd-ee1baabd7f1c"), new Guid("dfe18a72-d95e-4936-9d67-1203fe5a344e"), new Guid("6e5d8fa8-fa96-419f-9c07-3e05b96b087e"), "12:00 P.M", "8:00 A.M" },
                    { new Guid("88ea84eb-8858-430d-a076-1c3d5251e0b9"), new Guid("385d4334-ea67-4887-81de-b4a7caa61d94"), new Guid("6e5d8fa8-fa96-419f-9c07-3e05b96b087e"), "12:00 P.M", "8:00 A.M" },
                    { new Guid("b372a17b-1d6a-4944-bd40-1a077a303acd"), new Guid("b1784642-2fa7-41b5-9f3b-6124fb91692f"), new Guid("6e5d8fa8-fa96-419f-9c07-3e05b96b087e"), "12:00 P.M", "8:00 A.M" }
                });

            migrationBuilder.InsertData(
                table: "Taverns",
                columns: new[] { "StateId", "AddressLine1", "AddressLine2", "City", "Country", "Id", "Name", "PhoneNumber", "PostalCode" },
                values: new object[] { new Guid("122919d2-4235-4764-b995-409c64353208"), "1886 Hansel Drive", null, "Dubuque", "USA", new Guid("00000000-0000-0000-0000-000000000000"), "Zachs Bar", "904-553-2614", "52002" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6e5d8fa8-fa96-419f-9c07-3e05b96b087e"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 180, 5, 178, 244, 35, 158, 87, 42, 238, 39, 231, 109, 225, 90, 193, 140, 161, 224, 168, 242, 54, 13, 190, 186, 96, 190, 101, 225, 220, 170, 74, 232, 60, 170, 12, 41, 107, 200, 181, 152, 87, 0, 209, 197, 19, 96, 144, 219, 176, 246, 220, 81, 223, 213, 34, 18, 39, 89, 62, 125, 18, 164, 200, 107 }, new byte[] { 124, 125, 90, 142, 138, 226, 204, 31, 28, 116, 18, 193, 197, 250, 176, 161, 35, 31, 141, 230, 150, 178, 5, 99, 250, 50, 88, 202, 235, 167, 11, 112, 143, 146, 23, 85, 220, 201, 61, 180, 169, 45, 61, 22, 22, 85, 117, 54, 115, 235, 108, 215, 206, 231, 229, 238, 209, 201, 141, 143, 77, 158, 56, 253, 100, 0, 2, 8, 98, 116, 15, 185, 130, 126, 58, 91, 6, 45, 180, 202, 38, 251, 113, 56, 84, 103, 179, 195, 131, 185, 183, 8, 252, 192, 167, 46, 37, 105, 40, 88, 173, 143, 221, 83, 56, 230, 20, 85, 164, 25, 135, 69, 161, 154, 236, 144, 85, 96, 211, 199, 169, 237, 232, 89, 218, 187, 110, 209 } });

            migrationBuilder.CreateIndex(
                name: "IX_DayInWeek_TavernOperatingHoursDayId_TavernOperatingHoursOperatingHoursId_TavernOperatingHoursTavernId",
                table: "DayInWeek",
                columns: new[] { "TavernOperatingHoursDayId", "TavernOperatingHoursOperatingHoursId", "TavernOperatingHoursTavernId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayInWeek");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "TavernHappyHours");

            migrationBuilder.DropTable(
                name: "Taverns");

            migrationBuilder.DropTable(
                name: "TavernOperatingHours");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserRoles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6e5d8fa8-fa96-419f-9c07-3e05b96b087e"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 19, 165, 75, 209, 114, 57, 85, 123, 112, 67, 188, 117, 117, 129, 108, 95, 241, 199, 89, 249, 177, 83, 64, 166, 69, 95, 175, 77, 248, 223, 36, 121, 252, 201, 244, 221, 83, 78, 254, 79, 198, 231, 50, 158, 10, 177, 225, 185, 195, 183, 197, 198, 60, 169, 159, 203, 114, 132, 44, 234, 136, 212, 175, 220 }, new byte[] { 249, 254, 11, 38, 155, 68, 48, 169, 123, 7, 3, 229, 42, 167, 236, 234, 33, 51, 41, 21, 87, 248, 249, 144, 157, 187, 139, 153, 13, 137, 67, 72, 164, 227, 58, 185, 51, 24, 216, 20, 20, 233, 212, 45, 190, 173, 195, 247, 103, 124, 99, 225, 255, 191, 99, 25, 33, 160, 145, 213, 75, 191, 7, 10, 122, 142, 150, 142, 5, 186, 205, 61, 204, 252, 111, 246, 87, 71, 0, 229, 228, 80, 168, 100, 98, 24, 141, 111, 145, 181, 56, 207, 172, 228, 190, 123, 179, 136, 69, 63, 146, 234, 193, 50, 156, 119, 116, 114, 96, 129, 90, 182, 107, 240, 202, 207, 248, 12, 5, 76, 49, 105, 145, 227, 176, 253, 162, 72 } });
        }
    }
}
