export type Project = {
  id: number;
  title: string;
  short_description: string;
  technologies: string;
  github_url: string;
  live_demo_url: string | null;
  image_url: string | null;
  priority: number;
  created_at: string | null;
};
