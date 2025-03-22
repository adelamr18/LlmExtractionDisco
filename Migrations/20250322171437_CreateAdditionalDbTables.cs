using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LlmExtractionApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateAdditionalDbTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReceiptDeliveryMetadata",
                columns: table => new
                {
                    DeliveryMetadataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerMobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FloorNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerAddressLandmark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryManName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryManId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptDeliveryMetadata", x => x.DeliveryMetadataId);
                    table.ForeignKey(
                        name: "FK_ReceiptDeliveryMetadata_Receipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipts",
                        principalColumn: "ReceiptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptFinancialMetadata",
                columns: table => new
                {
                    FinancialMetadataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubTotalAmountBeforeDiscount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTotalAfterDiscount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceTaxValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmountsNotApplicableToVAT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmountsApplicableToVAT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonationToNGOs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NetVATValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VATPercentage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RedemptionPointsProgramEntityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RedemptionPointsProgramValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VoucherEntityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RedemptionVouchersValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CouponEntityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RedemptionCouponValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantLoyaltyPointsProgramName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantLoyaltyPointsProgramValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalValueOfAllRedemptions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryFees = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceFees = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tips = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalDue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaidAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Change = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentCash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentCreditCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPurchasedItems = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfItemsApplicableToVAT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfItemsNotApplicableToVAT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPurchasedUnits = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalDiscountCustomerGot = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptFinancialMetadata", x => x.FinancialMetadataId);
                    table.ForeignKey(
                        name: "FK_ReceiptFinancialMetadata_Receipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipts",
                        principalColumn: "ReceiptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptHeaderMetadatas",
                columns: table => new
                {
                    HeaderMetadataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MerchantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantBranch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantTelephoneNumbers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantHotlineNumbers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchTelephoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiptNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PosNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CashierNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CashierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shift = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiptBarcode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptHeaderMetadatas", x => x.HeaderMetadataId);
                    table.ForeignKey(
                        name: "FK_ReceiptHeaderMetadatas_Receipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipts",
                        principalColumn: "ReceiptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptMerchantContactsMetadata",
                columns: table => new
                {
                    MerchantContactsMetadataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MerchantContactNumbers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantWebsite = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptMerchantContactsMetadata", x => x.MerchantContactsMetadataId);
                    table.ForeignKey(
                        name: "FK_ReceiptMerchantContactsMetadata_Receipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipts",
                        principalColumn: "ReceiptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptDeliveryMetadata_ReceiptId",
                table: "ReceiptDeliveryMetadata",
                column: "ReceiptId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptFinancialMetadata_ReceiptId",
                table: "ReceiptFinancialMetadata",
                column: "ReceiptId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptHeaderMetadatas_ReceiptId",
                table: "ReceiptHeaderMetadatas",
                column: "ReceiptId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptMerchantContactsMetadata_ReceiptId",
                table: "ReceiptMerchantContactsMetadata",
                column: "ReceiptId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceiptDeliveryMetadata");

            migrationBuilder.DropTable(
                name: "ReceiptFinancialMetadata");

            migrationBuilder.DropTable(
                name: "ReceiptHeaderMetadatas");

            migrationBuilder.DropTable(
                name: "ReceiptMerchantContactsMetadata");
        }
    }
}
