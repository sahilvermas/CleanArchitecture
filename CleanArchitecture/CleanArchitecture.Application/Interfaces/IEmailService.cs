using System.Threading.Tasks;
using CleanArchitecture.Application.DTOs.Email;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}