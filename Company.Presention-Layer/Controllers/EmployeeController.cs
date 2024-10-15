using Company.Business_Logic_Layer;
using Company.Business_Logic_Layer.Interfaces;
using Company.Business_Logic_Layer.Interfaces.Dto;
using Company.Data_Access_Layer;
using Company.Presention_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Company.Presention_Layer.Controllers
{
	public class EmployeeController : Controller
	{
		public readonly IEmployeeServices _EmployeeServices;
        public readonly IDepartmentServices _DepartmentServices;

        public EmployeeController(IEmployeeServices EmployeeDtoServices,IDepartmentServices departmentServices)
		{
			_EmployeeServices = EmployeeDtoServices;
			_DepartmentServices = departmentServices;
		}
		
		public IActionResult Index(string searchInp)
		{
            IEnumerable<EmployeeDto> EmployeeDto = new List<EmployeeDto>();
			if(string.IsNullOrEmpty(searchInp)) //NULL OR EMPTY
                return View(_EmployeeServices.GetAll());
            else
				 EmployeeDto = _EmployeeServices.GetEmployeeByName(searchInp);
                return View(EmployeeDto); 
		}
	
		[HttpGet]
		public IActionResult Create()
		{
            var departments_list = _DepartmentServices.GetAll();
            var departments = new SelectList(departments_list, nameof(Department.Id), nameof(Department.Name));
            //ViewData  ViewBag  TempData
            ViewBag.Departments = departments;
			return View();
		}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeDto employee)
        {
            try
            {
                if (ModelState.IsValid) //matching in DataAnnotations
                {
                    _EmployeeServices.Add(employee);
                    return RedirectToAction(nameof(Index));
                }
                return View(employee);
            }
            catch (Exception exc)
            {
                return View(employee);
            }
        }

        //	public ActionResult Details(int? id, string viewName = "Details")
        //	{
        //		var EmployeeDto = _EmployeeDtoServices.GetById(id);
        //		if (EmployeeDto == null)
        //			return RedirectToAction("NotFoundPage", null, "Home");

        //		return View(viewName, EmployeeDto);
        //	}

        //	[HttpGet]
        //	public IActionResult Update(int? id)
        //	{
        //		return Details(id, "Update");
        //	}
        //	[HttpPost]
        //	public IActionResult Update(int? id, EmployeeDto EmployeeDto)
        //	{
        //		if (EmployeeDto.Id != id.Value)
        //			return RedirectToAction("NotFoundPage", null, "Home");
        //		_EmployeeDtoServices.Update(EmployeeDto);
        //		return RedirectToAction(nameof(Index));
        //	}

        //	public IActionResult Delete(int? id)
        //	{
        //		var EmployeeDto = _EmployeeDtoServices.GetById(id);
        //		if (EmployeeDto == null)
        //			return RedirectToAction("NotFoundPage", null, "Home");
        //		_EmployeeDtoServices.Delete(EmployeeDto);
        //		return RedirectToAction(nameof(Index));
        //	}
    }
}
