import { createClient } from "@supabase/supabase-js";
import type { Project } from "@/types/project";

export async function getProjects(): Promise<Project[]> {
  const url = process.env.SUPABASE_URL;
  const anonKey = process.env.SUPABASE_ANON_KEY;

  if (!url || !anonKey) {
    throw new Error("Supabase URL or anon key is not configured.");
  }

  const supabase = createClient(url, anonKey);

  const { data, error } = await supabase
    .from("projects")
    .select("*")
    .order("priority", { ascending: true });

  if (error) {
    throw new Error(error.message);
  }

  return data ?? [];
}
