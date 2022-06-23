using MediaBazzarApplication.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MediaBazzarApplication.Enums;

namespace MediaBazzarApplication.DAL
{
    public class ProductMediator : DataAccess
    {
        public bool Add(Product product)
        {
            if (ConnOpen())
            {
                query = "INSERT INTO products_prj(name,description,brand,serialNumber" +
                    ",buyPrice,sellprice,inStock,threshold,boxSize,productCategory,maxCapacity)" +
                    "VALUE (@name,@description, @brand,@serialNumber,@buyPrice,@sellprice," +
                    "@inStock,@threshold,@boxSize,@productCategory,@maxCapacity)";
                SqlQuery(query);

                AddWithValue("@name", product.Name);
                AddWithValue("@description", product.Description);
                AddWithValue("@brand", product.Brand);
                AddWithValue("@serialNumber", product.SerialNumber);
                AddWithValue("@buyPrice", product.BuyPrice);
                AddWithValue("@sellprice", product.SellPrice);
                AddWithValue("@inStock", product.InStock);
                AddWithValue("@threshold", product.Threshold);
                AddWithValue("@boxSize", product.boxSizes);
                AddWithValue("@productCategory", product.ProductCategory);
                AddWithValue("@maxCapacity", product.MaxCapacity);

                NonQueryEx();

                product.Id = Convert.ToInt32(command.LastInsertedId);

                Close();
                return true;
            }
            else
            {
                Close();
                return false;
            }
        }

        public bool Remove(Product product)
        {
            if (ConnOpen())
            {

                query = "DELETE from products_prj WHERE id = @id";
                SqlQuery(query);
                AddWithValue("@id", product.Id);
                NonQueryEx();

                Close();
                return true;
            }
            else
            {
                Close();
                return false;
            }
        }
        public bool Update(Product product)
        {
            if (ConnOpen())
            {
                query = "UPDATE products_prj SET name = @name, description = @description, brand = @brand," +
                    " serialNumber = @serialNumber," +
                    " buyPrice = @buyPrice, sellprice = @sellprice," +
                    " threshold = @threshold,boxSize=@boxSize," +
                    "productCategory =@productCategory,maxCapacity =@maxCapacity , inStock = @inStock WHERE id = @id";


                SqlQuery(query);
                AddWithValue("@id", product.Id);
                AddWithValue("@name", product.Name);
                AddWithValue("@description", product.Description);
                AddWithValue("@brand", product.Brand);
                AddWithValue("@serialNumber", product.SerialNumber);
                AddWithValue("@buyPrice", product.BuyPrice);
                AddWithValue("@sellprice", product.SellPrice);
                AddWithValue("@threshold", product.Threshold);
                AddWithValue("@boxSize", product.boxSizes);
                AddWithValue("@productCategory", product.ProductCategory);
                AddWithValue("@maxCapacity", product.MaxCapacity);
                AddWithValue("@inStock", product.InStock);

                NonQueryEx();

                Close();
                return true;
            }
            else
            {
                Close();
                return false;
            }
        }
        public List<Product> GetAll()
        {
            if (ConnOpen())
            {
                query = "SELECT * FROM products_prj";
                SqlQuery(query);

                List<Product> products = new List<Product>();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product(
                       reader["name"].ToString(),
                       reader["description"].ToString(),
                       reader["brand"].ToString(),
                       Convert.ToInt32(reader["serialNumber"]),
                       Convert.ToInt32(reader["buyPrice"]),
                       Convert.ToInt32(reader["sellprice"]),
                       Convert.ToInt32(reader["inStock"]),
                       Convert.ToInt32(reader["threshold"]),
                       (BoxSize)Enum.Parse(typeof(BoxSize), reader["boxSize"].ToString()),
                       (ProductCategory)Enum.Parse(typeof(ProductCategory), reader["productCategory"].ToString()),
                        Convert.ToInt32(reader["maxCapacity"])
                        );
                    product.Id = Convert.ToInt32(reader["id"]);
                    products.Add(product);
                }
                Close();
                return products;
            }
            else
            {
                Close();
                return null;
            }
        }
        //This is for removing products from the main storage so it can be added to shelfes 
        public void RemoveStock(int moved, int id)
        {
            if (ConnOpen())
            {
                query = "UPDATE `products_prj` SET `inStock` = `inStock`-@amount WHERE `id` = @id;";
                SqlQuery(query);
                AddWithValue("amount", moved);
                AddWithValue("id", id);
                NonQueryEx();

                Close();

            }
            else
            {
                Close();
            }
        }
        //This is for adding product to a shelf
        public void AddStock(int moved, int id)
        {
            if (ConnOpen())
            {
                query = "UPDATE `products_prj` SET `inStock` = `inStock`+@amount WHERE `id` = @id;";
                SqlQuery(query);
                AddWithValue("amount", -moved);
                AddWithValue("id", id);
                NonQueryEx();

                Close();

            }
            else
            {
                Close();
            }
        }
    }
}
