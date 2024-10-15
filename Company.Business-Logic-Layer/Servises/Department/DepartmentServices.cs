
using AutoMapper;
using Company.Business_Logic_Layer.Interfaces;
using Company.Business_Logic_Layer.Interfaces.Dto;
using Company.Data_Access_Layer;
using Company.Repository.Interfaces;

namespace Company.Business_Logic_Layer

{
    public class DepartmentDtoServices : IDepartmentServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentDtoServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(DepartmentDto departmentDto)
        {
            //var mappedDepartment = new Department //mapping
            //{
            //    Name = department.Name,
            //    Code = department.Code,
            //    CreatedDate = DateTime.Now

            //};
            Department department = _mapper.Map<Department>(departmentDto);
            _unitOfWork.DepartmentRepository.Add(department);
            _unitOfWork.Complete();
        }

        void IDepartmentServices.Delete(DepartmentDto departmentDto)
        {
            //Department department = new Department
            //{
            //    Name = departmentDto.Name,
            //    Code = departmentDto.Code,
            //    CreatedDate = DateTime.Now,

            //};
            Department department = _mapper.Map<Department>(departmentDto);
            _unitOfWork.DepartmentRepository.Delete(department);
            _unitOfWork.Complete();
        }


        public IEnumerable<DepartmentDto> GetAll()
        {
            var department = _unitOfWork.DepartmentRepository.GetAll();
            //var mappedDepartment = department.Select(x => new DepartmentDto
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Code = x.Code,
            //    CreateAt = x.CreatedDate,
            //});
            IEnumerable<DepartmentDto> mappedDepartment = _mapper.Map<IEnumerable<DepartmentDto>>(department);
            return mappedDepartment;
        }

        DepartmentDto IDepartmentServices.GetById(int? id)
        {
            if (id == null)
                return null;

            var department = _unitOfWork.DepartmentRepository.GetById(id.Value);

            if (department == null)
            //department is null

            {
                return null;
            }
            else
            {
                var departments = _unitOfWork.DepartmentRepository.GetById(id.Value);

                if (department == null) //department is null
                    return null;
                var departmentDto = _mapper.Map<DepartmentDto>(departments);

                return departmentDto;
            }
            return null;
        }

        public void Update(DepartmentDto department)
        {
            // _unitOfWork.DepartmentRepository.Update(department);
            _unitOfWork.Complete();
        }

      
    }
}
