namespace TestApp.Entitys.Dtos
{
    public class GiphyDataWrapper
    {
        public List<GifDto>? Data { get; set; }
    }

    public class GifDto
    {
        public string? Type { get; set; }
        public string? Id { get; set; }
        public string? Url { get; set; }
        public string? Title { get; set; }
        public ImagesDto? Images { get; set; }
    }

    public class ImagesDto
    {
        public OriginalDto? Original { get; set; }
    }

    public class OriginalDto
    {
        public string? Url { get; set; }
        public string? Width { get; set; }
        public string? Height { get; set; }
        public string? Size { get; set; }
    }

}
