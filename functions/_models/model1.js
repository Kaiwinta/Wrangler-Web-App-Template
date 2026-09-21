export const TABLE = "Model1";

export const COLUMNS = {
    ID: "id",
    NAME: "name",
    OTHER_COLUMN: "other_column"
};

// The all column prevent using a * in the query
// This ensure that we are only selecting the columns we want and not any extra columns that may be added in the future
export const ALL_COLUMNS = Object.values(COLUMNS).join(", ");

// This is used for queries that involve joins, to prevent column name conflicts
export const ALL_COLUMNS_WITH_ALIAS = (alias) =>
  Object.values(COLUMNS).map(col => `${alias}.${col}`).join(", ");