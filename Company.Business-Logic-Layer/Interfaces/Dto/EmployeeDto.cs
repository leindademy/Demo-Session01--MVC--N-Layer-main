using Microsoft.AspNetCore.Http;

namespace Company.Business_Logic_Layer.Interfaces.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime HiringDate { get; set; }
        public IFormFile Image { get; set; }
        public string? ImageUrl { get; set; }
        public DepartmentDto? Department { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        

    }
}
