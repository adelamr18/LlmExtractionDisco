using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LlmExtractionApi.Models
{
    public class ReceiptHeaderMetadata
    {

        public ReceiptHeaderMetadata() { }
        public int HeaderMetadataId { get; set; }
        public Guid ReceiptId { get; set; }
        [JsonIgnore]
        public Receipt? Receipt { get; set; }
        public string MerchantName { get; set; } = string.Empty;
        public string MerchantBranch { get; set; } = string.Empty;
        public string MerchantTelephoneNumbers { get; set; } = string.Empty;
        public string MerchantHotlineNumbers { get; set; } = string.Empty;
        public string StreetName { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string BranchTelephoneNumber { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public string ReceiptNumber { get; set; } = string.Empty;
        public string PosNumber { get; set; } = string.Empty;
        public string TransactionNumber { get; set; } = string.Empty;
        public string CashierNumber { get; set; } = string.Empty;
        public string CashierName { get; set; } = string.Empty;
        public string Shift { get; set; } = string.Empty;
        public string ReceiptBarcode { get; set; } = string.Empty;
    }
}
