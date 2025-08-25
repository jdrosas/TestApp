namespace TestApp.Entitys.Dtos
{
    public class HistoryDto
    {
        public int Id { get; set; }
        public DateTime DateSearch { get; set; }
        public string? FactInfo { get; set; }
        public string? FactQuery { get; set; }
        public string? UrlGif { get; set; }
    }

    public class HistoryCreateDto
    {
        public DateTime DateSearch { get; set; }
        public string? FactInfo { get; set; }
        public string? FactQuery { get; set; }
        public string? UrlGif { get; set; }
    }
}
