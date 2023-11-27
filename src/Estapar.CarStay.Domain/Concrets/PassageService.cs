using Estapar.CarStay.Data.Context;
using Estapar.CarStay.Data.Entity;
using Estapar.CarStay.Data.Repositories.Concrets;
using Estapar.CarStay.Domain.Extensions;
using Estapar.CarStay.Domain.Interfaces;
using Estapar.CarStay.Domain.Requets;
using Estapar.CarStay.Domain.Responses;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Estapar.CarStay.Domain.Concrets
{
    public class PassageService : BaseRepository<Passage>, IPassageService
    {
        public PassageService(CarStayContext dbContext) : base(dbContext)
        {
        }

        public async Task<Passage> Fechar(string garagem, string carroPlaca)
        {
            var result = await dbSet.AsNoTracking()
                                                  .Include(_ => _.Garage)
                                                  .Include(_ => _.PaymentMethod)
                                                  .FirstOrDefaultAsync(e => e.GarageCode == garagem && e.CarPlate == carroPlaca);

            if (result is null) throw new Exception("Veiculo não encontrado");

            result.TotalPrice = result.CalculateTotal();
            result.EndDateTime = DateTime.Now;

            return result;
        }

        public async Task<IEnumerable<Passage>> ListaCarros(string garagem, ListCarRequest request)
        {
            Expression<Func<Passage, bool>> predicate = x => x.GarageCode == garagem
                                                                                            && x.StartDateTime >= request.StartDateTime
                                                                                            && (request.Status == Enuns.StatusType.Todos ||
                                                                                                ((request.Status == Enuns.StatusType.Fechados && x.EndDateTime <= request.EndDateTime) ||
                                                                                                (request.Status == Enuns.StatusType.Abertos && x.EndDateTime == null)));

            var result = await dbSet.AsNoTracking()
                                      .Include(_ => _.Garage)
                                      .Include(_ => _.PaymentMethod)
                                      .Where(predicate)
                                      .ToListAsync();

            return result;
        }

        public async Task<FechamentoResponse> Fechamento(string garagem, DateTime startDateTime, DateTime endDateTime)
        {
            var result = await dbSet.AsNoTracking()
                                      .Include(_ => _.Garage)
                                      .Include(_ => _.PaymentMethod)
                                      .Where(e => e.GarageCode == garagem
                                            && e.EndDateTime != null
                                            && e.StartDateTime >= startDateTime
                                            && e.EndDateTime <= endDateTime)
                                      .ToListAsync();

            var totalVeiculos = result.Count();
            var valorTotal = result.Sum(x => x.CalculateTotal());

            var totalFees = result.GroupBy(x => x.PaymentMethodCode);
            var PaymentMethodGroup = result.GroupBy(x => x.PaymentMethod);

            var detalhes = PaymentMethodGroup.Select(x => new Detalhes()
            {
                FormaPagamento = x.Key.Description,
                ValorTotal = x.Sum(_ => _.CalculateTotal()),
                TotalCarros = x.Count()
            });

            var response = new FechamentoResponse()
            {
                TotalVeiculos = totalVeiculos,
                ValorTotal = valorTotal,
                Detalhes = detalhes
            };

            return response;
        }

        public async Task<MediaResponse> TempoMedio(string garagem, DateTime startDateTime, DateTime endDateTime)
        {
            var result = await dbSet.AsNoTracking()
                                      .Include(_ => _.Garage)
                                      .Include(_ => _.PaymentMethod)
                                      .Where(e => e.GarageCode == garagem
                                            && e.EndDateTime != null
                                            && e.StartDateTime >= startDateTime
                                            && e.EndDateTime <= endDateTime)
                                      .ToListAsync();

            var monthlyPayers = result.Where(x => x.PaymentMethodCode == "MEN");
            var nonMonthlyPayers = result.Where(x => x.PaymentMethodCode != "MEN");

            var response = new MediaResponse()
            {
                MonthlyAverage = monthlyPayers.CalculateMedia(),
                NonMonthlyAverage = nonMonthlyPayers.CalculateMedia()
            };

            return response;
        }
    }
}
