using Company.Data_Access_Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data_A_L.Configrations
{
	public class EmployeeConfigration : IEntityTypeConfiguration<Employee>
	{
		void IEntityTypeConfiguration<Employee>.Configure(EntityTypeBuilder<Employee> builder)
		{
			builder.Property(x => x.Name).IsRequired(true).HasMaxLength(50);
		}
	}
}
