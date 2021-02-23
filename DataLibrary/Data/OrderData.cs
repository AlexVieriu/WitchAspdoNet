using Dapper;
using DataLibrary.Db;
using DataLibrary.Model;
using System.Data;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class OrderData
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
            p.Add("Quatity", order.Quatity);
            p.Add("Total", order.Total);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _db.SaveData("dbo.spOrders_Insert", p, _connectionString.ConnectionName);

            return p.Get<int>("Id");
        }
    }
}
