using System.Diagnostics;
using artsofte.Data;
using artsofte.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace artsofte.Pages
{
    public class AddEmployeeModel : PageModel
    {
        private ApplicationContext _dbContext;
        public List<LanguageDataModel> _languages = new List<LanguageDataModel>();
        public List<DepartmentDataModel> _departments = new List<DepartmentDataModel>();
        public bool isShowSuccessMessage = false;
        public string successMessage = "employee added to database";
        public string errorMessage = string.Empty;
        public EmployeeDataModel employee = new EmployeeDataModel();
        public AddEmployeeModel(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
            GetDbData();
        }
        public void OnGet()
        {
            GetDbData();
        }

        public void OnPost()
        {
            try
            {
                if (Request.Form["name"] == string.Empty || Request.Form["surname"] == string.Empty ||
                    Request.Form["age"] == string.Empty)
                {

                    errorMessage = "all columns required";
                    return;
                }
                var departmentId = int.Parse(Request.Form["department"]);
                var languageId = int.Parse(Request.Form["language"]);
                employee.Name = Request.Form["name"];
                employee.Surname = Request.Form["surname"];
                employee.Age = Convert.ToInt32(Request.Form["age"]);
                

                employee.DepartmentId = departmentId;
                employee.LanguageId = languageId;
                isShowSuccessMessage = true;
                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();
                Response.Redirect("/");
            }
            catch
            {
                new Exception("something went wrong");
            }
        }

        public void GetDbData()
        {
            if (_dbContext.Department.Count() <= 0) _dbContext.AddRange(Util.Util._departments);
            _departments = _dbContext.Department.ToList();
            if (_dbContext.Languages.Count() <= 0) _dbContext.AddRange(Util.Util._languages);
            _languages = _dbContext.Languages.ToList();
            _dbContext.SaveChanges();
        }
    }
}
