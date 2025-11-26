using Microsoft.Extensions.Configuration;
using Portfolio.Shared.Models;
using System.Threading.Tasks;
using MailKit.Net.Smtp; // 💥 USAMOS MAILKIT
using MimeKit;          // 💥 USAMOS MIMEKIT
using MailKit.Security;

namespace Portfolio.Api.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly string _recipientEmail;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            _recipientEmail = _configuration["SmtpSettings:RecipientEmail"]!;
        }

        public async Task SendContactMessage(ContactMessage message)
        {
            var smtpSettings = _configuration.GetSection("SmtpSettings");

            // 1. Crear el mensaje con MimeKit
            var email = new MimeMessage();
            
            // Remitente (Tu cuenta de Gmail)
            email.From.Add(new MailboxAddress("Portafolio Contacto", smtpSettings["SenderEmail"]));
            // Destinatario (Tú)
            email.To.Add(new MailboxAddress("Yo", _recipientEmail));
            
            email.Subject = $"[PORTAFOLIO] {message.Subject}";

            var bodyBuilder = new BodyBuilder
            {
                TextBody = $"Nombre: {message.Name}\nEmail: {message.Email}\n\nMENSAJE:\n{message.Message}"
            };
            email.Body = bodyBuilder.ToMessageBody();

            // 2. Enviar con MailKit (SmtpClient)
            using (var client = new SmtpClient())
            {
                // Aceptar certificados SSL aunque haya problemas menores (útil en Docker)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                // Conectar a Gmail (Puerto 587, StartTls)
                await client.ConnectAsync(smtpSettings["Host"], int.Parse(smtpSettings["Port"]!), SecureSocketOptions.StartTls);

                // Autenticar
                await client.AuthenticateAsync(smtpSettings["Username"], smtpSettings["Password"]);

                // Enviar
                await client.SendAsync(email);

                // Desconectar limpiamente
                await client.DisconnectAsync(true);
            }
        }
    }
}