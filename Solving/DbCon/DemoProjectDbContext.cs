using Microsoft.EntityFrameworkCore;
using Solving.Model;

namespace Solving.DbCon
{
    public class DemoProjectDbContext : DbContext
    {
        public DemoProjectDbContext(DbContextOptions<DemoProjectDbContext> options) : base(options)
        {

        }
        public DbSet<Employeetb> employeetbs { get; set; }
        public DbSet<Attendance> attendances { get; set; }
    }
}
