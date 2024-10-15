using AutoMapper;
using Company.Business_Logic_Layer.Interfaces.Dto;
using Company.Data_Access_Layer;

namespace Company.Business_Logic_Layer.Mapping
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap(); //To Way Mapping
        }
    }
}
