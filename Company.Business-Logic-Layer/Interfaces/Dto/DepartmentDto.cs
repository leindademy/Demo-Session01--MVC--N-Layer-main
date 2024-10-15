namespace Company.Business_Logic_Layer.Interfaces.Dto
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime CreateAt { get; set; }
        ICollection<EmployeeDto> Employee { get; set; } = new List<EmployeeDto>();
    }
}
