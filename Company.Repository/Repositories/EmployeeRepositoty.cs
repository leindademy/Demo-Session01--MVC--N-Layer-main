using Company.Data_Access_Layer;
using Company.Data_Access_Layer.Context;
using Company.Repository.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    public class EmployeeRepositoty : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly CompanyDBContext _context;

        //public CompanyDBContext context { get; set; }//property injection
        public EmployeeRepositoty(CompanyDBContext context) : base(context)
        {
            _context = context;
        }


        public IEnumerable<Employee> GetEmployeeByName(string name)

          => _context.Employees.Where(x =>
            x.Name.Trim().ToLower().Contains(name.Trim().ToLower()) ||
            x.Email.Trim().ToLower().Contains(name.Trim().ToLower()) ||
            x.Phone.Trim().ToLower().Contains(name.Trim().ToLower())
            ).ToList();


        public IEnumerable<Employee> GetEmployeeByAddress(string address)
        {
            return _context.Employees.Where(x => x.Address == address).ToList();
        }
    }
}


