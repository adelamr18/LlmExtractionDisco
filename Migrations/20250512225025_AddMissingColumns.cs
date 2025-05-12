using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LlmExtractionApi.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExtractionLink",
                table: "Receipts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OcrLink",
                table: "Receipts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PictureLink",
                table: "Receipts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MerchantBranch",
                table: "ReceiptMerchantContactsMetadata",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MerchantName",
                table: "ReceiptMerchantContactsMetadata",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtractionLink",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "OcrLink",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "PictureLink",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "MerchantBranch",
                table: "ReceiptMerchantContactsMetadata");

            migrationBuilder.DropColumn(
                name: "MerchantName",
                table: "ReceiptMerchantContactsMetadata");
        }
    }
}
