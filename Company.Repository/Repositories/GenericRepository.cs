using Company.Repository.Interfaces;
using Company.Data_Access_Layer;
using Company.Data_Access_Layer.Context;

namespace Company.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		public readonly CompanyDBContext _context;

		public GenericRepository(CompanyDBContext context) //constructor
			=>_context = context;
		
		public void Add(T entity)
			=>_context.Set<T>().Add(entity);
	

		public void Delete(T entity)
            =>_context.Set<T>().Remove(entity);
		

		public IEnumerable<T> GetAll()
			=>_context.Set<T>().ToList();
		

		public T GetById(int id)
			=>_context.Set<T>().Find(id);
		

		public void Update(T entity)
			=>_context.Set<T>().Update(entity);	
		
	}
}
