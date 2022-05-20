namespace TD.CitizenAPI.Application.Catalog.BookManage;

public class CategoryBookDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string NameCate { get; set; } = default!;
    public string Code { get; set; } = default!;
    public string? Image { get; set; }

    public string? Description { get; set; }
    public DateTime? CreatedOn { get; set; }

}