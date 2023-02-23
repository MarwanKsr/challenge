namespace Enoca.Api.Models.Product
{
    public class ProductEditModel
    {
        public long CompanyId { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }
    }
}
