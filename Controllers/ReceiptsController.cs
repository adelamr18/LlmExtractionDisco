

using LlmExtractionApi.Data;
using LlmExtractionApi.Models;
using Microsoft.AspNetCore.Mvc;

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
        _db.Receipts.Add(model);
        await _db.SaveChangesAsync();
        return Ok(model);
    }
}
