using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data_Access_Layer
{
	public class BaseEntity  // Recurring_Entity
	{
		public int Id { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public bool IsDeleted { get; set; }  // Default bool = false
	}
}
