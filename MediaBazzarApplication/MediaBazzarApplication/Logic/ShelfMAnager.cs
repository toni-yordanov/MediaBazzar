using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaBazzarApplication.DAL;
using MediaBazzarApplication.Enteties;

namespace MediaBazzarApplication.Service
{
    public class ShelfManager
    {
        List<Shelf> shelves;
        ShelfMediator shelfMediator;
        ProductManager productManager;
        public ShelfManager()
        {
            shelves = new List<Shelf>();
            shelfMediator = new ShelfMediator();
            productManager = new ProductManager();
        }


        public void AddShelf(Shelf shelf)
        {
            shelves.Add(shelf);
            shelfMediator.AddShelff(shelf);
        }

        public void RemoveShelf(int id)
        {
            shelfMediator.RemoveShelf(id);
        }


        public void EditShelf(int id)
        {

        }

        public List<string> GetItemsOnShelf(int id)
        {
            return shelfMediator.ShowProductsInShelf(id);
        }

        public List<Shelf> GetShelves()
        {
            return shelfMediator.GetShelvess();
        }
        public bool LoadShelfs()
        {
            this.shelves = this.shelfMediator.GetShelvess();

            if (this.shelves != null)
            {
                return true;

            }
            else { return false; }
        }
        public Shelf[] GetShelvess()
        {
            return shelves.ToArray();
        }

        //public List<Shelf> GetShelfByFloor(Enum floor)
        //{
        //    List<Shelf> sl = new List<Shelf>();
        //    foreach (Shelf s in this.GetShelvess())
        //    {
        //        if (s.Floors == floor)
        //        {
        //            sl.Add(s);
        //        }
        //    }
        //    return sl;
        //}

        public void AddProductToshelf(int shelfId, int productId, int amount)
        {
            ////System.Windows.Forms.MessageBox.Show(shelfId.ToString());
            ////System.Windows.Forms.MessageBox.Show(productId.ToString());
            //bool temp = shelfMediator.IsProductOnShelf(shelfId, productId);
            //shelfMediator.AddProductToShelf(shelfId, productId, amount);
            //productManager.AddRemoveStock(amount, productId, true);
            bool isOnShelf = shelfMediator.IsProductOnShelf(shelfId, productId);
            if (amount < 0 && isOnShelf)
            {
                shelfMediator.UpdateProductOnShelf(shelfId, productId, amount);
                productManager.AddRemoveStock(amount, productId, false);
            }
            else if (isOnShelf)
            {
                shelfMediator.UpdateProductOnShelf(shelfId, productId, amount);
                productManager.AddRemoveStock(amount, productId, true);
            }
            else
            {
                shelfMediator.AddProductToShelf(shelfId, productId, amount);
                productManager.AddRemoveStock(amount, productId, true);
            }
        }

        public Shelf GetShelfByID(int ID)
        {
            foreach (Shelf s in GetShelves())
            {
                if (s.ID == ID)
                {
                    return s;
                }
            }
            return null;
        }
        public int CheckShelfAvailability(int shelfId)
        {
            return shelfMediator.GetProductAmountOnShelf(shelfId);
        }
    }
}
