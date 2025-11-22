// 📄 Portfolio.Api/Services/IEmailService.cs

using Portfolio.Shared.Models;
using System.Threading.Tasks;

namespace Portfolio.Api.Services
{
    public interface IEmailService
    {
        Task SendContactMessage(ContactMessage message);
    }
}