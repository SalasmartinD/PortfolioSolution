// 📄 Portfolio.Api/Services/EmailService.cs (Usando SendGrid)

using Microsoft.Extensions.Configuration;
using Portfolio.Shared.Models;
using System.Threading.Tasks;
using SendGrid; // 💥 SendGrid Client
using SendGrid.Helpers.Mail; // 💥 Para crear el objeto Mail

namespace Portfolio.Api.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly string _recipientEmail;
        private readonly string _senderEmail;
        private readonly string _apiKey;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            var settings = _configuration.GetSection("SendGridSettings");
            
            // Cargar credenciales de SendGrid
            _apiKey = settings["ApiKey"]!; 
            _senderEmail = settings["SenderEmail"]!;
            _recipientEmail = settings["RecipientEmail"]!;
        }

        public async Task SendContactMessage(ContactMessage message)
        {
            // 1. Crear el cliente SendGrid
            var client = new SendGridClient(_apiKey);

            // 2. Definir remitente (debe ser la dirección verificada)
            var from = new EmailAddress(_senderEmail, message.Name);
            
            // 3. Definir destinatario (tú)
            var to = new EmailAddress(_recipientEmail, "Yo");
            
            // 4. Construir el contenido
            var subject = $"[PORTAFOLIO] {message.Subject}";
            var plainTextContent = $"Nombre: {message.Name} ({message.Email})\n\nMENSAJE:\n{message.Message}";
            
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, null);

            // 5. Enviar usando la API HTTP
            var response = await client.SendEmailAsync(msg);

            if (!response.IsSuccessStatusCode)
            {
                // Si SendGrid devuelve un error (ej. API Key inválida)
                var body = await response.Body.ReadAsStringAsync();
                throw new Exception($"SendGrid API Error: {response.StatusCode}. Response: {body}");
            }
        }
    }
}