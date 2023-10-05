using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solving.DbCon;
using Solving.Model;
using System.Diagnostics.Metrics;

namespace Solving.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AttendanceController : Controller
{

    private readonly DemoProjectDbContext _context;

    public AttendanceController(DemoProjectDbContext context)
    {
        _context = context;
    }

    // GET: api/<AttendanceController>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Attendance>>> Get()
    {
        return await _context.attendances.ToListAsync();
    }

  


    //Employee Controller start
    // GET: api/<AttendanceController>
    [HttpGet("employee")]
    public async Task<ActionResult<IEnumerable<Employeetb>>> Get1()
    {
        
        return await _context.employeetbs.ToListAsync();
    }

    //// GET api/<CountryController>/5
    [HttpGet("{employeeid}")]
    public async Task<ActionResult<Employeetb>> Get1(int employeeid)
    {
        return await _context.employeetbs.FindAsync(employeeid);
    }



    //// PUT api/<CountryController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Employeetb>> Put(int id, [FromBody] Employeetb employeetb)
    {
        if (id != employeetb.employeeId)
        {
            return BadRequest();
        }
        _context.Entry(employeetb).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if(!EmployeetbExists(id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    private bool EmployeetbExists(int id)
    {
        //throw new NotImplementedException();
        return (_context.employeetbs?.Any(x => x.employeeId == id)).GetValueOrDefault();
    }



}
