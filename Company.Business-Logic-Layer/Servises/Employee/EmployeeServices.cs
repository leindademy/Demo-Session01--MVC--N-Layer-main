using AutoMapper;
using Company.Business_Logic_Layer.Helper;
using Company.Business_Logic_Layer.Interfaces.Dto;
using Company.Data_Access_Layer;
using Company.Repository.Interfaces;

namespace Company.Business_Logic_Layer
{
	public class EmployeeDtoServices : IEmployeeServices
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public EmployeeDtoServices(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public void Add(EmployeeDto employeeDto)
		{
			//Employee employee = new Employee //Manual mapping
			//{
			//	Address = employeeDto.Address,
			//	Age = employeeDto.Age,
			//	DepartmentId = employeeDto.DepartmentId,
			//	Email = employeeDto.Email,
			//	HiringDate = employeeDto.HiringDate,
			//	Phone = employeeDto.Phone,
			//	Name = employeeDto.Name,
			//	ImageUrl = employeeDto.ImageUrl,
			//	Salary = employeeDto.Salary,
			//};
			employeeDto.ImageUrl = DocumentSettings.UploadFile(employeeDto.Image , "Images");
			Employee employee = _mapper.Map<Employee>(employeeDto);
			_unitOfWork.EmployeeRepository.Add(employee);
			_unitOfWork.Complete();
		}

		public void Delete(EmployeeDto employeeDto)
		{
			Employee employee = _mapper.Map<Employee>(employeeDto);

			_unitOfWork.EmployeeRepository.Delete(employee);
			_unitOfWork.Complete();
		}

		public IEnumerable<EmployeeDto> GetAll()
		{
			var employees = _unitOfWork.EmployeeRepository.GetAll();

			//var mappedEmployees = employees.Select(x => new EmployeeDto
			//{
			//	DepartmentId = x.DepartmentId,
			//	Email = x.Email,
			//	HiringDate = x.HiringDate,
			//	ImageUrl = x.ImageUrl,
			//	Address = x.Address,
			//	Id = x.Id,
			//	Phone = x.Phone,
			//	Age = x.Age,
			//	Salary = x.Salary,
			//	Name = x.Name,
			//});

			IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
			return mappedEmployees;

		}

		public EmployeeDto  GetById(int? id)
		{
			if (id == null) //id is null
				return null;
			var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);

			if (employee == null)
			{
                return null;
            }
			else
			{
                var Employees = _unitOfWork.EmployeeRepository.GetById(id.Value);

                if (employee == null) //department is null
                    return null;
                var EmployeeDto = _mapper.Map<EmployeeDto>(Employees);
                return EmployeeDto;
            }
			//department is null
				
			//EmployeeDto employeeDto = new EmployeeDto //Manual mapping
			//{
			//	Address = employee.Address,
			//	Age = employee.Age,
			//	DepartmentId = employee.DepartmentId,
			//	Email = employee.Email,
			//	HiringDate = employee.HiringDate,
			//	Phone = employee.Phone,
			//	Name = employee.Name,
			//	ImageUrl = employee.ImageUrl,
			//	Salary = employee.Salary,
			//	Id = employee.Id,
			//	CreateAt = employee.CreatedDate,
			//};
			
		}

		void IEmployeeServices.Update(EmployeeDto employeeDto)
		{
			//_unitOfWork.EmployeeRepository.Update(employee);
			_unitOfWork.Complete();
		}

		IEnumerable<EmployeeDto> IEmployeeServices.GetEmployeeByName(string name)
		{
			var employees = _unitOfWork.EmployeeRepository.GetEmployeeByName(name);
			//var mappedEmployees = employees.Select(x => new EmployeeDto
			//{
			//	DepartmentId = x.DepartmentId,
			//	Email = x.Email,
			//	HiringDate = x.HiringDate,
			//	ImageUrl = x.ImageUrl,
			//	CreateAt = x.CreatedDate,
			//	Address = x.Address,
			//	Id = x.Id,
			//	Phone = x.Phone,
			//	Age = x.Age,
			//	Salary = x.Salary,
			//	Name = x.Name,
			//});
			IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
			return mappedEmployees;

		}

        
    }
}
	
