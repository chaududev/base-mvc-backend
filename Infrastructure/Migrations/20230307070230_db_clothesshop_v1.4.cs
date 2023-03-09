using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class db_clothesshop_v14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laundry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laundry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Origin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleStaff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleStaff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeClothes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Limit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeClothes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CitizenCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_RoleStaff_Id",
                        column: x => x.Id,
                        principalTable: "RoleStaff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clothes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RentalTime = table.Column<int>(type: "int", nullable: false),
                    RentalPrice = table.Column<int>(type: "int", nullable: false),
                    TypeClothesId = table.Column<int>(type: "int", nullable: false),
                    OriginId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clothes_Origin_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Origin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clothes_TypeClothes_TypeClothesId",
                        column: x => x.TypeClothesId,
                        principalTable: "TypeClothes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Customer_Id",
                        column: x => x.Id,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoice_Staff_Id",
                        column: x => x.Id,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LaundryInvoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LaundryId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaundryInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaundryInvoice_Laundry_Id",
                        column: x => x.Id,
                        principalTable: "Laundry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LaundryInvoice_Staff_Id",
                        column: x => x.Id,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailInvoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ClothesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailInvoice_Clothes_Id",
                        column: x => x.Id,
                        principalTable: "Clothes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailInvoice_Invoice_Id",
                        column: x => x.Id,
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailInvoiceLaundry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    LaundryInvoiceId = table.Column<int>(type: "int", nullable: false),
                    ClothesId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailInvoiceLaundry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailInvoiceLaundry_Clothes_Id",
                        column: x => x.Id,
                        principalTable: "Clothes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailInvoiceLaundry_LaundryInvoice_Id",
                        column: x => x.Id,
                        principalTable: "LaundryInvoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Address", "FullName", "Phone" },
                values: new object[,]
                {
                    { 1, "32 Nguyen Hue Str, Hue", "Chau Hoang Bich Du", "0943357474" },
                    { 2, "42 Nguyen Hue Str, Ha Noi", "Chau Chi Khanh", "0935727272" }
                });

            migrationBuilder.InsertData(
                table: "Laundry",
                columns: new[] { "Id", "Address", "Name", "Phone", "Rate" },
                values: new object[,]
                {
                    { 1, "56 Nguyen Hue Str, Hue", "O Ti", "0943357373", 3 },
                    { 2, "42 Hai Ba Trung Str, Hue", "O Mi", "0935727276", 4 }
                });

            migrationBuilder.InsertData(
                table: "Origin",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "Korea", "Zara" },
                    { 2, "Japan", "Uniqlo" }
                });

            migrationBuilder.InsertData(
                table: "RoleStaff",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Accountant" }
                });

            migrationBuilder.InsertData(
                table: "TypeClothes",
                columns: new[] { "Id", "Limit", "Name" },
                values: new object[,]
                {
                    { 1, 15, "Váy" },
                    { 2, 20, "Áo" }
                });

            migrationBuilder.InsertData(
                table: "Clothes",
                columns: new[] { "Id", "Description", "Name", "OriginId", "Price", "RentalPrice", "RentalTime", "Size", "Status", "TypeClothesId" },
                values: new object[,]
                {
                    { 1, "Màu trắng", "Váy công sở Zara", 1, 89.99m, 200000, 0, 3, 1, 1 },
                    { 2, "Màu đen", "Áo công sở Uniqlo", 2, 58.99m, 100000, 0, 2, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "Address", "Birthday", "CitizenCode", "CreatedDate", "Email", "FullName", "Password", "Phone", "RoleId" },
                values: new object[,]
                {
                    { 1, "5/6 Nguyen Cong Tru Str, Hue", new DateTime(2001, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "04321842241", new DateTime(2022, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@abc.com", "Nguyen Thi Kim Tuyen", "SS1JiBmooIzUmIjlbQEUet0eMI/KvUUX5j9E/Qk/Bf8=", "0943357323", 1 },
                    { 2, "5/10 Nguyen Hue Str, Hue", new DateTime(1989, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "04242144124", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tai@gmail.com", "Nguyen Van Tai", "SS1JiBmooIzUmIjlbQEUet0eMI/KvUUX5j9E/Qk/Bf8=", "0943357329", 2 }
                });

            migrationBuilder.InsertData(
                table: "DetailInvoice",
                columns: new[] { "Id", "ClothesId", "InvoiceId" },
                values: new object[] { 2, 2, 1 });

            migrationBuilder.InsertData(
                table: "DetailInvoiceLaundry",
                columns: new[] { "Id", "ClothesId", "LaundryInvoiceId", "Price" },
                values: new object[] { 2, 2, 1, 0.99m });

            migrationBuilder.InsertData(
                table: "Invoice",
                columns: new[] { "Id", "CustomerId", "Date", "Discount", "StaffId" },
                values: new object[] { 1, 1, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1 });

            migrationBuilder.InsertData(
                table: "LaundryInvoice",
                columns: new[] { "Id", "Date", "LaundryId", "StaffId" },
                values: new object[] { 1, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 });

            migrationBuilder.InsertData(
                table: "DetailInvoice",
                columns: new[] { "Id", "ClothesId", "InvoiceId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "DetailInvoiceLaundry",
                columns: new[] { "Id", "ClothesId", "LaundryInvoiceId", "Price" },
                values: new object[] { 1, 1, 1, 1.00m });

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_OriginId",
                table: "Clothes",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_TypeClothesId",
                table: "Clothes",
                column: "TypeClothesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailInvoice");

            migrationBuilder.DropTable(
                name: "DetailInvoiceLaundry");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Clothes");

            migrationBuilder.DropTable(
                name: "LaundryInvoice");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Origin");

            migrationBuilder.DropTable(
                name: "TypeClothes");

            migrationBuilder.DropTable(
                name: "Laundry");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "RoleStaff");
        }
    }
}
