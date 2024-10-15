using Company.Business_Logic_Layer.Interfaces.Dto;
namespace Company.Business_Logic_Layer
{
    public interface IEmployeeServices
	{
		EmployeeDto GetById(int? id);
		IEnumerable<EmployeeDto> GetAll();
		void Add(EmployeeDto employee);
		void Update(EmployeeDto employee);
		void Delete(EmployeeDto employee);
		IEnumerable<EmployeeDto> GetEmployeeByName(string Name);
	}
}
