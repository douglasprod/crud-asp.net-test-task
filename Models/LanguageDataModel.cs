namespace artsofte.Models
{
    public class LanguageDataModel
    {
        public int Id { get; set; }
        public string Language { get; set; }
        public LanguageDataModel(int id, string language)
        {
            Id = id;
            Language = language;
        }
    }
}
