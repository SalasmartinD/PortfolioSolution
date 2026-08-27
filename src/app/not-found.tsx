import Link from "next/link";

export default function NotFound() {
  return (
    <div className="bg-theme min-h-screen flex flex-col items-center justify-center gap-4 text-center px-6">
      <h1 className="text-6xl font-extrabold text-[var(--text-primary)]">404</h1>
      <p className="text-[var(--text-secondary)]">No encontré esta página.</p>
      <Link href="/" className="btn-gradient">
        Volver al inicio
      </Link>
    </div>
  );
}
