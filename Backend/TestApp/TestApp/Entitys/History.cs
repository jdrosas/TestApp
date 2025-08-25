using System.ComponentModel.DataAnnotations;

namespace TestApp.Entitys
{
    public class History
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateSearch { get; set; }
        public string? FactInfo { get; set; }
        public string? FactQuery { get; set; }
        public string? UrlGif { get; set; }
    }
}
