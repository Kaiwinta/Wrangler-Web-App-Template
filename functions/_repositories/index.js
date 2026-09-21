import { ExampleRepo1 } from "./ExampleRepo1.js";
import { ExampleRepo2 } from "./ExampleRepo2.js";

export function createRepositories(db) {
    const exampleRepo1 = new ExampleRepo1(db);
    const exampleRepo2 = new ExampleRepo2(db);

    return {
        exampleRepo1,
        exampleRepo2
    };
}