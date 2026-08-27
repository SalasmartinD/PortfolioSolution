import { FaFolder, FaExternalLinkAlt, FaGithub, FaLock } from "react-icons/fa";
import type { Project } from "@/types/project";

export default function ProjectCard({ project }: { project: Project }) {
  const technologies = project.technologies
    ? project.technologies.split(",").map((tech) => tech.trim()).filter(Boolean)
    : [];

  return (
    <div className="glass-card flex h-full flex-col p-6">
      <h3 className="flex items-center gap-2 text-lg font-bold text-[var(--text-primary)] mb-3">
        <FaFolder className="text-[var(--primary)]" /> {project.title}
      </h3>

      <p className="project-description flex-grow mb-4">{project.short_description}</p>

      {technologies.length > 0 && (
        <>
          <h4 className="text-xs font-bold uppercase tracking-wide text-[var(--text-secondary)] mb-2">
            Tecnologías Clave
          </h4>
          <div className="project-technologies mb-4">
            {technologies.map((tech) => (
              <span key={tech} className="tech-badge">
                {tech}
              </span>
            ))}
          </div>
        </>
      )}

      <div className="mt-auto flex flex-col gap-2 pt-2">
        {project.live_demo_url && (
          <a
            href={project.live_demo_url}
            target="_blank"
            rel="noreferrer"
            className="btn-outline"
          >
            <FaExternalLinkAlt /> Demo en Vivo
          </a>
        )}
        {project.github_url ? (
          <a href={project.github_url} target="_blank" rel="noreferrer" className="btn-gradient">
            <FaGithub /> Código Fuente
          </a>
        ) : (
          <button className="btn-outline opacity-60 cursor-not-allowed" disabled>
            <FaLock /> Repositorio Privado
          </button>
        )}
      </div>
    </div>
  );
}
