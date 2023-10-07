using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solving.DbCon;
using Solving.Model;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

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

    //// GET: api/<AttendanceController>
    //[HttpGet]
    //public async Task<ActionResult<IEnumerable<Attendance>>> Get()
    //{
    //    return await _context.attendances.ToListAsync();
    //}

  


    //Employee Controller start
    // GET: api/<AttendanceController>
    [HttpGet("ThirdHighestSalary")]
    public async Task<ActionResult<Employeetb>> GetThirdHighestSalary()
    {
        
        var result= _context.employeetbs.OrderByDescending(e=>e.employeeSalary).Skip(2).First();// employee who has 3rd salary
        return result;
    }

    [HttpGet("SalaryWithPresent")]
    public async Task<ActionResult<IEnumerable<dynamic>>> GetSalaryCombined()
    {
        var employeeTable = _context.employeetbs.OrderByDescending(a => a.employeeSalary).ToList();

        var attendanceTable = _context.attendances
            .Where(b => b.isAbsent == 0 && b.isPresent==1)
            .OrderByDescending(b => b.isOffday)
            .ToList();

        // Combine the results using a join
        //var combinedRecords = from employee in employeeTable
        //                      join attendance in attendanceTable
        //                      on employee.employeeId equals attendance.employeeId
        //                      select new {employee.employeeId, employee.employeeName, employee.employeeSalary, attendance.isAbsent }
        //                      


        var combinedRecords = from employee in employeeTable
                              join attendance in attendanceTable
                              on employee.employeeId equals attendance.employeeId
                              group new { employee.employeeId, employee.employeeName, employee.employeeSalary, attendance.isAbsent } by attendance.isAbsent into grouped
                              select new
                              {
                                  IsAbsent = grouped.Key,
                                  Employees = grouped.ToList()
                              };

        return combinedRecords.ToList();
    }


    [HttpGet]
    [Route("api/employeetbs/hierarchy/{employeeId}")]
    //public IHttpActionResult GetHierarchy(int employeeId)
    //{
    //    var hierarchy = GetEmployeeHierarchy(employeeId);
    //    if (hierarchy == null)
    //    {
    //        return IHttpActionResult(); // or another appropriate HTTP status code
    //    }
    //    return Ok(hierarchy);

    //}
    private IHttpActionResult IHttpActionResult()
    {
        throw new NotImplementedException();
    }

    private List<Employeetb> GetEmployeeHierarchy(int employeeId)
    {
        var hierarchy = new List<Employeetb>();

        // Get the employee and their direct reports
        var employee = _context.employeetbs.Find(employeeId);
        if (employee != null)
        {
            hierarchy.Add(employee);

            var directReports = _context.employeetbs.Where(e => e.supervisorId == employeeId).ToList();

            foreach (var report in directReports)
            {
                // Recursively get the hierarchy for each direct report
                hierarchy.AddRange(GetEmployeeHierarchy(report.employeeId));
            }
        }

        return hierarchy;
    }


    //// GET api/<AttendanceController>
    [HttpGet("{employeeid}")]
    public async Task<ActionResult<Employeetb>> Get1(int employeeid)
    {
        return await _context.employeetbs.FindAsync(employeeid);
    }



    //// PUT api/<CountryController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Employeetb>> Put(int id, Employeetb employeetb)
    {
        if (id != employeetb.employeeId)
        {
            return BadRequest();
        }
        //_context.Entry(employeetb).State = EntityState.Modified;
        var existingEmployeetb = await _context.employeetbs.FindAsync(id);
        if (existingEmployeetb == null)
        {
            return NotFound();
        }
        // Update specific properties
        existingEmployeetb.employeeName = employeetb.employeeName; // Replace with the actual property you want to update
        existingEmployeetb.employeeCode = employeetb.employeeCode; // Replace with other properties

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
