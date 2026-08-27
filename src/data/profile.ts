export const profile = {
  name: "Salas Martín Daniel",
  role: "Software Engineer Full-Stack",
  tagline:
    "Apasionado por el desarrollo de software y la innovación tecnológica. Construyendo el futuro, un código a la vez.",
  aboutParagraphs: [
    "Software Engineer Full-Stack enfocado en el desarrollo de aplicaciones web modernas y en la integración de inteligencia artificial en productos reales. Estudiante avanzado de Ingeniería en Informática en la UNLaM (50% de la carrera aprobada), combino formación académica con experiencia profesional del día a día.",
    "Actualmente trabajo en AranguriApps como Software Engineer Web, donde participo en el ciclo de vida completo de las aplicaciones: desde el diseño y la implementación hasta el despliegue y el mantenimiento. Implemento herramientas basadas en IA para potenciar los productos en los que trabajo, y soy responsable de generar informes de arquitectura y documentación técnica de las funcionalidades que desarrollo, algo que considero clave para ordenar el conocimiento del equipo y facilitar el trabajo a futuro.",
    "Trabajo principalmente con React, TypeScript y Supabase (PostgreSQL), construyendo interfaces sólidas y APIs bien pensadas. En paralelo, desarrollo proyectos de forma independiente para clientes particulares, lo que me llevó a manejar todo el proceso por mi cuenta: relevar necesidades, diseñar la solución, programarla y acompañar al cliente después de la entrega.",
    "Tengo además experiencia construyendo proyectos propios con C#, .NET y Blazor, incluyendo APIs REST desde cero, lo que me dio una base sólida en programación orientada a objetos y arquitectura backend más allá de mi stack principal actual. Me interesa seguir creciendo como desarrollador full-stack, sumando proyectos donde pueda aportar tanto en el código como en las decisiones de arquitectura.",
  ],
  contact: {
    email: "salasmartindaniel0@gmail.com",
    github: "https://github.com/SalasmartinD",
    githubHandle: "SalasmartinD",
    linkedin: "https://www.linkedin.com/in/martíndanielsalas",
    linkedinName: "Salas Martín Daniel",
    whatsapp: "https://wa.me/5491127646848",
    whatsappNumber: "+54 9 11 2764-6848",
  },
} as const;

export const navSections = [
  { id: "about", label: "Sobre Mí" },
  { id: "experience", label: "Experiencia" },
  { id: "projects", label: "Proyectos" },
  { id: "contact", label: "Contacto" },
] as const;
