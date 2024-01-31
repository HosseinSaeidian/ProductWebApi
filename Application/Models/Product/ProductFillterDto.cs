namespace ProductWebApi.Application.Models.Product
{
    public class ProductFillterDto
    {
        public string? Fillter { get; set; }
        public string? Sort { get; set; }
        public int? PageSize { get; set; } = 5;
        public int? PageIndex { get; set; } = 1 ;
        
    }
}