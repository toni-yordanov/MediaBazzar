using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaBazzarApplication.Enums;

namespace MediaBazzarApplication.Enteties
{
    public class Product
    {
        public delegate void OutOfStockHandle(Product p);
        public event OutOfStockHandle ProductOutOfStock;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public int SerialNumber { get; set; }
        public int BuyPrice { get; set; }
        public int SellPrice { get; set; }
        public int InStock { get; set; }
        public int Threshold { get; set; }
        public BoxSize boxSizes { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public int MaxCapacity { get; set; }
        public Product() { }
        public Product(string name, string desription, string brand, int serialNum, int buyPrice, int sellPirce, int inStock, int threshold, BoxSize boxSize, ProductCategory productCategory, int maxCapacity)
        {
            this.Name = name;
            this.Description = desription;
            this.Brand = brand;
            this.SerialNumber = serialNum;
            this.BuyPrice = buyPrice;
            this.SellPrice = sellPirce;
            this.InStock = inStock;
            this.Threshold = threshold;
            this.boxSizes = boxSize;
            this.ProductCategory = productCategory;
            this.MaxCapacity = maxCapacity;
        }
        public void UpdateProduct(string name, string desription, string brand, int serialNum, int buyPrice, int sellPirce, int threshold, BoxSize boxSize, ProductCategory productCategory, int maxCapacity)
        {
            this.Name = name;
            this.Description = desription;
            this.Brand = brand;
            this.SerialNumber = serialNum;
            this.BuyPrice = buyPrice;
            this.SellPrice = sellPirce;

            this.Threshold = threshold;
            this.boxSizes = boxSize;
            this.ProductCategory = productCategory;
            this.MaxCapacity = maxCapacity;
        }
        public void RestockProduct(int quantity)
        {
            this.InStock += quantity;
        }
        public bool CheckQuantity()
        {
            if (this.ProductOutOfStock != null)
            {
                if (this.InStock < this.Threshold)
                {
                    this.ProductOutOfStock(this);
                    return true;
                }
                else { return false; }
            }
            return false;
        }

    }
}
