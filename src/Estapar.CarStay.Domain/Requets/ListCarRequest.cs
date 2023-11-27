using Estapar.CarStay.Domain.Enuns;

namespace Estapar.CarStay.Domain.Requets
{
    public class ListCarRequest
    {
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public StatusType Status { get; set; }
    }
}
