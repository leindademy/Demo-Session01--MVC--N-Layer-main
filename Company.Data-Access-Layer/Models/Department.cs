using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data_Access_Layer
{
	public class Department:BaseEntity
	{
		public string Name { get; set; }
		public string Code { get; set; }
		ICollection<Employee> Employee { get; set; } = new List<Employee>();


	}
}