namespace TD.CitizenAPI.Application.Common.Mailing;

public interface IMailService : ITransientService
{
    Task SendAsync(MailRequest request);
}