using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Pseudo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.CheckConstraint("CK_Email", "[Email] LIKE '%@%.%'");
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Email", "Firstname", "Lastname", "Password", "Phone", "Pseudo", "Role" },
                values: new object[,]
                {
                    { 1, "jeremy.bazin@email.com", null, null, "Test123=", null, "rains-", "admin" },
                    { 2, "bob.martin@email.com", null, null, "5Gh#zBvKw3PxYrE", null, "MidnightWolf", "user" },
                    { 3, "charlie.nguyen@email.com", null, null, "fT7#eRm2QxLz9Dy$", null, "GalacticNinja", "user" },
                    { 4, "david.lee@email.com", null, null, "V6b$UwPcNz @hM8xK", null, "DragonSlayer", "user" },
                    { 5, "emma.garcia@email.com", null, null, "aH5%kXjL9$qBm2W", null, "PixelPrincess", "user" },
                    { 6, "frank.chen@email.com", null, null, "qJ9@fM8cWu5$xLrE", null, "PhantomGamer", "user" },
                    { 7, "grace.wong@email.com", null, null, "7Km&zRb#vGy2hNj", null, "ElectricNoodle", "user" },
                    { 8, "henry.zhang@email.com", null, null, "T4c#nSv@wGj2RkF", null, "MoonlightRider", "user" },
                    { 9, "isabella.lopez@email.com", null, null, "H8f$kL3q#sVp9Xy", null, "GoldenPhoenix", "user" },
                    { 10, "jack.kim@email.com", null, null, "3ZgY*6tLx#pVfDhN", null, "StormChaser", "user" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                table: "users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
