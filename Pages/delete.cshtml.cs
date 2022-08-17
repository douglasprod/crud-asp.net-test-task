using artsofte.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace artsofte.Pages
{
    public class deleteModel : PageModel
    {
        private ApplicationContext _dbContext;
        public deleteModel(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            var id = Convert.ToInt32(Request.Query["id"]);
            var employee = _dbContext.Employees.FirstOrDefault(x => x.Id == id);
            if (employee == null) return;
            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
            Response.Redirect("/");
        }
    }
}
