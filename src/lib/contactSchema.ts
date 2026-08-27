import { z } from "zod";

export const contactSchema = z.object({
  name: z.string().trim().min(1, "El nombre es obligatorio"),
  email: z.string().trim().email("Ingresá un email válido"),
  subject: z.string().trim().min(1, "El asunto es obligatorio"),
  message: z
    .string()
    .trim()
    .min(10, "El mensaje debe tener al menos 10 caracteres")
    .max(500, "El mensaje no puede superar los 500 caracteres"),
});

export type ContactFormValues = z.infer<typeof contactSchema>;
