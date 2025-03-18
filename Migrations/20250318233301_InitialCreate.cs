using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LlmExtractionApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    ReceiptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscoReceiptId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OcrContent = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.ReceiptId);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowNumber = table.Column<int>(type: "int", nullable: false),
                    ItemFullTextDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemBrandNameArabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemBrandNameEnglish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemSubBrandNameArabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemSubBrandNameEnglish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ItemQuantityOrWeight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemTotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiscountValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiscountPercentage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullQuantityDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScaleOfWeightCapacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemBarcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemSubCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemSubSubCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemFlavorOrFragrance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPackagingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPackagingMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptItems", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_ReceiptItems_Receipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipts",
                        principalColumn: "ReceiptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptItems_ReceiptId",
                table: "ReceiptItems",
                column: "ReceiptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceiptItems");

            migrationBuilder.DropTable(
                name: "Receipts");
        }
    }
}
