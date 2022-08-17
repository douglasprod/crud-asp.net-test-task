using System.Diagnostics;
using artsofte.Data;
using artsofte.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace artsofte.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationContext _dbContext;
        private readonly ILogger<IndexModel> _logger;
        public List<EmployeeDataModel> _employees = new List<EmployeeDataModel>();
        public List<LanguageDataModel> _languages = new List<LanguageDataModel>();
        public List<DepartmentDataModel> _departments = new List<DepartmentDataModel>();
        public IndexModel(ILogger<IndexModel> logger, ApplicationContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
            GetDbData();
        }

        public void OnGet()
        {
            GetDbData();
        }
        public void GetDbData()
        {
            _employees = _dbContext.Employees.ToList();
            if (_dbContext.Department.Count() <= 0) _dbContext.AddRange(Util.Util._departments);
            _departments = _dbContext.Department.ToList();
            if (_dbContext.Languages.Count() <= 0) _dbContext.AddRange(Util.Util._languages);
            _languages = _dbContext.Languages.ToList();
            _dbContext.SaveChanges();
        }
    }
}