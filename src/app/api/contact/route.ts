import { NextResponse } from "next/server";
import { Resend } from "resend";
import { contactSchema } from "@/lib/contactSchema";

export async function POST(request: Request) {
  const body = await request.json().catch(() => null);
  const parsed = contactSchema.safeParse(body);

  if (!parsed.success) {
    return NextResponse.json(
      { status: "Error", message: parsed.error.issues[0]?.message ?? "Datos inválidos." },
      { status: 400 },
    );
  }

  const apiKey = process.env.RESEND_API_KEY;
  const toEmail = process.env.CONTACT_TO_EMAIL;
  const fromEmail = process.env.CONTACT_FROM_EMAIL ?? "onboarding@resend.dev";

  if (!apiKey || !toEmail) {
    console.error("Faltan RESEND_API_KEY o CONTACT_TO_EMAIL en las variables de entorno.");
    return NextResponse.json(
      { status: "Error", message: "El servicio de contacto no está configurado." },
      { status: 500 },
    );
  }

  const { name, email, subject, message } = parsed.data;
  const resend = new Resend(apiKey);

  const { error } = await resend.emails.send({
    from: `Portfolio <${fromEmail}>`,
    to: toEmail,
    replyTo: email,
    subject: `[PORTAFOLIO] ${subject}`,
    text: `Nombre: ${name} (${email})\n\nMENSAJE:\n${message}`,
  });

  if (error) {
    console.error("Error al enviar el correo vía Resend:", error);
    return NextResponse.json(
      { status: "Error", message: "Fallo interno del servidor al enviar el correo." },
      { status: 500 },
    );
  }

  return NextResponse.json({ status: "Success", message: "Mensaje enviado correctamente." });
}
