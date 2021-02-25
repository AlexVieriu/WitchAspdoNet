using DataLibrary.Model;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public interface IOrderData
    {
        Task<int> CreareOrder(OrderModel order);
        Task<int> DeleteOrder(int orderId);
        Task<OrderModel> GetOderById(int orderId);
        Task<int> UpdateOrderName(int orderId, string orderName);
    }
}