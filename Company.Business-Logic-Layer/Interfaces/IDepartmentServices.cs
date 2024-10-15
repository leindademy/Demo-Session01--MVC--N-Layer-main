using Company.Business_Logic_Layer.Interfaces.Dto;
namespace Company.Business_Logic_Layer
{
    public interface IDepartmentServices
{
        DepartmentDto GetById(int? id);
        IEnumerable<DepartmentDto> GetAll();
        void Add(DepartmentDto Department);
        void Update(DepartmentDto Department);
        void Delete(DepartmentDto Department);
    }
}
