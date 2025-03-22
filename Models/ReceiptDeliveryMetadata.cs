using System;

namespace LlmExtractionApi.Models
{
    public class ReceiptDeliveryMetadata
    {
        public ReceiptDeliveryMetadata() { }
        public int DeliveryMetadataId { get; set; }
        public Guid ReceiptId { get; set; }
        public Receipt Receipt { get; set; } = default!;
        public string OrderNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerMobileNumber { get; set; } = string.Empty;
        public string StreetName { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string FloorNumber { get; set; } = string.Empty;
        public string ApartmentNumber { get; set; } = string.Empty;
        public string CustomerAddressLandmark { get; set; } = string.Empty;
        public string DeliveryManName { get; set; } = string.Empty;
        public string DeliveryManId { get; set; } = string.Empty;
        public string DeliveryTime { get; set; } = string.Empty;
    }
}
