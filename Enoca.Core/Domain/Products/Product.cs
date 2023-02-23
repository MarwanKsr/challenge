using Ardalis.GuardClauses;
using Enoca.Core.Base;
using Enoca.Core.Domain.Companies;
using Enoca.Core.Exceptions;
using Enoca.Core.Resources;

namespace Enoca.Core.Domain.Products
{
    public class Product : BaseEntity
    {
        protected Product() { }

        public Product(Company company, string productName, int stock, long price)
        {
            SetCompany(company);
            SetProductName(productName);
            SetStock(stock);
            SetPrice(price);
        }

        public long CompanyId { get; private set; }
        public Company Company { get; private set; }
        public void SetCompany(Company company)
        {
            if (company is null)
            {
                throw BusinessLogicException.Create(_Product.Product_Exception_InvalidCompanyId);
            }
            Company = company;
            CompanyId = company.Id;
        }

        public string ProductName { get; private set; }
        public void SetProductName(string productName)
        {
            Guard.Against.NullOrEmpty(productName, nameof(productName), _Product.Product_Exception_EmptyName);
            ProductName = productName;
        }

        public int Stock { get; private set; }
        public void SetStock(int stock)
        {
            if (stock <= 0)
            {
                throw BusinessLogicException.Create(_Product.Product_Exception_InvalidStockNumber);
            }

            Stock = stock;
        }
        public void DecreaseStockNumber()
        {
            Stock--;
        }

        public long Price { get; private set; }
        public void SetPrice(long price)
        {
            if (price < 0)
            {
                throw BusinessLogicException.Create(_Product.Product_Exception_InvalidPrice);
            }
            Price = price;
        }
    }
}
