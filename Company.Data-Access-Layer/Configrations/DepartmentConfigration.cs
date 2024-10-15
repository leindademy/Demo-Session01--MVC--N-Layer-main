using Company.Data_Access_Layer;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data_A_L.Configrations
{
	public class DepartmentConfigration: IEntityTypeConfiguration<Department>
	{
		void IEntityTypeConfiguration<Department>.Configure(EntityTypeBuilder<Department> builder)
		{
			builder.Property(x=> x.Id).IsRequired().UseIdentityColumn(1,10);
			builder.HasIndex(x => x.Id).IsUnique();
		}
	}
}
