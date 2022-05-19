namespace TD.CitizenAPI.Application.Catalog.BookManage;

public class BookDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string NameBook { get; set; }
    public string? CodeBook { get; set; }
    public string? Description { get; set; }
    public float? Price { get; set; }
    public string? Image { get; set; }
    public Guid? AuthorId { get; set; }
    public Guid? CategoryId { get; set; }
    public DateTime? CreatedOn { get; set; }
    public virtual CategoryBookDto? oneCategoryBook { get; set; }



}