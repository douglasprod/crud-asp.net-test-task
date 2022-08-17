using artsofte.Models;
using Microsoft.EntityFrameworkCore;

namespace artsofte.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<EmployeeDataModel> Employees { get; set; }
        public DbSet<LanguageDataModel> Languages { get; set; }
        public DbSet<DepartmentDataModel> Department { get; set; }
    }
}
