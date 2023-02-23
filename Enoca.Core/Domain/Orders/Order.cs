using Enoca.Core.Base;
using Enoca.Core.Domain.Products;
using Enoca.Core.Exceptions;
using Enoca.Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Core.Domain.Orders
{
    public class Order : BaseEntity
    {
        protected Order() { }

        public Order(Product product, string nameOfPerson)
        {
            SetProduct(product);
            SetNameOfPerson(nameOfPerson);
        }

        public long ProductId { get; private set; }
        public Product Product { get; private set; }
        public void SetProduct(Product product)
        {
            if (product is null)
            {
                throw BusinessLogicException.Create(_Order.Order_Exception_InvalidProductId);
            }
            Product = product;
            ProductId = product.Id;
        }

        public string NameOfPerson { get; private set; }
        public void SetNameOfPerson(string nameOfPerson) => NameOfPerson = nameOfPerson;
    }
}
