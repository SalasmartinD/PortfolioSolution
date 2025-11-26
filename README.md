# 🌐 Portafolio Personal Full-Stack C# / Blazor WebAssembly

[![Deployment Status](https://img.shields.io/badge/Status-Deploy%20Exitoso-brightgreen)](https://TU-PROYECTO.vercel.app)
[![API Backend](https://img.shields.io/badge/Backend-Render%20Live-blueviolet)](https://TU-API-RENDER.onrender.com/ping)
[![Tecnología Principal](https://img.shields.io/badge/Framework-ASP.NET%20Core%2010.0-9400D3)]()

## 📝 Visión General del Proyecto

Este repositorio contiene la arquitectura completa de mi portafolio web personal, diseñado para demostrar mi dominio del **Stack C#/.NET** en un entorno de producción real.

El proyecto está diseñado con una arquitectura de "Despliegue Dividido" (Split Deployment) que separa el cliente estático de la API de backend, replicando un entorno de microservicios real.

---

## 🎯 Tecnologías Clave

| Capa | Tecnología | Propósito |
| :--- | :--- | :--- |
| **Frontend (Client)** | **Blazor WebAssembly (WASM)** | Single Page Application (SPA) para la interfaz. Carga el runtime de .NET directamente en el navegador. |
| **Backend (API)** | **ASP.NET Core Web API** | Servicio RESTful para manejar solicitudes de datos de proyectos y la lógica de contacto. |
| **Persistencia** | **PostgreSQL + Entity Framework Core** | Base de datos relacional robusta. EF Core gestiona las migraciones y consultas de datos. |
| **DevOps/Hosting** | **Vercel & Render** | Vercel aloja el cliente estático (WASM). Render aloja el servidor de la API y la base de datos (Full-Stack Free Tier). |
| **Servicios** | **SendGrid** | Envío de emails transaccionales para el formulario de contacto (solución robusta anti-spam y anti-bloqueo). |

---

## ✨ Funcionalidades y Patrones Demostrados

* **API Orientada a Datos:** El `ProjectsController` consulta datos persistentes de PostgreSQL.
* **Formulario Funcional:** `ContactController` recibe datos y los envía al correo electrónico a través de la API de SendGrid (sin usar SMTP directamente).
* **Arquitectura:** Separación estricta de la UI (Blazor) y la lógica de negocio (API).
* **Diseño Responsivo:** UI inspirada en el estilo minimalista de Brittany Chiang, optimizada para Desktop y Móvil.

---

## 🏗️ Estructura de la Solución

El proyecto está organizado en una solución de múltiples proyectos:

1.  **`Portfolio.Client`**: La aplicación Blazor WebAssembly.
2.  **`Portfolio.Api`**: El servidor de la API y el host de Kestrel (ejecutado en Docker/Render).
3.  **`Portfolio.Shared`**: Modelos y DTOs (Data Transfer Objects) compartidos entre el cliente y el servidor.
