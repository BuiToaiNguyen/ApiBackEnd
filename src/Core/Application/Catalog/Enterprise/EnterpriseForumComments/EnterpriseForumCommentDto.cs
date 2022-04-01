namespace TD.CitizenAPI.Application.Catalog.EnterpriseForumComments;

public class EnterpriseForumCommentDto : IDto
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string? Content { get; set; }

    public Guid? EnterpriseForumTopicId { get; set; }
}