using Company.Data_Access_Layer;
using Company.Data_Access_Layer.Context;
using Company.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
	public class DepartmentRepository: GenericRepository<Department>, IDepartmentRepository
	{

		//public CompanyDBContext context { get; set; }//property injection
		public DepartmentRepository(CompanyDBContext context) : base(context)
		{
			
		}

     
    }
}

