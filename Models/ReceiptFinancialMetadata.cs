
namespace LlmExtractionApi.Models
{
    public class ReceiptFinancialMetadata
    {
        public ReceiptFinancialMetadata() { }
        public int FinancialMetadataId { get; set; }
        public Guid ReceiptId { get; set; }
        public Receipt Receipt { get; set; } = default!;
        public string SubTotalAmountBeforeDiscount { get; set; } = string.Empty;
        public string DiscountType { get; set; } = string.Empty;
        public string SubTotalAfterDiscount { get; set; } = string.Empty;
        public string ServiceTaxValue { get; set; } = string.Empty;
        public string TotalAmountsNotApplicableToVAT { get; set; } = string.Empty;
        public string TotalAmountsApplicableToVAT { get; set; } = string.Empty;
        public string DonationToNGOs { get; set; } = string.Empty;
        public string NetVATValue { get; set; } = string.Empty;
        public string VATPercentage { get; set; } = string.Empty;
        public string RedemptionPointsProgramEntityName { get; set; } = string.Empty;
        public string RedemptionPointsProgramValue { get; set; } = string.Empty;
        public string VoucherEntityName { get; set; } = string.Empty;
        public string RedemptionVouchersValue { get; set; } = string.Empty;
        public string CouponEntityName { get; set; } = string.Empty;
        public string RedemptionCouponValue { get; set; } = string.Empty;
        public string MerchantLoyaltyPointsProgramName { get; set; } = string.Empty;
        public string MerchantLoyaltyPointsProgramValue { get; set; } = string.Empty;
        public string TotalValueOfAllRedemptions { get; set; } = string.Empty;
        public string DeliveryFees { get; set; } = string.Empty;
        public string ServiceFees { get; set; } = string.Empty;
        public string Tips { get; set; } = string.Empty;
        public string TotalDue { get; set; } = string.Empty;
        public string PaidAmount { get; set; } = string.Empty;
        public string Change { get; set; } = string.Empty;
        public string PaymentCash { get; set; } = string.Empty;
        public string PaymentCreditCard { get; set; } = string.Empty;
        public string TotalPurchasedItems { get; set; } = string.Empty;
        public string NumberOfItemsApplicableToVAT { get; set; } = string.Empty;
        public string NumberOfItemsNotApplicableToVAT { get; set; } = string.Empty;
        public string TotalPurchasedUnits { get; set; } = string.Empty;
        public string TotalDiscountCustomerGot { get; set; } = string.Empty;
    }
}
