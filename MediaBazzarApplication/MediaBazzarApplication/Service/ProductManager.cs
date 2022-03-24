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
            Load();
            productMediator.GetAll();
            return products;




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
    }
}
