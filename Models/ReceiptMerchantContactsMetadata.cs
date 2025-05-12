
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LlmExtractionApi.Models
{
    [Table("ReceiptMerchantContactsMetadata")]
    public class ReceiptMerchantContactsMetadata
    {
        public ReceiptMerchantContactsMetadata() { }
        public int MerchantContactsMetadataId { get; set; }
        public Guid ReceiptId { get; set; }
        [JsonIgnore]
        public Receipt? Receipt { get; set; }
        public string MerchantContactNumbers { get; set; } = string.Empty;
        public string MerchantEmail { get; set; } = string.Empty;
        public string Facebook { get; set; } = string.Empty;
        public string Instagram { get; set; } = string.Empty;
        public string MerchantWebsite { get; set; } = string.Empty;
        public string MerchantName { get; set; } = string.Empty;
        public string MerchantBranch { get; set; } = string.Empty;
    }
}
