using Enoca.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Service.Products.Model
{
    public class ProductDto
    {
        public long Id { get; private set; }
        public string ProductName { get; private set; }
        public long CompanyId { get; private set; }
        public string CompanyName { get; private set; }
        public int Stock { get; private set; }
        public long Price { get; private set; }

        public static ProductDto FromEntity(Product product) => new()
        {
            Id = product.Id,
            ProductName = product.ProductName,
            CompanyId = product.CompanyId,
            CompanyName = product.Company.CompanyName,
            Stock = product.Stock,
            Price = product.Price,
        };

    }
}
