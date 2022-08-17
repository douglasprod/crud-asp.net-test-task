using artsofte.Models;

namespace artsofte.Util
{
    public static class Util
    {
        public static List<LanguageDataModel> _languages = new List<LanguageDataModel>
        {
            new LanguageDataModel(1, "c#"),
            new LanguageDataModel(1, "java"),
            new LanguageDataModel(1, "javascript"),
            new LanguageDataModel(1, "c++"),
            new LanguageDataModel(1, "python"),
            new LanguageDataModel(1, "ruby")
        };

        public static List<DepartmentDataModel> _departments = new List<DepartmentDataModel>
        {
            new DepartmentDataModel(1, "department 1"),
            new DepartmentDataModel(2, "department 2"),
            new DepartmentDataModel(3, "department 3")
        };
    }
}
