using Company.Business_Logic_Layer;
using Company.Business_Logic_Layer.Interfaces;
using Company.Business_Logic_Layer.Interfaces.Dto;
using Company.Data_Access_Layer;
using Company.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Company.Presention_Layer.Controllers
{
	public class DepartmentController: Controller
	{
		public readonly IDepartmentServices _departmentServices;

        public DepartmentController(IDepartmentServices departmentServices)
		{
            _departmentServices = departmentServices;
		}
		[HttpGet]
		public IActionResult Index()
		{
			var department = _departmentServices.GetAll();
			//TempData.Keep("TextMessage");
			return View(department);
			
		}
		[HttpGet]//Default
        public IActionResult Create() //Button
        {
            return View();
        }
		[HttpPost]
        public IActionResult Create(DepartmentDto department)
		{
			try
			{
                if (ModelState.IsValid) //matching in DataAnnotations
                {
                    _departmentServices.Add(department);
                    TempData["TextMessage"] = "Hello From Employee Index (TextMessage)";
                    return RedirectToAction(nameof(Index));

                }
				ModelState.AddModelError("DepartmentError", "Invalid Data");
				return View(department);
            }
			catch (Exception exc)
			{
                ModelState.AddModelError("DepartmentError", exc.Message);
                return View(department);
            }
		}

		public ActionResult Details(int? id ,  string viewName = "Details")
		{
			var Department = _departmentServices.GetById(id);
			if (Department == null)
				return RedirectToAction("NotFoundPage",null,"Home" );
			
			return View(viewName,Department);
		}
		[HttpGet]
		public IActionResult Update(int? id)
		{
            return Details(id, "Update");
		}
		[HttpPost]
		public IActionResult Update(int? id, DepartmentDto department)
		{
			if (department.Id != id.Value)
				return RedirectToAction("NotFoundPage", null, "Home");
			_departmentServices.Update(department);
			return RedirectToAction(nameof(Index));
		}
		
		public IActionResult Delete(int? id)
        {
           var department = _departmentServices.GetById(id);
            if (department == null)
                return RedirectToAction("NotFoundPage", null, "Home");
            _departmentServices.Delete(department);
			return RedirectToAction(nameof(Index));
        }
	


	}

   

  
}
