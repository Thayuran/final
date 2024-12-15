import { PaginatedFilter } from "./paginationFilter";

export class BrandParams implements PaginatedFilter {
  searchString: string;
  pageNumber: number;
  pageSize: number;
  orderBy: string;
}
