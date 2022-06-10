using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkrSocial.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TokenRefreshs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenRefreshs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    EmailConfirmationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmedCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetPasswordCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("43db034a-98cc-42ee-8fff-c57016484f4d"), "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "EmailConfirmationCode", "EmailConfirmed", "EmailConfirmedCode", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PostalCode", "ResetPasswordCode", "UserName" },
                values: new object[] { new Guid("6e5d8fa8-fa96-419f-9c07-3e05b96b087e"), "defaultadmin@gmail.com", null, true, null, "Default", "Admin", new byte[] { 19, 165, 75, 209, 114, 57, 85, 123, 112, 67, 188, 117, 117, 129, 108, 95, 241, 199, 89, 249, 177, 83, 64, 166, 69, 95, 175, 77, 248, 223, 36, 121, 252, 201, 244, 221, 83, 78, 254, 79, 198, 231, 50, 158, 10, 177, 225, 185, 195, 183, 197, 198, 60, 169, 159, 203, 114, 132, 44, 234, 136, 212, 175, 220 }, new byte[] { 249, 254, 11, 38, 155, 68, 48, 169, 123, 7, 3, 229, 42, 167, 236, 234, 33, 51, 41, 21, 87, 248, 249, 144, 157, 187, 139, 153, 13, 137, 67, 72, 164, 227, 58, 185, 51, 24, 216, 20, 20, 233, 212, 45, 190, 173, 195, 247, 103, 124, 99, 225, 255, 191, 99, 25, 33, 160, 145, 213, 75, 191, 7, 10, 122, 142, 150, 142, 5, 186, 205, 61, 204, 252, 111, 246, 87, 71, 0, 229, 228, 80, 168, 100, 98, 24, 141, 111, 145, 181, 56, 207, 172, 228, 190, 123, 179, 136, 69, 63, 146, 234, 193, 50, 156, 119, 116, 114, 96, 129, 90, 182, 107, 240, 202, 207, 248, 12, 5, 76, 49, 105, 145, 227, 176, 253, 162, 72 }, "52002", null, "admin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "Id" },
                values: new object[] { new Guid("43db034a-98cc-42ee-8fff-c57016484f4d"), new Guid("6e5d8fa8-fa96-419f-9c07-3e05b96b087e"), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TokenRefreshs");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
