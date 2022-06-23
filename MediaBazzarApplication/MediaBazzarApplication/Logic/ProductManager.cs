using MediaBazzarApplication.DAL;
using MediaBazzarApplication.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazzarApplication.Service
{
    public class ProductManager
    {
        public List<Product> products { get; private set; }
        private ProductMediator productMediator;

        public ProductManager()
        {
            this.products = new List<Product>();
            this.productMediator = new ProductMediator();
        }

        public bool Add(Product product)
        {
            Load();
            if (products.Count != 0)
            {
                foreach (Product p in products)
                {
                    if (p.Name == product.Name)
                    {

                        return false;

                    }
                }
                this.products.Add(product);
                this.productMediator.Add(product);
                return true;
            }
            else
            {
                this.products.Add(product);
                this.productMediator.Add(product);
                return true;
            }

        }
        public bool Load()
        {
            this.products = this.productMediator.GetAll();

            if (this.products != null)
            {
                return true;
            }
            else { return false; }
        }
        public Product[] GetProducts()
        {
            Load();
            return products.ToArray();
        }
        public List<Product> GetProductsToList()
        {
            //Load();
            productMediator.GetAll();
            return products;
        }
        public List<Product> GetProductsToList2()
        {

            return productMediator.GetAll();

        }
        public Product Get(int id)
        {
            foreach (Product product in this.GetProducts())
            {
                if (product.Id == id)
                {
                    return product;
                }
            }
            return null;
        }
        public bool Update(Product product)
        {
            if (this.products.Contains(product))
            {

                this.productMediator.Update(product);
                return true;
            }
            else { return false; }


        }
        public bool Remove(Product product)
        {
            if (this.Get(product.Id) != null)
            {
                this.products.Remove(product);
                this.productMediator.Remove(product);
                return true;
            }
            else { return false; }

        }

        public List<Product> SearchProducts(string item)
        {
            List<Product> products = GetProductsToList();
            List<Product> foundProducts = new List<Product>();

            foreach (Product p in products)
            {
                if (item == p.Id.ToString() || item == p.Name || item == p.Brand || item == p.SerialNumber.ToString() || item == p.boxSizes.ToString())
                {
                    foundProducts.Add(p);

                }
            }
            return foundProducts;
        }
        public void AddRemoveStock(int amount, int id, bool remove)
        {
            if (remove)
            {
                this.productMediator.RemoveStock(amount, id);
            }
            else
            {
                this.productMediator.AddStock(amount, id);
            }
        }

        public List<Product> GetProductsByShelfType(int shelfType)
        {
            if (shelfType == 0)
            {
                foreach (Product p in GetProductsToList2())
                {
                    if (p.ProductCategory == Enums.ProductCategory.Gaming || p.ProductCategory == Enums.ProductCategory.Computer || p.ProductCategory == Enums.ProductCategory.TVandAudio || p.ProductCategory == Enums.ProductCategory.PhotoAndVideo || p.ProductCategory == Enums.ProductCategory.Telecom)
                    {
                        products.Add(p);
                    }
                }
            }
            else if (shelfType == 1)
            {
                foreach (Product p in GetProductsToList2())
                {
                    if (p.ProductCategory == Enums.ProductCategory.HouseHold || p.ProductCategory == Enums.ProductCategory.Kitchen)
                    {
                        products.Add(p);
                    }
                }
            }
            else if (shelfType == 2)
            {
                foreach (Product p in GetProductsToList2())
                {
                    if (p.ProductCategory == Enums.ProductCategory.SportAndHealth || p.ProductCategory == Enums.ProductCategory.GymEquipment)
                    {
                        products.Add(p);
                    }
                }
            }
            return products;
        }
    }
}
