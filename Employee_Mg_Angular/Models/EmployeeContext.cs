using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Mg_Angular.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
           : base(options) { }

        public EmployeeContext() { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(@"Data Source = (localdb)\mssqllocaldb; Initial Catalog = EmployeeManagement; Integrated Security = True");//(@"Server =(localdb)\mssqllocaldb;Database=EmployeeManagement;Trusted_Connection=True;;MultipleActiveResultSets=true");
        //    }
        //}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
      

        public DbSet<EmployeeMaster> EmployeeMaster { get; set; }
        public DbSet<DepartmentMaster> DepartmentMaster { get; set; }
        //  public DbSet<Depart> Depart { get; set; }
    }
}
