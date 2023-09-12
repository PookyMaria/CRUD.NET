using NetCoreAPIMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Data.Repositories
{
    public interface ICarsRepositorie
    {
        Task<IEnumerable<Cars>> GetAllCars();
        Task<Cars> GetDetails(int id);
        Task<bool> InsertCars(Cars cars);
        Task<bool> UpdateCars(Cars cars);
        Task<bool> DeleteCars(Cars cars);


    }
}
