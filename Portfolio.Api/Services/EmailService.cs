using Microsoft.Extensions.Configuration;
using Portfolio.Shared.Models;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Logging; // 💥 Necesario para los logs

namespace Portfolio.Api.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly string _recipientEmail;
        private readonly ILogger<EmailService> _logger; // 💥 Nuevo Logger

        // Actualiza el constructor para recibir el Logger
        public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
        {
            _configuration = configuration;
            _recipientEmail = _configuration["SmtpSettings:RecipientEmail"]!;
            _logger = logger;
        }

        public async Task SendContactMessage(ContactMessage message)
        {
            var smtpSettings = _configuration.GetSection("SmtpSettings");
            var host = smtpSettings["Host"];
            var port = int.Parse(smtpSettings["Port"]!);
            var username = smtpSettings["Username"];
            var password = smtpSettings["Password"];
            var sender = smtpSettings["SenderEmail"];

            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Portafolio", sender));
            email.To.Add(new MailboxAddress("Yo", _recipientEmail));
            email.Subject = $"[PORTAFOLIO] {message.Subject}";

            var bodyBuilder = new BodyBuilder
            {
                TextBody = $"Nombre: {message.Name}\nEmail: {message.Email}\n\nMENSAJE:\n{message.Message}"
            };
            email.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                // Aceptar certificados SSL (útil en Docker)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                try 
                {
                    _logger.LogInformation($"1. Conectando a SMTP: {host}:{port}...");
                    
                    // 💥 CAMBIO CLAVE: useSsl = true (Para puerto 465) 💥
                    // Si usas 465, el tercer parámetro debe ser 'true'. Si usas 587, es 'false'.
                    // Vamos a forzar el uso de SSL implícito si el puerto es 465.
                    bool useSsl = port == 465;
                    
                    await client.ConnectAsync(host, port, useSsl);
                    _logger.LogInformation("2. Conectado. Autenticando...");

                    await client.AuthenticateAsync(username, password);
                    _logger.LogInformation("3. Autenticado. Enviando...");

                    await client.SendAsync(email);
                    _logger.LogInformation("4. ¡Enviado!");

                    await client.DisconnectAsync(true);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"ERROR SMTP CRÍTICO: {ex.Message}");
                    throw; // Re-lanzar para que el controlador lo capture
                }
            }
        }
    }
}