// 📄 Portfolio.Api/Controllers/ContactController.cs
using Microsoft.AspNetCore.Mvc; 
using Microsoft.Extensions.Logging;
using Portfolio.Shared.Models; // Para ContactMessage
using Portfolio.Api.Services; // Para IEmailService

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly ILogger<ContactController> _logger;
    private readonly IEmailService _emailService;

    // Constructor con la nueva dependencia
    public ContactController(ILogger<ContactController> logger, IEmailService emailService) 
    {
        _logger = logger;
        _emailService = emailService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> Post([FromBody] ContactMessage message) 
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            // 💥 LLAMADA REAL AL SERVICIO DE CORREO 💥
            await _emailService.SendContactMessage(message);

            _logger.LogInformation("NUEVO MENSAJE DE CONTACTO ENVIADO CON ÉXITO.");
            return Ok(new { Status = "Success", Message = "Mensaje enviado correctamente." });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "ERROR al enviar el correo a través de SMTP.");
            // Si hay un error, el API devuelve un 500 para evitar que el cliente se bloquee.
            return StatusCode(500, new { Status = "Error", Message = "Fallo interno del servidor al enviar el correo." });
        }
    }
}