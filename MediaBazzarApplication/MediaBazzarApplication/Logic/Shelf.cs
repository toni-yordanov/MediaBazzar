using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaBazzarApplication.Enums;

namespace MediaBazzarApplication.Enteties
{
    public class Shelf
    {
        private string shelfCategory;
        private int shelfCapacity;
        private int shelfID;

        public int ID
        {
            get; set;
        }
        //public string Category
        //{
        //    get { return shelfCategory; }
        //}
        public int Capacity
        {
            get; set;
        }
        public Floors Floors { get; set; }
        public List<Product> products = new List<Product>();

        public Shelf(string shelfCategory, int shelfCapacity)
        {
            this.shelfCategory = shelfCategory;
            this.shelfCapacity = shelfCapacity;
        }

        public Shelf(int shelfID, string shelfCategory, int shelfCapacity)
        {
            this.shelfID = shelfID;
            this.shelfCategory = shelfCategory;
            this.shelfCapacity = shelfCapacity;
        }
        public Shelf(int shelfID, Floors floors)
        {
            this.shelfID = shelfID;
            Floors = floors;

        }
        public Shelf(Floors floors, int shelfCapacity)
        {

            Floors = floors;
            Capacity = shelfCapacity;

        }
        public Shelf() { }
        public string Get()
        {
            return $"{ID} || Floor:{Floors} Capacity:{Capacity}";
        }
    }
}
