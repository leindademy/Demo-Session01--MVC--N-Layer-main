using Company.Business_Logic_Layer;
using Company.Business_Logic_Layer.Mapping;
using Company.Data_Access_Layer;
using Company.Data_Access_Layer.Context;
using Company.Repository.Interfaces;
using Company.Repository.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;

namespace Company.Presention_Layer
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			builder.Services.AddDbContext<CompanyDBContext>(option =>
				{
					option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); //Json --> Connection string
			
				});
			//builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>(); 
			builder.Services.AddScoped<IDepartmentServices, DepartmentDtoServices>();
            builder.Services.AddScoped<IEmployeeServices, EmployeeDtoServices>();
			builder.Services.AddAutoMapper(x => x.AddProfile(new EmployeeProfile()));
            builder.Services.AddAutoMapper(x => x.AddProfile(new DepartmentProfile()));
			builder.Services.AddIdentity<ApplicationUser, IdentityRole>(config =>
			{
				config.User.RequireUniqueEmail = true;
				config.Password.RequiredLength = 4;
                config.Password.RequireDigit = true;
				config.Password.RequireNonAlphanumeric = true;
				config.Password.RequireUppercase = true;
				config.Password.RequireLowercase = true;
				config.Password.RequiredLength = 6;
				config.User.RequireUniqueEmail = true;
				config.Lockout.MaxFailedAccessAttempts = 3;
				config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				config.Lockout.AllowedForNewUsers = true;


            }).AddEntityFrameworkStores<CompanyDBContext>()
			  .AddDefaultTokenProviders();

			builder.Services.ConfigureApplicationCookie(options =>
			{
				options.Cookie.HttpOnly = true;
				options.ExpireTimeSpan = TimeSpan.FromMinutes(60); 
				options.SlidingExpiration = true;
				options.LoginPath = "/Account/Login";
				options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";
				options.Cookie.Name = "Company.Cookie";
				options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
				options.Cookie.SameSite = SameSiteMode.Strict;
			});


            var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();

			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseAuthentication();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
			app.Run();
		}
	}

  
}
