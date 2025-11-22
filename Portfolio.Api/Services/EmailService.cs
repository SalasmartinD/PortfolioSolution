// 📄 Portfolio.Api/Services/EmailService.cs

using Microsoft.Extensions.Configuration;
using Portfolio.Shared.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Portfolio.Api.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly string _recipientEmail;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            // Leer la dirección de recepción de appsettings.json
            _recipientEmail = _configuration["SmtpSettings:RecipientEmail"]!;
        }

        public async Task SendContactMessage(ContactMessage message)
        {
            var smtpSettings = _configuration.GetSection("SmtpSettings");
            
            // Usar dispose para asegurar que la conexión se cierre
            using (var client = new SmtpClient(smtpSettings["Host"], int.Parse(smtpSettings["Port"]!)))
            {
                client.EnableSsl = true; 
                client.Credentials = new NetworkCredential(smtpSettings["Username"], smtpSettings["Password"]);

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpSettings["SenderEmail"]!, message.Name),
                    Subject = $"[PORTAFOLIO] Mensaje de: {message.Name} - {message.Subject}",
                    Body = $"De: {message.Name} ({message.Email})\n\n{message.Message}",
                    IsBodyHtml = false
                };

                mailMessage.To.Add(_recipientEmail);

                // Envía el correo de forma asíncrona
                await client.SendMailAsync(mailMessage);
            }
        }
    }
}