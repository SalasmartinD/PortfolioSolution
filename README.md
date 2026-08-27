# Portafolio — Salas Martín Daniel

Sitio personal donde muestro quién soy como desarrollador: mi experiencia actual como Software
Engineer Web en AranguriApps, mi trabajo freelance, mi formación en Ingeniería en Informática (UNLaM)
y los proyectos en los que vengo trabajando. Construido en React/TypeScript sobre Next.js y desplegado
en Vercel.

## Stack

| Capa | Tecnología | Por qué |
| :--- | :--- | :--- |
| Framework | Next.js (App Router) + TypeScript | Frontend y funciones serverless en un solo proyecto, sin backend separado. |
| Estilos | Tailwind CSS v4 | Tema oscuro con glassmorphism, sin dependencias de un framework CSS externo. |
| Datos | Supabase (PostgreSQL) | La sección de proyectos se consulta server-side con `@supabase/supabase-js`. |
| Contacto | Resend | El formulario de contacto se maneja desde una Route Handler (`/api/contact`). |
| Formularios | react-hook-form + zod | Validación tipada de principio a fin. |
| Hosting | Vercel | Un solo proveedor: frontend, SSR y funciones serverless. |

Es la segunda versión de este portafolio. La primera estaba hecha en C#/Blazor WebAssembly con una API
separada en .NET corriendo en Render; esta versión unifica todo en un solo stack de React desplegado
en Vercel.

## Contenido del sitio

- **Sobre mí**: quién soy y en qué me especializo hoy.
- **Experiencia**: mi rol actual en AranguriApps, el trabajo freelance en paralelo y mi formación
  académica y técnica previa.
- **Proyectos**: una selección de trabajos propios y para clientes, con enlaces a demo y/o código
  fuente cuando están disponibles.
- **Contacto**: mis redes y un formulario para escribirme directamente.

## Estructura del proyecto

```
src/
  app/            App Router: layout, página principal y la API route de contacto
  components/     Componentes de UI (sidebar, secciones, formulario, tarjetas)
  data/           Contenido tipado (perfil, experiencia)
  lib/            Cliente de Supabase y schema de validación del formulario
  types/          Tipos compartidos (Project)
```

## Variables de entorno

Copiá `.env.example` a `.env.local` y completá:

- `SUPABASE_URL` / `SUPABASE_ANON_KEY`: proyecto de Supabase (tabla `projects`).
- `RESEND_API_KEY`: API key de [resend.com](https://resend.com) para enviar el mail de contacto.
- `CONTACT_TO_EMAIL`: dirección que recibe los mensajes del formulario.
- `CONTACT_FROM_EMAIL`: remitente. Usá `onboarding@resend.dev` hasta verificar un dominio propio en Resend.

Las mismas variables hay que cargarlas en el proyecto de Vercel (Settings → Environment Variables).

## Desarrollo local

```bash
npm install
npm run dev
```

## Deploy

El repo se conecta directo a Vercel (framework preset: Next.js), con las variables de entorno
cargadas ahí. No depende de ningún otro servicio de hosting.
