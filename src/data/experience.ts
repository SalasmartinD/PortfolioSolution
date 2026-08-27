export type ExperienceEntry = {
  title: string;
  period: string;
  description: string;
  technologies: string[];
};

export const experience: ExperienceEntry[] = [
  {
    title: "Software Engineer Web — AranguriApps",
    period: "08/2026 - Presente",
    description:
      "Participo en el ciclo de vida completo de las aplicaciones web: diseño, implementación, despliegue y mantenimiento. Implemento herramientas basadas en inteligencia artificial para potenciar los productos, y elaboro informes de arquitectura y documentación técnica de las funcionalidades que desarrollo.",
    technologies: ["React", "TypeScript", "Supabase", "PostgreSQL", "Node.js", "IA aplicada"],
  },
  {
    title: "Desarrollador Full Stack Freelance",
    period: "05/2025 - Presente",
    description:
      "Diseño y arquitectura de soluciones de software de extremo a extremo a medida. Especializado en el desarrollo de aplicaciones web dinámicas y sistemas de gestión eficientes utilizando tanto el ecosistema moderno de JavaScript/TypeScript (React, Node.js) como la robustez de .NET. Implementación de bases de datos relacionales, integraciones cloud con Supabase y automatizaciones de procesos orientadas a maximizar la operatividad del cliente.",
    technologies: [
      "TypeScript",
      "React",
      "Node.js",
      "C# / .NET",
      "Blazor",
      "Supabase (BaaS)",
      "SQL Server / PostgreSQL",
      "GitHub / CI/CD",
    ],
  },
  {
    title: "Soporte IT en Telecomunicaciones - Cat-Technologies",
    period: "03/2026 - 06/2026",
    description:
      "Gestión y mantenimiento de infraestructura tecnológica crítica para operaciones de telecomunicaciones de alta disponibilidad. Responsable del soporte técnico de primer nivel, diagnóstico de fallas en redes, aprovisionamiento de servicios, gestión de usuarios y optimización de sistemas de comunicación para garantizar la continuidad operativa y el cumplimiento de los estándares de servicio (SLAs) de la compañía.",
    technologies: [
      "Telecomunicaciones & Redes",
      "Infraestructura de Conectividad",
      "Resolución de Incidencias (SLAs)",
    ],
  },
  {
    title: "Soporte IT - Ministerio de Educación de la Nación",
    period: "01/2026 - 03/2026",
    description:
      "Gestión de infraestructura tecnológica y soporte técnico de segundo nivel. Responsable de la configuración y despliegue de políticas de seguridad (2FA), administración de entornos Microsoft 365 y resolución de incidencias en sistemas críticos para asegurar la continuidad operativa del organismo.",
    technologies: ["2FA / Seguridad", "Windows 10/11", "Office 365 Admin", "Active Directory"],
  },
  {
    title: "Técnico de Soporte IT (Hardware & Software)",
    period: "03/2025 – 01/2026",
    description:
      "Especialista en diagnóstico y reparación física de equipos informáticos. Experiencia en ensamblado de componentes de alto rendimiento, mantenimiento preventivo de hardware y solución de conflictos de software base, optimizando el rendimiento y extendiendo el ciclo de vida de los activos tecnológicos.",
    technologies: ["Mantenimiento de Hardware", "Redes LAN", "Resolución de Incidencias"],
  },
  {
    title: "Universidad Nacional de La Matanza (UNLaM)",
    period: "Ingeniería en Informática | 2023 – Presente",
    description:
      "Formación académica centrada en la ingeniería de software de alta complejidad. Conocimientos avanzados en estructuras de datos, algoritmos, redes y seguridad informática. Miembro activo de la comunidad estudiantil de ingeniería.",
    technologies: ["C / C++", "Python", "Cisco Packet Tracer"],
  },
];
