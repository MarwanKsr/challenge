namespace Enoca.Api.Models.Product
{
    public class ProductCreateModel
    {
        public long ComapnyId { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }
    }
}
