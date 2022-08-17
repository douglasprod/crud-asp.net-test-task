namespace artsofte.Models
{
    public class EmployeeDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname   { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public int LanguageId { get; set; }
    }
}