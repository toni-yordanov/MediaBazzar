using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazzarApplication.Enteties
{
    public class RestockRequest
    {
        public int ID { get; set; }
        public int RequestedAmount { get; private set; }
        public string SentTime { get; private set; }
        //public Product Product { get; private set; }
        public string ProductName { get; private set; }
        public int ProductId { get; private set; }

        public RestockRequest(Product product, int restockAmount)
        {
            this.RequestedAmount = restockAmount;
            // this.RequestedAmount = product.MaxCapacity - product.InStock;
            this.SentTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            this.ProductName = product.Name;
            this.ProductId = product.Id;
        }
        public RestockRequest(Product product)
        {
            //this.RequestedAmount = restockAmount;
            // this.RequestedAmount = product.MaxCapacity - product.InStock;
            this.SentTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            this.ProductName = product.Name;
            this.ProductId = product.Id;
        }
        public RestockRequest(int productId, string productName, int requestedAmount, string sentTime)
        {
            this.RequestedAmount = requestedAmount;
            this.SentTime = sentTime;
            this.ProductName = productName;
            this.ProductId = productId;
        }
    }
}
