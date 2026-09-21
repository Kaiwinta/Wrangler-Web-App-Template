import { createRepositories } from "../../_repositories/index.js";

// GET /api/example/{id}
export async function onRequestGet({ request, env }) {
    const url = new URL(request.url);
    const idSegment = url.pathname.split("/").pop();
    const id = Number.parseInt(idSegment, 10);

    if (Number.isNaN(id)) {
        return new Response("Invalid example id", { status: 400 });
    }

    const { exampleRepo1 } = createRepositories(env.DB);
    const results = await exampleRepo1.getById(id, true);
    if (!results || results.length === 0) {
        return new Response("Example not found", { status: 404 });
    }

    return Response.json(mapExample(results[0]));
}
