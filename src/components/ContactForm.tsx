"use client";

import { useState } from "react";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { FaPaperPlane } from "react-icons/fa";
import { contactSchema, type ContactFormValues } from "@/lib/contactSchema";

export default function ContactForm() {
  const [status, setStatus] = useState<string | null>(null);
  const {
    register,
    handleSubmit,
    reset,
    formState: { errors, isSubmitting },
  } = useForm<ContactFormValues>({ resolver: zodResolver(contactSchema) });

  const onSubmit = async (values: ContactFormValues) => {
    setStatus(null);
    try {
      const response = await fetch("/api/contact", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(values),
      });

      if (response.ok) {
        setStatus("✅ ¡Mensaje enviado con éxito! Te responderé pronto.");
        reset();
      } else {
        setStatus("❌ Error al enviar. Intenta de nuevo más tarde.");
      }
    } catch {
      setStatus("❌ Error de conexión. Intenta de nuevo más tarde.");
    }
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)} className="glass-card p-6" noValidate>
      <div className="mb-4">
        <label htmlFor="name" className="block text-xs font-bold uppercase tracking-wide text-[var(--text-secondary)] mb-2">
          Nombre
        </label>
        <input id="name" placeholder="Tu nombre" className="custom-input" {...register("name")} />
        {errors.name && <p className="validation-message">{errors.name.message}</p>}
      </div>

      <div className="mb-4">
        <label htmlFor="email" className="block text-xs font-bold uppercase tracking-wide text-[var(--text-secondary)] mb-2">
          Email
        </label>
        <input id="email" placeholder="tu@email.com" className="custom-input" {...register("email")} />
        {errors.email && <p className="validation-message">{errors.email.message}</p>}
      </div>

      <div className="mb-4">
        <label htmlFor="subject" className="block text-xs font-bold uppercase tracking-wide text-[var(--text-secondary)] mb-2">
          Asunto
        </label>
        <input id="subject" placeholder="¿De qué se trata?" className="custom-input" {...register("subject")} />
        {errors.subject && <p className="validation-message">{errors.subject.message}</p>}
      </div>

      <div className="mb-4">
        <label htmlFor="message" className="block text-xs font-bold uppercase tracking-wide text-[var(--text-secondary)] mb-2">
          Mensaje
        </label>
        <textarea
          id="message"
          rows={5}
          placeholder="Cuéntame sobre tu proyecto o consulta..."
          className="custom-input"
          {...register("message")}
        />
        {errors.message && <p className="validation-message">{errors.message.message}</p>}
      </div>

      <button type="submit" disabled={isSubmitting} className="btn-gradient w-full justify-center mt-2">
        {isSubmitting ? (
          <span className="inline-block h-4 w-4 animate-spin rounded-full border-2 border-white/40 border-t-white" />
        ) : (
          <>
            <FaPaperPlane /> Enviar Mensaje
          </>
        )}
      </button>

      {status && (
        <div className="mt-4 rounded-lg border border-white/10 bg-black/30 p-3 text-sm text-[var(--text-primary)]">
          {status}
        </div>
      )}
    </form>
  );
}
