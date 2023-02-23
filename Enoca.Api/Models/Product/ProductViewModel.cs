namespace Enoca.Api.Models.Product
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public string CompanyName { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }
    }
}
