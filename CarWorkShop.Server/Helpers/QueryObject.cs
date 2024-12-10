namespace CarWorkShop.Server.Helpers
{
    public class QueryObject
    {
        public string? Brand {  get; set; }= null;
        public string? EmployeeAssigned { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDecsending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
