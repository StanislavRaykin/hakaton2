namespace hakaton2.Models.Models;

public class BlogViewModel
{
    public string Title { get; set; } = "";
    public string Excerpt { get; set; } = "";
    public string Slug { get; set; } = "";
    public DateTime Published { get; set; } = DateTime.UtcNow;
    public string Category { get; set; } = "Общо";
    public string ContentHtml { get; set; } = "";
}