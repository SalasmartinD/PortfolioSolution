"use client";

import { useEffect, useState } from "react";
import { navSections, profile } from "@/data/profile";

export default function Sidebar() {
  const [activeId, setActiveId] = useState<string>(navSections[0].id);

  useEffect(() => {
    const sections = navSections
      .map(({ id }) => document.getElementById(id))
      .filter((el): el is HTMLElement => el !== null);

    if (sections.length === 0) return;

    const observer = new IntersectionObserver(
      (entries) => {
        const visible = entries
          .filter((entry) => entry.isIntersecting)
          .sort((a, b) => b.intersectionRatio - a.intersectionRatio)[0];

        if (visible) {
          setActiveId(visible.target.id);
        }
      },
      { rootMargin: "-20% 0px -60% 0px", threshold: [0, 0.25, 0.5, 0.75, 1] },
    );

    sections.forEach((section) => observer.observe(section));
    return () => observer.disconnect();
  }, []);

  return (
    <div className="flex flex-col p-8 lg:p-12 lg:h-screen lg:sticky lg:top-0 lg:justify-between animate-fade-in-up delay-1">
      <div>
        <header className="mb-10">
          <h1 className="text-4xl lg:text-5xl font-extrabold text-[var(--text-primary)] tracking-tight mb-3">
            {profile.name}
          </h1>
          <h2 className="text-lg font-light text-[var(--primary)] mb-6">{profile.role}</h2>
          <p className="text-[var(--text-secondary)] leading-relaxed">{profile.tagline}</p>
        </header>

        <nav className="hidden lg:flex flex-col gap-3" aria-label="Navegación de secciones">
          {navSections.map(({ id, label }) => (
            <a
              key={id}
              href={`#${id}`}
              className={`nav-link ${activeId === id ? "active" : ""}`}
              aria-current={activeId === id ? "true" : undefined}
            >
              <span className="nav-indicator-line" />
              {label}
            </a>
          ))}
        </nav>
      </div>
    </div>
  );
}
