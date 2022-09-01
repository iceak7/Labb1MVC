using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb1MVC.Migrations
{
    public partial class InititalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    TotalNumberOfBooks = table.Column<int>(nullable: false),
                    NumberOfBooksInStock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    PhoneNr = table.Column<string>(nullable: false),
                    City = table.Column<string>(maxLength: 30, nullable: false),
                    Address = table.Column<string>(maxLength: 80, nullable: false),
                    ZipCode = table.Column<string>(maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "BookBorrows",
                columns: table => new
                {
                    BookBorrowId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BorrowDate = table.Column<DateTime>(nullable: false),
                    ReturnLatestDate = table.Column<DateTime>(nullable: false),
                    ReturnedDate = table.Column<DateTime>(nullable: true),
                    Returned = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrows", x => x.BookBorrowId);
                    table.ForeignKey(
                        name: "FK_BookBorrows_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBorrows_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "NumberOfBooksInStock", "Title", "TotalNumberOfBooks" },
                values: new object[,]
                {
                    { 1, "J.K Rowling", 5, "Harry Potter", 7 },
                    { 2, "Dan Brown", 3, "Da Vinci-Koden", 4 },
                    { 3, "C.S Lewis", 6, "Berättelsen om Narnia", 7 },
                    { 4, "Suzanne Collins", 10, "Hungerspelen", 11 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "City", "Name", "PhoneNr", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Vägen 1", "Halmstad", "Anders Andersson", "0733333333", "30291" },
                    { 2, "Vägen 10", "Stockholm", "Sven Svensson", "0744444444", "60291" },
                    { 3, "Gatan 1", "Göteborg", "Göran Göransson", "075555555", "40291" },
                    { 4, "Gränden 1", "Borås", "Karl Karlsson", "07666666", "20291" }
                });

            migrationBuilder.InsertData(
                table: "BookBorrows",
                columns: new[] { "BookBorrowId", "BookId", "BorrowDate", "CustomerId", "ReturnLatestDate", "Returned", "ReturnedDate" },
                values: new object[,]
                {
                    { 3, 2, new DateTime(2022, 8, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2022, 9, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), false, null },
                    { 6, 4, new DateTime(2022, 7, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2022, 8, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2022, 8, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 1, new DateTime(2022, 8, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2022, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), false, null },
                    { 7, 3, new DateTime(2022, 7, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2022, 8, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2022, 8, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, new DateTime(2022, 8, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2022, 9, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), false, null },
                    { 4, 4, new DateTime(2022, 8, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2022, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), false, null },
                    { 5, 3, new DateTime(2022, 8, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2022, 9, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), false, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrows_BookId",
                table: "BookBorrows",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrows_CustomerId",
                table: "BookBorrows",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBorrows");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
