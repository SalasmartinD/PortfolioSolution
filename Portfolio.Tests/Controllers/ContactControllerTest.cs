// 📄 Portfolio.Tests/Controllers/ContactControllerTests.cs

using Xunit;
using Moq; // Necesario para crear simulacros
using Microsoft.AspNetCore.Mvc; // Para IActionResult, OkObjectResult, etc.
using Microsoft.Extensions.Logging;
using Portfolio.Api.Controllers;
using Portfolio.Api.Services; // Para IEmailService
using Portfolio.Shared.Models;
using System.Threading.Tasks;

namespace Portfolio.Tests.Controllers
{
    public class ContactControllerTests
    {
        [Fact] // Este atributo indica que este es un método de prueba
        public async Task Post_ValidMessage_ReturnsOkAndCallsEmailService()
        {
            // Arrange (Preparación: Definir las dependencias simuladas)
            
            // Simular el servicio de email (NO enviará un correo real)
            var mockEmailService = new Mock<IEmailService>();
            var mockLogger = new Mock<ILogger<ContactController>>();
            
            // Crear el controlador, inyectando las simulaciones
            var controller = new ContactController(mockLogger.Object, mockEmailService.Object);
            
            var validMessage = new ContactMessage
            {
                Name = "Daniel Salas",
                Email = "test@unlam.edu.ar",
                Subject = "Consulta de Portafolio",
                Message = "Me interesa tu proyecto UoW."
            };

            // Act (Acción: Ejecutar el código a probar)
            var result = await controller.Post(validMessage);

            // Assert (Verificación: Comprobar el resultado)
            
            // 1. Verificar el estado HTTP: ¿Es 200 OK?
            Assert.IsType<OkObjectResult>(result);
            
            // 2. 💥 VERIFICAR LA INTERACCIÓN CRÍTICA (Moq) 💥
            // Asegurarse de que el servicio de email FUE LLAMADO exactamente una vez.
            mockEmailService.Verify(service => service.SendContactMessage(validMessage), Times.Once());
        }

        [Fact] 
        public async Task Post_InvalidMessage_ReturnsBadRequestAndDoesNotCallEmailService()
        {
            // Arrange
            var mockEmailService = new Mock<IEmailService>();
            var mockLogger = new Mock<ILogger<ContactController>>();
            var controller = new ContactController(mockLogger.Object, mockEmailService.Object);
            
            // Crear mensaje inválido (Falta el campo Email, lo cual es requerido)
            var invalidMessage = new ContactMessage { Name = "Tester", Subject = "Error", Message = "Test" };
            
            // 💥 Simular la falla de la validación del modelo 💥
            controller.ModelState.AddModelError("Email", "El email es obligatorio.");

            // Act
            var result = await controller.Post(invalidMessage);

            // Assert
            // 1. Verificar el estado HTTP: ¿Es 400 Bad Request?
            Assert.IsType<BadRequestObjectResult>(result);
            
            // 2. Verificar la interacción (Moq): Asegurarse de que el servicio de email NUNCA fue llamado.
            mockEmailService.Verify(service => service.SendContactMessage(It.IsAny<ContactMessage>()), Times.Never());
        }
    }
}