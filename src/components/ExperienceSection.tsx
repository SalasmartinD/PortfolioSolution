import { experience } from "@/data/experience";

export default function ExperienceSection() {
  return (
    <section id="experience" className="py-10 animate-fade-in-up delay-3">
      <h2 className="text-2xl lg:text-3xl font-bold text-[var(--primary)] mb-8 text-center">
        Educación y Experiencia
      </h2>

      <div className="experience-list">
        {experience.map((entry) => (
          <article key={entry.title} className="experience-card">
            <h3 className="font-bold text-[var(--text-primary)] mb-1">{entry.title}</h3>
            <p className="text-sm text-[var(--text-secondary)]/80 mb-2">{entry.period}</p>
            <p className="text-[var(--text-secondary)] leading-relaxed">{entry.description}</p>
            <div className="mt-3 flex flex-wrap gap-2">
              {entry.technologies.map((tech) => (
                <span key={tech} className="tech-badge">
                  {tech}
                </span>
              ))}
            </div>
          </article>
        ))}
      </div>
    </section>
  );
}
