namespace TD.CitizenAPI.Domain.Catalog;

public class CategoryBook : AuditableEntity, IAggregateRoot
{
    public string NameCate { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }

    public virtual ICollection<Book>? Books { get; set; }





    public CategoryBook(string nameCate, string? code, string? description, string? image)
    {
        NameCate = nameCate;
        Code = code;
        Description = description;
        Image = image;


    }

    public CategoryBook Update(string nameCate, string? code, string? description, string? image)
    {
        if (nameCate is not null && NameCate?.Equals(nameCate) is not true) NameCate = nameCate;
        if (code is not null && Code?.Equals(code) is not true) Code = code;
        if (image is not null && Image?.Equals(image) is not true) Image = image;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        return this;
    }
}