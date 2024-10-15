using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;




namespace Company.Data_Access_Layer.Context
{
	public class CompanyDBContext : IdentityDbContext<ApplicationUser>
	{
		public CompanyDBContext(DbContextOptions<CompanyDBContext>options) : base(options)
		{
		}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			//	modelBuilder.Entity<BaseEntity>().HasQueryFilter(x => !x.IsDeleted);
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Employee> Employees { get; set; }
		public DbSet<Department> Departments { get; set; }

	}
}

