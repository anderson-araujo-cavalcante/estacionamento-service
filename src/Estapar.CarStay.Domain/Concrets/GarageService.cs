using Estapar.CarStay.Data.Context;
using Estapar.CarStay.Data.Entity;
using Estapar.CarStay.Data.Repositories.Concrets;
using Estapar.CarStay.Domain.Interfaces;

namespace Estapar.CarStay.Domain.Concrets
{
    public class GarageService : BaseRepository<Garage>, IGarageService
    {
        public GarageService(CarStayContext dbContext) : base(dbContext)
        {
        }
    }
}
