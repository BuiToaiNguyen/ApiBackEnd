namespace TD.CitizenAPI.Application.Catalog.BookManage;

public class CategoryBookDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string NameCate { get; set; } = default!;
    public string Code { get; set; } = default!;
    public string image { get; set; } = default!;

    public string? Description { get; set; }
    public DateTime? CreatedOn { get; set; }
    //public virtual ICollection<BookDto>? ListBooks { get; set; }


}