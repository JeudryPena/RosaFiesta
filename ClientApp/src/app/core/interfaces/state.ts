import { SortColumn, SortDirection } from "../../shared/directives/sortable.directive";

export interface State {
    page: number;
    pageSize: number;
    searchTerm: string;
    sortColumn: SortColumn;
    sortDirection: SortDirection;
}
