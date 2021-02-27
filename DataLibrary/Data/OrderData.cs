using Dapper;
using DataLibrary.Db;
using DataLibrary.Model;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class OrderData : IOrderData
    {
        private readonly ISqlDb _db;
        private readonly ConnectionStringData _connectionString;

        public OrderData(ISqlDb db, ConnectionStringData connectionString)
        {
            _db = db;
            _connectionString = connectionString;
        }

        public async Task<int> CreareOrder(OrderModel order)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("OrderName", order.OrderName);
            p.Add("OrderDate", order.OrderDate);
            p.Add("FoodId", order.FoodId);
            p.Add("Quantity", order.Quantity);
            p.Add("Total", order.Total);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _db.SaveData("dbo.spOrders_Insert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");
        }

        public Task<int> UpdateOrderName(int orderId, string orderName)
        {
            return _db.SaveData("dbo.spOrders_UpdateName",
                                new { Id = orderId, orderName = orderName },
                                _connectionString.SqlConnectionName);
        }

        public Task<int> DeleteOrder(int orderId)
        {
            return _db.SaveData("dbo.spOrders_Delete",
                                new { Id = orderId },
                                _connectionString.SqlConnectionName);
        }


        public async Task<OrderModel> GetOderById(int orderId)
        {
            var records = await _db.LoadData<OrderModel, dynamic>("dbo.spOrders_GetbyId",
                                                                  new { Id = orderId },
                                                                  _connectionString.SqlConnectionName);

            return records.FirstOrDefault();
        }
    }
}
