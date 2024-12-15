import { PaginatedFilter } from "./paginationFilter";

export class ProductParams implements PaginatedFilter {
  searchString: string;
  brandIds: string[];
  categoryIds: string[];
  pageNumber: number;
  pageSize: number;
  orderBy: string;
}
