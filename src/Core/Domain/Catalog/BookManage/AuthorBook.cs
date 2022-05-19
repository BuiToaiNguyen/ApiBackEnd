namespace TD.CitizenAPI.Domain.Catalog;

public class AuthorBook : AuditableEntity, IAggregateRoot
{
    public string NameAuthor { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }

    public int? Age { get; set; }
    public string? Image { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Book>? Books { get; set; }

    public AuthorBook(string nameAuthor, string? code, string? description, int? age, string? address, string? image)
    {
        NameAuthor = nameAuthor;
        Code = code;
        Description = description;
        Age = age;
        Address = address;
        Image = image;

    }

    public AuthorBook Update(string? nameAuthor, string? code, string? description,int? age, string? address, string? image)
    {
        if (nameAuthor is not null && NameAuthor?.Equals(nameAuthor) is not true) NameAuthor = nameAuthor;
        if (code is not null && Code?.Equals(code) is not true) Code = code;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        if (age is not null && Age?.Equals(age) is not true) Age = age;
        if (image is not null && Image?.Equals(image) is not true) Image = image;
        if (address is not null && Address?.Equals(address) is not true) Address = address;

        return this;
    }
}