using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LlmExtractionApi.Models
{
    public class ReceiptItem
    {
        [JsonIgnore]
        public Receipt? Receipt { get; set; }
        public int ItemId { get; set; }
        public Guid ReceiptId { get; set; }
        public int RowNumber { get; set; }
        public string ItemFullTextDescription { get; set; } = string.Empty;
        public string ItemBrandNameArabic { get; set; } = string.Empty;
        public string ItemBrandNameEnglish { get; set; } = string.Empty;
        public string ItemSubBrandNameArabic { get; set; } = string.Empty;
        public string ItemSubBrandNameEnglish { get; set; } = string.Empty;
        public string? ItemPrice { get; set; }
        public string? ItemQuantityOrWeight { get; set; }
        public string? ItemTotalPrice { get; set; }
        public string? DiscountValue { get; set; }
        public string? DiscountPercentage { get; set; }
        public string? FullQuantityDescription { get; set; }
        public string? ScaleOfWeightCapacity { get; set; }
        public string? ItemBarcode { get; set; }
        public string? ItemCategory { get; set; }
        public string? ItemSubCategory { get; set; }
        public string? ItemSubSubCategory { get; set; }
        public string? ItemFlavorOrFragrance { get; set; }
        public string? ItemSize { get; set; }
        public string? ItemPackagingType { get; set; }
        public string? ItemPackagingMaterial { get; set; }
    }
}
