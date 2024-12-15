import { PaginatedFilter } from "./paginationFilter";

export class EmployeeParams implements PaginatedFilter {
  searchString: string;
  pageNumber: number;
  pageSize: number;
  orderBy: string;
}
