namespace TD.CitizenAPI.Application.Catalog.BookManage;

public class AuthorBookDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string NameAuthor { get; set; } = default!;
    public string? Code { get; set; }
    public string? Description { get; set; }

    public int? Age { get; set; }
    public string? Image { get; set; }

    public string? Address { get; set; }
}