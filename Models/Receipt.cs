

namespace LlmExtractionApi.Models
{
    public class Receipt
    {
        public Guid ReceiptId { get; set; } = Guid.NewGuid();

        public string ImageId { get; set; } = "";
        public string DiscoReceiptId { get; set; } = "";
        public string OcrContent { get; set; } = "";

        public ICollection<ReceiptItem> ReceiptItems { get; set; } = [];
    }
}
