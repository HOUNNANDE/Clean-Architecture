using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspNetCore.Courses.Section15.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ReceiveNewLetters = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonID);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "CountryName" },
                values: new object[,]
                {
                    { new Guid("23c556ad-28df-45b6-a066-25f80017eb6d"), "Indonesia" },
                    { new Guid("33078766-f09b-4f5b-81b9-567d332ac32f"), "Macedonia" },
                    { new Guid("44456690-ec3b-4b52-8621-71f79712f19a"), "Colombia" },
                    { new Guid("496c2b48-fdf7-4064-8b26-0e60689cbf44"), "Portugal" },
                    { new Guid("77089c9c-29e2-44da-bb96-b279ed51fd4c"), "China" },
                    { new Guid("7b46eb99-c4f0-4f8f-837f-95177b512bb1"), "Russia" },
                    { new Guid("8a02d751-bf41-4601-9694-0b31c8d120b6"), "Papua New Guinea" },
                    { new Guid("c76f4ade-16ee-436e-9115-03f3280fb4b2"), "Costa Rica" },
                    { new Guid("ca6034c4-d106-40a4-b3f7-680268054261"), "Madagascar" },
                    { new Guid("e6e323e6-a122-401f-b3b9-ff7dfc3df3de"), "Philippines" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonID", "Address", "CountryID", "DateOfBirth", "Email", "Gender", "PersonName", "ReceiveNewLetters" },
                values: new object[,]
                {
                    { new Guid("00223335-4cbd-4bad-995a-428246d990aa"), "299 Reindahl Street", new Guid("ca6034c4-d106-40a4-b3f7-680268054261"), new DateTime(1992, 8, 1, 9, 0, 0, 0, DateTimeKind.Local), "cfarryann6@cbslocal.com", "Female", "Clary Farryann", false },
                    { new Guid("05eb218b-6fe2-4b5c-8f9b-acf057ce522e"), "772 Eastwood Park", new Guid("7b46eb99-c4f0-4f8f-837f-95177b512bb1"), new DateTime(2012, 8, 1, 9, 0, 0, 0, DateTimeKind.Local), "djeratt3@homestead.com", "Female", "Dulci Jeratt", false },
                    { new Guid("0a532dfd-6d9c-4639-81d1-06d0740b1393"), "8 Nelson Lane", new Guid("77089c9c-29e2-44da-bb96-b279ed51fd4c"), new DateTime(1992, 8, 1, 9, 0, 0, 0, DateTimeKind.Local), "fmichal7@surveymonkey.com", "Male", "Frederic Michal", true },
                    { new Guid("2ad19535-1ec9-47d0-9264-9a0d67e98ed3"), "98554 Paget Terrace", new Guid("e6e323e6-a122-401f-b3b9-ff7dfc3df3de"), new DateTime(2012, 8, 1, 9, 0, 0, 0, DateTimeKind.Local), "mloisi4@mit.edu", "Female", "Maris Loisi", false },
                    { new Guid("4247b2e5-f1b2-4a15-b8af-abc8d9b6e0ea"), "122 Fulton Terrace", new Guid("8a02d751-bf41-4601-9694-0b31c8d120b6"), new DateTime(1992, 8, 1, 9, 0, 0, 0, DateTimeKind.Local), "kwombwell5@i2i.jp", "Female", "Konstance Wombwell", true },
                    { new Guid("5ff09c86-4eef-455f-8001-69c93da8a34a"), "3 Hayes Street", new Guid("44456690-ec3b-4b52-8621-71f79712f19a"), new DateTime(2004, 8, 1, 9, 0, 0, 0, DateTimeKind.Local), "rtomlett0@gnu.org", "Male", "Rickey Tomlett", true },
                    { new Guid("86e7bdcf-f574-436e-ad94-c851c595db51"), "51 Waubesa Junction", new Guid("33078766-f09b-4f5b-81b9-567d332ac32f"), new DateTime(2002, 8, 1, 9, 0, 0, 0, DateTimeKind.Local), "mmccullen1@sina.com.cn", "Male", "Mattie McCullen", true },
                    { new Guid("895e817b-7510-49e5-833e-758f74604997"), "7 Almo Parkway", new Guid("c76f4ade-16ee-436e-9115-03f3280fb4b2"), new DateTime(1990, 8, 1, 9, 0, 0, 0, DateTimeKind.Local), "cwingatt2@t.co", "Female", "Charlot Wingatt", true },
                    { new Guid("c34e4488-5f88-4291-9e2f-f534cd5de9e9"), "7524 Linden Lane", new Guid("23c556ad-28df-45b6-a066-25f80017eb6d"), new DateTime(1993, 8, 1, 9, 0, 0, 0, DateTimeKind.Local), "gkuschek9@icq.com", "Female", "Gianna Kuschek", true },
                    { new Guid("e9745dd4-859d-4665-bd96-a8a68811c070"), "65 Londonderry Place", new Guid("496c2b48-fdf7-4064-8b26-0e60689cbf44"), new DateTime(1991, 8, 1, 9, 0, 0, 0, DateTimeKind.Local), "cgravells8@shinystat.com", "Female", "Cicely Gravells", false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
