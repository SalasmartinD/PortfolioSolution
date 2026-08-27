import { profile } from "@/data/profile";

export default function AboutSection() {
  return (
    <section id="about" className="py-10 animate-fade-in-up delay-2">
      <h2 className="text-3xl lg:text-4xl font-bold text-[var(--text-primary)] mb-8 text-center">
        Sobre Mí
      </h2>
      <div className="space-y-4">
        {profile.aboutParagraphs.map((paragraph) => (
          <p key={paragraph.slice(0, 24)} className="text-[var(--text-secondary)] text-lg leading-relaxed">
            {paragraph}
          </p>
        ))}
      </div>
    </section>
  );
}
