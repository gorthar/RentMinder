using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend;

[Route("api/lease")]
[ApiController]
public class LeaseController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public LeaseController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetLeases()
    {
        var leasesDto = await _context.Leases.Select(l => l.ToLeaseDto()).ToListAsync();
        return Ok(leasesDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLease([FromRoute] int id)
    {
        var leaseDto = await _context.Leases.Where(l => l.Id == id).Select(l => l.ToLeaseDto()).FirstOrDefaultAsync();
        if (leaseDto == null)
        {
            return NotFound();
        }
        return Ok(leaseDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLease([FromRoute] int id, [FromBody] LeaseDto leaseDto)
    {
        var lease = await _context.Leases.FindAsync(id);
        if (lease == null)
        {
            return NotFound();
        }

        lease.PropertyId = leaseDto.PropertyId;
        lease.StartDate = leaseDto.StartDate;
        lease.EndDate = leaseDto.EndDate;
        lease.Rent = leaseDto.Rent;
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateLease([FromBody] LeaseDto leaseDto)
    {
        var lease = leaseDto.ToLeaseModel();
        _context.Leases.Add(lease);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetLease), new { id = lease.Id }, lease.ToLeaseDto());
    }

}
