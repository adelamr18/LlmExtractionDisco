
namespace LlmExtractionApi.Models
{
    public class ReceiptMerchantContactsMetadata
    {
        public ReceiptMerchantContactsMetadata() { }
        public int MerchantContactsMetadataId { get; set; }
        public Guid ReceiptId { get; set; }
        public Receipt Receipt { get; set; } = default!;
        public string MerchantContactNumbers { get; set; } = string.Empty;
        public string MerchantEmail { get; set; } = string.Empty;
        public string Facebook { get; set; } = string.Empty;
        public string Instagram { get; set; } = string.Empty;
        public string MerchantWebsite { get; set; } = string.Empty;
    }
}
