using LlmExtractionApi.Data;
using LlmExtractionApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class ReceiptsController : ControllerBase
{
    private readonly DataContext _db;

    public ReceiptsController(DataContext db)
    {
        _db = db;
    }

    [HttpPost("create-receipt")]
    public async Task<IActionResult> CreateReceipt([FromBody] Receipt model)
    {
        try
        {
            _db.Receipts.Add(model);
            await _db.SaveChangesAsync();
            return Ok(model);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error creating receipt: {ex.Message}");
        }
    }


    [HttpPatch("update-receipt/{receiptId}")]
    public async Task<IActionResult> PatchReceipt(Guid receiptId, [FromBody] Receipt model)
    {
        var existing = await _db.Receipts
            .Include(r => r.ReceiptItems)
            .Include(r => r.ReceiptHeaderMetadata)
            .Include(r => r.ReceiptFinancialMetadata)
            .Include(r => r.ReceiptDeliveryMetadata)
            .Include(r => r.ReceiptMerchantContactsMetadata)
            .FirstOrDefaultAsync(r => r.ReceiptId == receiptId);

        if (existing == null)
            return NotFound($"Receipt with ID {receiptId} not found.");

        if (model.ImageId != null)
            existing.ImageId = model.ImageId;
        if (model.DiscoReceiptId != null)
            existing.DiscoReceiptId = model.DiscoReceiptId;
        if (model.OcrContent != null)
            existing.OcrContent = model.OcrContent;

        if (model.ReceiptItems != null)
        {
            _db.ReceiptItems.RemoveRange(existing.ReceiptItems);
            foreach (var item in model.ReceiptItems)
            {
                item.ReceiptId = existing.ReceiptId;
                _db.ReceiptItems.Add(item);
            }
        }

        if (model.ReceiptHeaderMetadata != null)
        {
            if (existing.ReceiptHeaderMetadata == null)
            {
                existing.ReceiptHeaderMetadata = new ReceiptHeaderMetadata
                {
                    ReceiptId = existing.ReceiptId
                };
                _db.ReceiptHeaderMetadatas.Add(existing.ReceiptHeaderMetadata);
            }
            existing.ReceiptHeaderMetadata.MerchantName = model.ReceiptHeaderMetadata.MerchantName ?? existing.ReceiptHeaderMetadata.MerchantName;
            existing.ReceiptHeaderMetadata.MerchantBranch = model.ReceiptHeaderMetadata.MerchantBranch ?? existing.ReceiptHeaderMetadata.MerchantBranch;
            existing.ReceiptHeaderMetadata.MerchantTelephoneNumbers = model.ReceiptHeaderMetadata.MerchantTelephoneNumbers ?? existing.ReceiptHeaderMetadata.MerchantTelephoneNumbers;
            existing.ReceiptHeaderMetadata.MerchantHotlineNumbers = model.ReceiptHeaderMetadata.MerchantHotlineNumbers ?? existing.ReceiptHeaderMetadata.MerchantHotlineNumbers;
            existing.ReceiptHeaderMetadata.StreetName = model.ReceiptHeaderMetadata.StreetName ?? existing.ReceiptHeaderMetadata.StreetName;
            existing.ReceiptHeaderMetadata.Area = model.ReceiptHeaderMetadata.Area ?? existing.ReceiptHeaderMetadata.Area;
            existing.ReceiptHeaderMetadata.City = model.ReceiptHeaderMetadata.City ?? existing.ReceiptHeaderMetadata.City;
            existing.ReceiptHeaderMetadata.PostalCode = model.ReceiptHeaderMetadata.PostalCode ?? existing.ReceiptHeaderMetadata.PostalCode;
            existing.ReceiptHeaderMetadata.BranchTelephoneNumber = model.ReceiptHeaderMetadata.BranchTelephoneNumber ?? existing.ReceiptHeaderMetadata.BranchTelephoneNumber;
            existing.ReceiptHeaderMetadata.Date = model.ReceiptHeaderMetadata.Date ?? existing.ReceiptHeaderMetadata.Date;
            existing.ReceiptHeaderMetadata.Time = model.ReceiptHeaderMetadata.Time ?? existing.ReceiptHeaderMetadata.Time;
            existing.ReceiptHeaderMetadata.ReceiptNumber = model.ReceiptHeaderMetadata.ReceiptNumber ?? existing.ReceiptHeaderMetadata.ReceiptNumber;
            existing.ReceiptHeaderMetadata.PosNumber = model.ReceiptHeaderMetadata.PosNumber ?? existing.ReceiptHeaderMetadata.PosNumber;
            existing.ReceiptHeaderMetadata.TransactionNumber = model.ReceiptHeaderMetadata.TransactionNumber ?? existing.ReceiptHeaderMetadata.TransactionNumber;
            existing.ReceiptHeaderMetadata.CashierNumber = model.ReceiptHeaderMetadata.CashierNumber ?? existing.ReceiptHeaderMetadata.CashierNumber;
            existing.ReceiptHeaderMetadata.CashierName = model.ReceiptHeaderMetadata.CashierName ?? existing.ReceiptHeaderMetadata.CashierName;
            existing.ReceiptHeaderMetadata.Shift = model.ReceiptHeaderMetadata.Shift ?? existing.ReceiptHeaderMetadata.Shift;
            existing.ReceiptHeaderMetadata.ReceiptBarcode = model.ReceiptHeaderMetadata.ReceiptBarcode ?? existing.ReceiptHeaderMetadata.ReceiptBarcode;
        }

        if (model.ReceiptFinancialMetadata != null)
        {
            if (existing.ReceiptFinancialMetadata == null)
            {
                existing.ReceiptFinancialMetadata = new ReceiptFinancialMetadata
                {
                    ReceiptId = existing.ReceiptId
                };
                _db.ReceiptFinancialMetadatas.Add(existing.ReceiptFinancialMetadata);
            }
            existing.ReceiptFinancialMetadata.SubTotalAmountBeforeDiscount = model.ReceiptFinancialMetadata.SubTotalAmountBeforeDiscount ?? existing.ReceiptFinancialMetadata.SubTotalAmountBeforeDiscount;
            existing.ReceiptFinancialMetadata.DiscountType = model.ReceiptFinancialMetadata.DiscountType ?? existing.ReceiptFinancialMetadata.DiscountType;
            existing.ReceiptFinancialMetadata.SubTotalAfterDiscount = model.ReceiptFinancialMetadata.SubTotalAfterDiscount ?? existing.ReceiptFinancialMetadata.SubTotalAfterDiscount;
            existing.ReceiptFinancialMetadata.ServiceTaxValue = model.ReceiptFinancialMetadata.ServiceTaxValue ?? existing.ReceiptFinancialMetadata.ServiceTaxValue;
            existing.ReceiptFinancialMetadata.TotalAmountsNotApplicableToVAT = model.ReceiptFinancialMetadata.TotalAmountsNotApplicableToVAT ?? existing.ReceiptFinancialMetadata.TotalAmountsNotApplicableToVAT;
            existing.ReceiptFinancialMetadata.TotalAmountsApplicableToVAT = model.ReceiptFinancialMetadata.TotalAmountsApplicableToVAT ?? existing.ReceiptFinancialMetadata.TotalAmountsApplicableToVAT;
            existing.ReceiptFinancialMetadata.DonationToNGOs = model.ReceiptFinancialMetadata.DonationToNGOs ?? existing.ReceiptFinancialMetadata.DonationToNGOs;
            existing.ReceiptFinancialMetadata.NetVATValue = model.ReceiptFinancialMetadata.NetVATValue ?? existing.ReceiptFinancialMetadata.NetVATValue;
            existing.ReceiptFinancialMetadata.VATPercentage = model.ReceiptFinancialMetadata.VATPercentage ?? existing.ReceiptFinancialMetadata.VATPercentage;
            existing.ReceiptFinancialMetadata.RedemptionPointsProgramEntityName = model.ReceiptFinancialMetadata.RedemptionPointsProgramEntityName ?? existing.ReceiptFinancialMetadata.RedemptionPointsProgramEntityName;
            existing.ReceiptFinancialMetadata.RedemptionPointsProgramValue = model.ReceiptFinancialMetadata.RedemptionPointsProgramValue ?? existing.ReceiptFinancialMetadata.RedemptionPointsProgramValue;
            existing.ReceiptFinancialMetadata.VoucherEntityName = model.ReceiptFinancialMetadata.VoucherEntityName ?? existing.ReceiptFinancialMetadata.VoucherEntityName;
            existing.ReceiptFinancialMetadata.RedemptionVouchersValue = model.ReceiptFinancialMetadata.RedemptionVouchersValue ?? existing.ReceiptFinancialMetadata.RedemptionVouchersValue;
            existing.ReceiptFinancialMetadata.CouponEntityName = model.ReceiptFinancialMetadata.CouponEntityName ?? existing.ReceiptFinancialMetadata.CouponEntityName;
            existing.ReceiptFinancialMetadata.RedemptionCouponValue = model.ReceiptFinancialMetadata.RedemptionCouponValue ?? existing.ReceiptFinancialMetadata.RedemptionCouponValue;
            existing.ReceiptFinancialMetadata.MerchantLoyaltyPointsProgramName = model.ReceiptFinancialMetadata.MerchantLoyaltyPointsProgramName ?? existing.ReceiptFinancialMetadata.MerchantLoyaltyPointsProgramName;
            existing.ReceiptFinancialMetadata.MerchantLoyaltyPointsProgramValue = model.ReceiptFinancialMetadata.MerchantLoyaltyPointsProgramValue ?? existing.ReceiptFinancialMetadata.MerchantLoyaltyPointsProgramValue;
            existing.ReceiptFinancialMetadata.TotalValueOfAllRedemptions = model.ReceiptFinancialMetadata.TotalValueOfAllRedemptions ?? existing.ReceiptFinancialMetadata.TotalValueOfAllRedemptions;
            existing.ReceiptFinancialMetadata.DeliveryFees = model.ReceiptFinancialMetadata.DeliveryFees ?? existing.ReceiptFinancialMetadata.DeliveryFees;
            existing.ReceiptFinancialMetadata.ServiceFees = model.ReceiptFinancialMetadata.ServiceFees ?? existing.ReceiptFinancialMetadata.ServiceFees;
            existing.ReceiptFinancialMetadata.Tips = model.ReceiptFinancialMetadata.Tips ?? existing.ReceiptFinancialMetadata.Tips;
            existing.ReceiptFinancialMetadata.TotalDue = model.ReceiptFinancialMetadata.TotalDue ?? existing.ReceiptFinancialMetadata.TotalDue;
            existing.ReceiptFinancialMetadata.PaidAmount = model.ReceiptFinancialMetadata.PaidAmount ?? existing.ReceiptFinancialMetadata.PaidAmount;
            existing.ReceiptFinancialMetadata.Change = model.ReceiptFinancialMetadata.Change ?? existing.ReceiptFinancialMetadata.Change;
            existing.ReceiptFinancialMetadata.PaymentCash = model.ReceiptFinancialMetadata.PaymentCash ?? existing.ReceiptFinancialMetadata.PaymentCash;
            existing.ReceiptFinancialMetadata.PaymentCreditCard = model.ReceiptFinancialMetadata.PaymentCreditCard ?? existing.ReceiptFinancialMetadata.PaymentCreditCard;
            existing.ReceiptFinancialMetadata.TotalPurchasedItems = model.ReceiptFinancialMetadata.TotalPurchasedItems ?? existing.ReceiptFinancialMetadata.TotalPurchasedItems;
            existing.ReceiptFinancialMetadata.NumberOfItemsApplicableToVAT = model.ReceiptFinancialMetadata.NumberOfItemsApplicableToVAT ?? existing.ReceiptFinancialMetadata.NumberOfItemsApplicableToVAT;
            existing.ReceiptFinancialMetadata.NumberOfItemsNotApplicableToVAT = model.ReceiptFinancialMetadata.NumberOfItemsNotApplicableToVAT ?? existing.ReceiptFinancialMetadata.NumberOfItemsNotApplicableToVAT;
            existing.ReceiptFinancialMetadata.TotalPurchasedUnits = model.ReceiptFinancialMetadata.TotalPurchasedUnits ?? existing.ReceiptFinancialMetadata.TotalPurchasedUnits;
            existing.ReceiptFinancialMetadata.TotalDiscountCustomerGot = model.ReceiptFinancialMetadata.TotalDiscountCustomerGot ?? existing.ReceiptFinancialMetadata.TotalDiscountCustomerGot;
        }

        if (model.ReceiptDeliveryMetadata != null)
        {
            if (existing.ReceiptDeliveryMetadata == null)
            {
                existing.ReceiptDeliveryMetadata = new ReceiptDeliveryMetadata
                {
                    ReceiptId = existing.ReceiptId
                };
                _db.ReceiptDeliveryMetadatas.Add(existing.ReceiptDeliveryMetadata);
            }
            existing.ReceiptDeliveryMetadata.OrderNumber = model.ReceiptDeliveryMetadata.OrderNumber ?? existing.ReceiptDeliveryMetadata.OrderNumber;
            existing.ReceiptDeliveryMetadata.CustomerName = model.ReceiptDeliveryMetadata.CustomerName ?? existing.ReceiptDeliveryMetadata.CustomerName;
            existing.ReceiptDeliveryMetadata.CustomerMobileNumber = model.ReceiptDeliveryMetadata.CustomerMobileNumber ?? existing.ReceiptDeliveryMetadata.CustomerMobileNumber;
            existing.ReceiptDeliveryMetadata.StreetName = model.ReceiptDeliveryMetadata.StreetName ?? existing.ReceiptDeliveryMetadata.StreetName;
            existing.ReceiptDeliveryMetadata.Area = model.ReceiptDeliveryMetadata.Area ?? existing.ReceiptDeliveryMetadata.Area;
            existing.ReceiptDeliveryMetadata.FloorNumber = model.ReceiptDeliveryMetadata.FloorNumber ?? existing.ReceiptDeliveryMetadata.FloorNumber;
            existing.ReceiptDeliveryMetadata.ApartmentNumber = model.ReceiptDeliveryMetadata.ApartmentNumber ?? existing.ReceiptDeliveryMetadata.ApartmentNumber;
            existing.ReceiptDeliveryMetadata.CustomerAddressLandmark = model.ReceiptDeliveryMetadata.CustomerAddressLandmark ?? existing.ReceiptDeliveryMetadata.CustomerAddressLandmark;
            existing.ReceiptDeliveryMetadata.DeliveryManName = model.ReceiptDeliveryMetadata.DeliveryManName ?? existing.ReceiptDeliveryMetadata.DeliveryManName;
            existing.ReceiptDeliveryMetadata.DeliveryManId = model.ReceiptDeliveryMetadata.DeliveryManId ?? existing.ReceiptDeliveryMetadata.DeliveryManId;
            existing.ReceiptDeliveryMetadata.DeliveryTime = model.ReceiptDeliveryMetadata.DeliveryTime ?? existing.ReceiptDeliveryMetadata.DeliveryTime;
        }

        if (model.ReceiptMerchantContactsMetadata != null)
        {
            if (existing.ReceiptMerchantContactsMetadata == null)
            {
                existing.ReceiptMerchantContactsMetadata = new ReceiptMerchantContactsMetadata
                {
                    ReceiptId = existing.ReceiptId
                };
                _db.ReceiptMerchantContactsMetadatas.Add(existing.ReceiptMerchantContactsMetadata);
            }
            existing.ReceiptMerchantContactsMetadata.MerchantContactNumbers = model.ReceiptMerchantContactsMetadata.MerchantContactNumbers ?? existing.ReceiptMerchantContactsMetadata.MerchantContactNumbers;
            existing.ReceiptMerchantContactsMetadata.MerchantEmail = model.ReceiptMerchantContactsMetadata.MerchantEmail ?? existing.ReceiptMerchantContactsMetadata.MerchantEmail;
            existing.ReceiptMerchantContactsMetadata.Facebook = model.ReceiptMerchantContactsMetadata.Facebook ?? existing.ReceiptMerchantContactsMetadata.Facebook;
            existing.ReceiptMerchantContactsMetadata.Instagram = model.ReceiptMerchantContactsMetadata.Instagram ?? existing.ReceiptMerchantContactsMetadata.Instagram;
            existing.ReceiptMerchantContactsMetadata.MerchantWebsite = model.ReceiptMerchantContactsMetadata.MerchantWebsite ?? existing.ReceiptMerchantContactsMetadata.MerchantWebsite;
        }

        _db.Receipts.Update(existing);
        await _db.SaveChangesAsync();
        return Ok(existing);
    }

    [HttpDelete("delete-receipt/{receiptId}")]
    public async Task<IActionResult> DeleteReceipt(Guid receiptId)
    {
        var existing = await _db.Receipts
            .Include(r => r.ReceiptItems)
            .Include(r => r.ReceiptHeaderMetadata)
            .Include(r => r.ReceiptFinancialMetadata)
            .Include(r => r.ReceiptDeliveryMetadata)
            .Include(r => r.ReceiptMerchantContactsMetadata)
            .FirstOrDefaultAsync(r => r.ReceiptId == receiptId);

        if (existing == null)
            return NotFound($"Receipt with ID {receiptId} not found.");

        _db.Receipts.Remove(existing);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
