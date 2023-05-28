export interface PaginatedResult<T> {
    page: number;
    pageSize: number;
    totalItemCount: number;
    results: Array<T>;
}
