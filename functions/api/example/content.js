import { createRepositories } from "../../_repositories/index.js";

// GET /api/example/content/
export async function onRequestGet({ request, env }) {
    const { exampleRepo1 } = createRepositories(env.DB);
    const results = await exampleRepo1.getAllContent(true);
    if (!results || results.length === 0) {
        return new Response("No example content found", { status: 404 });
    }

    return Response.json(mapExample(results[0]));
}
