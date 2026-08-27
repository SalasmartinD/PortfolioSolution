import { FaPhoneAlt, FaEnvelope, FaGithub, FaLinkedin, FaWhatsapp } from "react-icons/fa";
import { profile } from "@/data/profile";

const links = [
  {
    href: `mailto:${profile.contact.email}`,
    label: "Gmail",
    value: profile.contact.email,
    icon: FaEnvelope,
    variant: "card-gmail",
  },
  {
    href: profile.contact.github,
    label: "GitHub",
    value: profile.contact.githubHandle,
    icon: FaGithub,
    variant: "card-github",
  },
  {
    href: profile.contact.linkedin,
    label: "LinkedIn",
    value: profile.contact.linkedinName,
    icon: FaLinkedin,
    variant: "card-linkedin",
  },
  {
    href: profile.contact.whatsapp,
    label: "WhatsApp",
    value: profile.contact.whatsappNumber,
    icon: FaWhatsapp,
    variant: "card-whatsapp",
  },
];

export default function ContactLinks() {
  return (
    <div>
      <h3 className="flex items-center gap-2 text-xl font-bold text-[var(--primary)] mb-2">
        <FaPhoneAlt /> Conectemos
      </h3>
      <p className="text-sm text-[var(--text-secondary)] mb-6">
        ¿Tienes un proyecto en mente? ¡Me encantaría escuchar sobre tus ideas!
      </p>

      <div className="flex flex-col gap-3">
        {links.map(({ href, label, value, icon: Icon, variant }) => (
          <a
            key={label}
            href={href}
            target="_blank"
            rel="noreferrer"
            className={`contact-glass-card ${variant} flex items-center justify-between p-4`}
          >
            <div className="min-w-0">
              <h4 className="font-bold text-[var(--text-primary)] mb-0.5">{label}</h4>
              <p className="text-sm text-[var(--text-secondary)] truncate">{value}</p>
            </div>
            <Icon className="text-2xl shrink-0" />
          </a>
        ))}
      </div>
    </div>
  );
}
