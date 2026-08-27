import { FaFolderOpen, FaExclamationTriangle } from "react-icons/fa";
import { getProjects } from "@/lib/supabase";
import ProjectCard from "./ProjectCard";

export const revalidate = 3600;

export default async function ProjectsSection() {
  let projects: Awaited<ReturnType<typeof getProjects>> = [];
  let errorMessage: string | null = null;

  try {
    projects = await getProjects();
  } catch (err) {
    errorMessage = err instanceof Error ? err.message : "Error desconocido.";
  }

  return (
    <section id="projects" className="py-10 animate-fade-in-up delay-4">
      <h2 className="text-3xl lg:text-4xl font-bold text-[var(--text-primary)] mb-2 text-center">
        Proyectos
      </h2>
      <p className="text-[var(--text-secondary)] text-center mb-10">
        Estos proyectos demuestran mi experiencia en el desarrollo de aplicaciones robustas implementando
        buenas prácticas.
      </p>

      {errorMessage ? (
        <div className="rounded-xl border border-red-500/20 bg-red-500/5 p-6 text-center">
          <p className="flex items-center justify-center gap-2 font-bold text-red-400 mb-2">
            <FaExclamationTriangle /> Error al cargar proyectos
          </p>
          <p className="text-sm text-[var(--text-secondary)]">Detalle técnico: {errorMessage}</p>
        </div>
      ) : projects.length === 0 ? (
        <div className="flex flex-col items-center gap-3 py-10 text-[var(--text-secondary)]">
          <FaFolderOpen size={32} />
          <p>No se encontraron proyectos registrados en este momento.</p>
        </div>
      ) : (
        <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
          {projects.map((project) => (
            <ProjectCard key={project.id} project={project} />
          ))}
        </div>
      )}
    </section>
  );
}
