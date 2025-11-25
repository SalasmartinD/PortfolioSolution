using Microsoft.AspNetCore.Mvc;
using Portfolio.Shared.Models;
using Portfolio.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly PortfolioDbContext _context;
        private readonly ILogger<ProjectsController> _logger;

        public ProjectsController(PortfolioDbContext context, ILogger<ProjectsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Project>> GetProjects()
        {
            // Consulta la tabla Projects y devuelve la lista de forma asíncrona
            return await _context.Projects.ToListAsync();
        }
    }
}