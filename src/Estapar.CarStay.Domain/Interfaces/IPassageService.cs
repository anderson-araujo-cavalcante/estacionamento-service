using Estapar.CarStay.Data.Entity;
using Estapar.CarStay.Data.Repositories.Interfaces;
using Estapar.CarStay.Domain.Requets;
using Estapar.CarStay.Domain.Responses;

namespace Estapar.CarStay.Domain.Interfaces
{
    public interface IPassageService : IBaseRepository<Passage>
    {
        Task <Passage> Fechar(string garagem, string carroPlaca);
        Task <IEnumerable<Passage>> ListaCarros(string garagem, ListCarRequest request);
        Task<FechamentoResponse> Fechamento(string garagem, DateTime startDateTime, DateTime endDateTime);
        Task<MediaResponse> TempoMedio(string garagem, DateTime startDateTime, DateTime endDateTime);
    }
}
