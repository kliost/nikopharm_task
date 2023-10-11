using Microsoft.EntityFrameworkCore;

namespace nikopharm_task.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<EmployeeModel> employees { get; set; }
    }
}
