using Enoca.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Service.Orders.Model
{
    public class OrderDto
    {
        public long Id { get; private set; }
        public string NameOfPerson { get; private set; }
        public long ProductId { get; private set; }
        public string ProductName { get; private set; }
        public long CompanyId { get; private set; }
        public string CompanyName { get; private set; }
        public DateTime OrderTime { get; private set; }

        public static OrderDto FromEntity(Order order) => new()
        {
            Id = order.Id,
            NameOfPerson = order.NameOfPerson,
            ProductId = order.ProductId,
            ProductName = order.Product.ProductName,
            CompanyId = order.Product.CompanyId,
            CompanyName = order.Product.Company.CompanyName,
            OrderTime = order.CreatedAt.ToLocalTime(),
        };
    }
}
