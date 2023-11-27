using Estapar.CarStay.Data.Context;
using Estapar.CarStay.Data.Entity;
using Estapar.CarStay.Data.Repositories.Concrets;
using Estapar.CarStay.Domain.Interfaces;

namespace Estapar.CarStay.Domain.Concrets
{
    public class PaymentMethodService : BaseRepository<PaymentMethod>, IPaymentMethodService
    {
        public PaymentMethodService(CarStayContext dbContext) : base(dbContext)
        {
        }
    }
}
