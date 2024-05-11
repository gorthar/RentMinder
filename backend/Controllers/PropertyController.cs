using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend;
[Route("api/property")]
[ApiController]
public class PropertyController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public PropertyController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetProperties()
    {
        var propertiesDto = await _context.Properties.Select(p => p.ToPropertyDto()).ToListAsync();
        return Ok(propertiesDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProperty([FromRoute] int id)
    {
        var propertyDto = await _context.Properties.Where(p => p.Id == id).Select(p => p.ToPropertyDto()).FirstOrDefaultAsync();
        if (propertyDto == null)
        {
            return NotFound();
        }
        return Ok(propertyDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProperty([FromRoute] int id, [FromBody] PropertyDto propertyDto)
    {
        var property = await _context.Properties.FindAsync(id);
        if (property == null)
        {
            return NotFound();
        }

        property.OwnerId = propertyDto.OwnerId;
        property.Address = propertyDto.Address;
        property.City = propertyDto.City;
        property.Province = propertyDto.Province;
        property.PostalCode = propertyDto.PostalCode;
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateProperty([FromBody] PropertyDto propertyDto)
    {
        var property = propertyDto.ToPropertyModel();
        _context.Properties.Add(property);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProperty), new { id = property.Id }, property.ToPropertyDto());
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProperty([FromRoute] int id)
    {
        var property = await _context.Properties.FindAsync(id);
        if (property == null)
        {
            return NotFound();
        }

        _context.Properties.Remove(property);
        await _context.SaveChangesAsync();
        return Ok();
    }




}
