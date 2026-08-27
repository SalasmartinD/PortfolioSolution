# 🌐 Portafolio Personal — React / TypeScript / Next.js

## 📝 Visión General

Portafolio personal migrado de C#/Blazor a un stack moderno de React, pensado para desplegarse
íntegramente en Vercel (frontend + funciones serverless), sin backend separado.

## 🎯 Stack

| Capa | Tecnología | Propósito |
| :--- | :--- | :--- |
| **Framework** | **Next.js (App Router) + TypeScript** | SSR/SSG, rutas de API serverless y frontend en un solo proyecto. |
| **Estilos** | **Tailwind CSS v4** | Sistema de diseño oscuro con glassmorphism, sin dependencias de Bootstrap. |
| **Datos** | **Supabase (PostgreSQL)** | Los proyectos se consultan server-side con `@supabase/supabase-js`. |
| **Contacto** | **Resend** | Envío del formulario de contacto vía una Route Handler (`/api/contact`). |
| **Formularios** | **react-hook-form + zod** | Validación tipada del formulario de contacto. |
| **Hosting** | **Vercel** | Único proveedor: frontend estático/SSR + funciones serverless. |

## 🏗️ Estructura

```
src/
  app/            # App Router: layout, page y la API route de contacto
  components/     # Componentes de UI (Sidebar, secciones, formulario, etc.)
  data/           # Contenido tipado (perfil, experiencia)
  lib/            # Cliente de Supabase y schema de validación
  types/          # Tipos compartidos (Project)
```

## ⚙️ Variables de entorno

Copiá `.env.example` a `.env.local` y completá:

- `SUPABASE_URL` / `SUPABASE_ANON_KEY`: proyecto de Supabase (tabla `projects`).
- `RESEND_API_KEY`: API key de [resend.com](https://resend.com) para enviar el mail de contacto.
- `CONTACT_TO_EMAIL`: dirección que recibe los mensajes del formulario.
- `CONTACT_FROM_EMAIL`: remitente. Usá `onboarding@resend.dev` hasta verificar un dominio propio en Resend.

Estas mismas variables hay que cargarlas en el proyecto de Vercel (Settings → Environment Variables).

## 🚀 Desarrollo local

```bash
npm install
npm run dev
```

## 📦 Deploy

Conectar el repo a Vercel (framework preset: Next.js) y cargar las variables de entorno. No requiere
ningún otro servicio de hosting.
