using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaBazzarApplication.Enteties;
using MySql.Data.MySqlClient;
using MediaBazzarApplication.Enums;
using System.Windows.Forms;


namespace MediaBazzarApplication.DAL
{
    public class ShelfMediator : DataAccess
    {
        private DataAccess dataAccess;

        public ShelfMediator()
        {
            dataAccess = new DataAccess();
        }

        public bool IsProductOnShelf(int shelfID, int productID)
        {
            if (ConnOpen())
            {
                query = "SELECT count(*) FROM product_shelves WHERE `shelf_ID` = @Shelf AND `product_ID` = @Product";
                SqlQuery(query);
                AddWithValue("@Shelf", shelfID);
                AddWithValue("@Product", productID);

                int amount = 0;

                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    amount = Convert.ToInt32(dataReader["count(*)"]);
                }
                if (amount > 0)
                {
                    Close();
                    return true;
                }
                Close();
            }
            else
            {
                Close();
                return false;
            }
            return false;
        }

        public void UpdateProductOnShelf(int shelfID, int productID, int amount)
        {
            if (ConnOpen())
            {
                query = "UPDATE `product_shelves` set amount=amount+@amount WHERE shelf_ID = @shelf_ID and product_ID=@product_ID;";

                SqlQuery(query);

                AddWithValue("@shelf_ID", shelfID);
                AddWithValue("@product_ID", productID);
                AddWithValue("@amount", amount);
                NonQueryEx();

                Close();
            }
            else
            {
                Close();
            }
        }
        public bool AddShelff(Shelf shelf)
        {
            if (ConnOpen())
            {
                query = "INSERT INTO shelvess ( Floor,Cap) VALUES ( @Floor,@Cap)";

                SqlQuery(query);

                // AddWithValue("@id", shelf.ID);
                AddWithValue("@Floor", shelf.Floors);
                AddWithValue("@Cap", shelf.Capacity);

                NonQueryEx();
                shelf.ID = Convert.ToInt32(command.LastInsertedId);
                Close();
                return true;
            }
            else
            {
                Close();
                return false;
            }
        }
        public void RemoveShelf(int id)
        {
            Close();
            if (ConnOpen())
            {
                try
                {
                    query = "DELETE FROM shelves WHERE @id = " + id;
                    MySqlDataReader dataReader = command.ExecuteReader();

                    SqlQuery(query);
                    NonQueryEx();
                    dataReader.Close();


                }
                catch (Exception ex)
                {


                    string p = ex.Message;
                }
            }
        }

        public void AddProductToShelf(int shelfID, int productID, int amount)
        {
            if (ConnOpen())
            {
                query = "INSERT INTO product_shelves (shelf_ID,product_ID,amount) VALUES (@Shelf,@Product,@Amount)";

                SqlQuery(query);

                AddWithValue("@Shelf", shelfID);
                AddWithValue("@Product", productID);
                AddWithValue("@Amount", amount);

                NonQueryEx();
                Close();
            }
            else
            {
                Close();
            }
        }
        public void RemoveProductFromShelf(int shelfID, int productID, int amount)
        {
            if (ConnOpen())
            {
                query = "UPDATE `product_shelves` SET shelf_ID = @shelf_ID,product_ID=@product_ID ,amount =@amount, WHERE `id` = @id;";

                SqlQuery(query);

                AddWithValue("@shelf_ID", shelfID);
                AddWithValue("@product_ID", productID);
                AddWithValue("@amount", amount);
                NonQueryEx();

                Close();
            }
            else
            {
                Close();
            }
        }



        public List<Shelf> GetShelvess()
        {
            if (ConnOpen())
            {

                query = "SELECT * FROM shelvess";
                SqlQuery(query);
                List<Shelf> shelves = new List<Shelf>();
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Shelf shelf = new Shelf((Floors)Enum.Parse(typeof(Floors), dataReader["Floor"].ToString()), Convert.ToInt32(dataReader["Cap"]));
                    shelf.ID = Convert.ToInt32(dataReader["id"]);
                    shelves.Add(shelf);

                }
                Close();
                return shelves;


            }
            else
            {
                Close();
                return null;
            }

        }

        public List<string> ShowProductsInShelf(int shelfID)
        {
            if (ConnOpen())
            {

                query = "select distinct p.id as ProductID,p.name as Product,ps.amount as Count from product_shelves as ps inner " +
                    "join shelvess as s on s.id = ps.shelf_ID inner join products_prj as p on p.id = ps.product_ID where s.id = @shelf";
                SqlQuery(query);
                AddWithValue("@Shelf", shelfID);
                List<String> items = new List<String>();
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    //if(dataReader["Count"] > 5)
                    //{

                    //}
                    //Shelf shelf = new Shelf((Floors)Enum.Parse(typeof(Floors), dataReader["Floor"].ToString()));
                    items.Add(dataReader["ProductID"] + " " + " Name:" + dataReader["Product"] + " " + "Quantity: " + dataReader["Count"]);
                }
                Close();
                return items;


            }
            else
            {
                Close();
                return null;
            }
        }

        public int GetProductAmountOnShelf(int id)
        {
            int temp = -1;
            if (ConnOpen())
            {
                query = "SELECT Sum(amount) AS amount FROM `product_shelves` WHERE shelf_ID =@shelf_ID";

                SqlQuery(query);
                AddWithValue("@shelf_ID", id);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    if (!(dataReader["amount"] is DBNull))
                    {
                        temp = Convert.ToInt32(dataReader["amount"]);
                    }

                }

                Close();
                return temp;
            }

            else
            {
                Close();
                return temp;
            }

        }
    }
}
