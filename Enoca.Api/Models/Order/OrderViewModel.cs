namespace Enoca.Api.Models.Order
{
    public class OrderViewModel
    {
        public long Id { get; set; }
        public string NameOfPerson { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public long CompanyId { get; set; }
        public string CompanyName { get; set; }
        public DateTime OrderTime { get; set; }

    }
}
