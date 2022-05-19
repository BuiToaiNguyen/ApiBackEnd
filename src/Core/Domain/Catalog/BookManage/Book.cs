namespace TD.CitizenAPI.Domain.Catalog;
public class Book : AuditableEntity, IAggregateRoot
{
    public string NameBook { get; set; }
    public string? CodeBook { get; set; }
    public string? Description { get; set; }

    public float? Price { get; set; }
    public string? Image { get; set; }
    public Guid? AuthorId { get; set; }
    public Guid? CategoryId { get; set; }

    public virtual AuthorBook? AuthorBook { get; set; }
    public virtual CategoryBook? CategoryBook { get; set; }


    public Book(string nameBook, string? codeBook, string? description, Guid? authorId,float? price, Guid? categoryId,string? image)
    {
        NameBook = nameBook;
        CodeBook = codeBook;
        Description = description;
        AuthorId = authorId;
        Price=price;
        CategoryId = categoryId;
        Image = image;

    }

    public Book Update(string nameBook, string? codeBook, string? description, Guid? authorId, float? price, Guid? categoryId, string? image)
    {
        if (nameBook is not null && NameBook?.Equals(nameBook) is not true) NameBook = nameBook;
        if (image is not null && Image?.Equals(image) is not true) Image = image;
        if (codeBook is not null && CodeBook?.Equals(codeBook) is not true) CodeBook = codeBook;
        if (price is not null && Price?.Equals(price) is not true) Price = price;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        if (authorId.HasValue && authorId.Value != Guid.Empty && !AuthorId.Equals(authorId.Value)) AuthorId = authorId.Value;
        if (categoryId.HasValue && categoryId.Value != Guid.Empty && !CategoryId.Equals(categoryId.Value)) CategoryId = categoryId.Value;
        return this;
    }

}