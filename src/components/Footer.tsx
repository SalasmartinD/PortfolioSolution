export default function Footer() {
  return (
    <footer className="site-footer py-6 text-center">
      <span className="text-sm text-[var(--text-secondary)]">
        © {new Date().getFullYear()} Salas Martín Daniel · Desarrollado con React, TypeScript y Next.js.
      </span>
    </footer>
  );
}
