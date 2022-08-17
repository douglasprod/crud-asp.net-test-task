using System.Diagnostics;
using artsofte.Data;
using artsofte.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace artsofte.Pages
{
    public class editModel : PageModel
    {
        private ApplicationContext _dbContext;
        public List<LanguageDataModel> _languages = new List<LanguageDataModel>();
        public List<DepartmentDataModel> _departments = new List<DepartmentDataModel>();
        public bool isShowSuccessMessage = false;
        public string successMessage = "employee data changed";
        public string errorMessage = string.Empty;
        public EmployeeDataModel employee = new EmployeeDataModel();
        public editModel(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
            GetDbData();
        }
        public void OnGet()
        {
            var id = Convert.ToInt32(Request.Query["id"]);
            var employeeData = _dbContext.Employees.FirstOrDefault(x => x.Id == id);
            if (employeeData == null) return;
            employee = employeeData;
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
                var id = Convert.ToInt32(Request.Form["id"]);
                var employeeData = _dbContext.Employees.FirstOrDefault(x => x.Id == id);
                Debug.WriteLine($"id: {id}");
                if (employeeData == null) return;
                employeeData.Name = Request.Form["name"];
                employeeData.Surname = Request.Form["surname"];
                employeeData.Age = Convert.ToInt32(Request.Form["age"]);
                employeeData.DepartmentId = departmentId;
                employeeData.LanguageId = languageId;


                isShowSuccessMessage = true;
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
