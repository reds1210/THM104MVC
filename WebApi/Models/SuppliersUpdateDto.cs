namespace WebApi.Models
{
    public class SuppliersUpdateDto
    {
        public string CompanyName { get; set; } = null!;

        public string? ContactName { get; set; }

        public string? ContactTitle { get; set; }
    }
}
