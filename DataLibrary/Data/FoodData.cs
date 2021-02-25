using DataLibrary.Db;
using DataLibrary.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class FoodData : IFoodData
    {
        private readonly ISqlDb _db;
        private readonly ConnectionStringData _connectionString;

        public FoodData(ISqlDb db, ConnectionStringData connectionString)
        {
            _db = db;
            _connectionString = connectionString;
        }

        public Task<List<FoodModel>> GetFood()
        {
            return _db.LoadData<FoodModel, dynamic>("dbo.SpFood_All",
                                                    new { },
                                                    _connectionString.SqlConnectionName);
        }
    }
}
