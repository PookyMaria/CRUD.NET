using Dapper;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using NetCoreAPIMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Data.Repositories
{
    public class CarsRepository : ICarsRepositorie
    {
        private readonly MySQLConfiguration _conecctionString;

        public CarsRepository(MySQLConfiguration conecctionString)
        { 
            _conecctionString = conecctionString;
        }

        protected MySqlConnection DbConnecction()
        {
            return new MySqlConnection(_conecctionString.ConnectionString);
        }


        public async Task<bool> DeleteCars(Cars cars )
        {
            var db = DbConnecction();
            var sql = "DELETE FROM cars WHERE id = @Id";
            var result = await db.ExecuteAsync( sql, new { Id = cars.Id });
            return result > 0;
        }

        public async Task<Cars> GetDetails(int id)
        {
            var db = DbConnecction();

            var sql = @"SELECT id,make,model,color,year,doors FROM cars WHERE id = @Id";

            return await db.QueryFirstOrDefaultAsync<Cars>(sql, new { Id = id});
        }

        public async Task<IEnumerable<Cars>> GetAllCars()
        {
            var db= DbConnecction();

            var sql = @"SELECT id,make,model,color,year,doors FROM cars";
            return await db.QueryAsync<Cars>(sql, new { });
        }

        public async Task<bool> InsertCars(Cars cars)
        {
            var db = DbConnecction();

            var sql = @"INSERT INTO cars (make,model,color,year,doors) VALUES (@make,@model,@color,@year,@doors)";

            var result = await db.ExecuteAsync(sql, new { cars.Make, cars.Model, cars.Color, cars.Year, cars.Doors});
            return result > 0;
        }

        public async Task<bool> UpdateCars(Cars cars)
        {
            var db = DbConnecction();

            var sql = @"UPDATE cars SET make=@make, model=@Model ,color=@Color, year=@Year, doors=@Doors WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new { cars.Make, cars.Model, cars.Color, cars.Year, cars.Doors, cars.Id});
            return result > 0;
        }
    }
}
