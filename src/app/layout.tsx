import type { Metadata } from "next";
import { Inter, Space_Mono } from "next/font/google";
import CursorHalo from "@/components/CursorHalo";
import Footer from "@/components/Footer";
import "./globals.css";

const inter = Inter({
  variable: "--font-sans",
  subsets: ["latin"],
});

const spaceMono = Space_Mono({
  variable: "--font-mono",
  weight: ["400", "700"],
  subsets: ["latin"],
});

export const metadata: Metadata = {
  metadataBase: new URL("https://salasmartin.dev"),
  title: "Salas Martín - Portafolio",
  description:
    "Software Engineer Full-Stack enfocado en React, TypeScript y Supabase, con experiencia integrando IA en productos reales.",
  icons: {
    icon: "/favicon.png",
    apple: "/icon-192.png",
  },
  openGraph: {
    title: "Salas Martín - Portafolio",
    description:
      "Software Engineer Full-Stack enfocado en React, TypeScript y Supabase, con experiencia integrando IA en productos reales.",
    type: "website",
  },
};

export default function RootLayout({ children }: LayoutProps<"/">) {
  return (
    <html lang="es" className={`${inter.variable} ${spaceMono.variable}`}>
      <body className="bg-theme min-h-screen antialiased flex flex-col">
        <CursorHalo />
        <div className="flex-1">{children}</div>
        <Footer />
      </body>
    </html>
  );
}
