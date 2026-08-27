import AboutSection from "@/components/AboutSection";
import ExperienceSection from "@/components/ExperienceSection";
import ProjectsSection from "@/components/ProjectsSection";
import ContactLinks from "@/components/ContactLinks";
import ContactForm from "@/components/ContactForm";
import Sidebar from "@/components/Sidebar";

export default function Home() {
  return (
    <div className="grid grid-cols-1 lg:grid-cols-[minmax(0,420px)_1fr] gap-8 px-6 lg:px-12 pt-6">
      <Sidebar />

      <main className="min-w-0 pt-6 pb-10">
        <AboutSection />
        <hr className="my-10 border-white/10" />
        <ExperienceSection />
        <hr className="my-10 border-white/10" />
        <ProjectsSection />
        <hr className="my-10 border-white/10" />

        <section id="contact" className="py-10 min-h-screen animate-fade-in-up delay-4">
          <h2 className="text-3xl lg:text-4xl font-bold text-[var(--text-primary)] mb-10 text-center">
            Contacto
          </h2>
          <div className="grid grid-cols-1 lg:grid-cols-[minmax(0,1fr)_minmax(0,1.4fr)] gap-6 items-start max-w-4xl mx-auto">
            <ContactLinks />
            <ContactForm />
          </div>
        </section>
      </main>
    </div>
  );
}
