namespace Portfolio.Shared.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        // Asumiendo que Technologies es una lista de strings para el frontend
        public string Technologies { get; set; } = string.Empty;
        public string GitHubUrl { get; set; } = string.Empty;
        public string? LiveDemoUrl { get; set; } = string.Empty;
    }
}