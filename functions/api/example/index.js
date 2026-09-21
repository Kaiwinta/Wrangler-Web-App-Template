import { createRepositories } from "../../_repositories/index.js";

// GET /api/folders
export async function onRequestGet({ request, env }){
    const url    = new URL(request.url);

    const { foldersRepo } = createRepositories(env.DB);
    const results = await foldersRepo.getAll();
    return Response.json(results);
}
