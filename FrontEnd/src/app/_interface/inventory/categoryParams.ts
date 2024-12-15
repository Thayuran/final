import { PaginatedFilter } from "./paginationFilter";

export class CategoryParams implements PaginatedFilter {
  searchString: string;
  pageNumber: number;
  pageSize: number;
  orderBy: string;
}
