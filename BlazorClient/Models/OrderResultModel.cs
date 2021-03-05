using DataLibrary.Model;

namespace BlazorClient.Models
{
    public class OrderResultModel
    {
        public OrderModel Order { get; set; }
        public string ItemPurchased { get; set; }
    }
}
