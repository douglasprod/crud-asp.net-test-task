namespace artsofte.Models
{
    public class DepartmentDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DepartmentDataModel(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
