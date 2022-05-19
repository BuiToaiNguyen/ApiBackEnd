namespace TD.CitizenAPI.Application.Catalog.BookManage;

public class CategoryBookDto : IDto
{
    public Guid Id { get; set; }
    public string NameCate { get; set; } = default!;
    public string Code { get; set; } = default!;
    public string Image { get; set; } = default!;


    public string? Description { get; set; }
    public DateTime? CreatedOn { get; set; }


}