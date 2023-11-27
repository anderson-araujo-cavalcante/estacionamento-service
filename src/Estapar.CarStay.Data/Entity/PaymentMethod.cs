using System.ComponentModel.DataAnnotations;

namespace Estapar.CarStay.Data.Entity
{
    public class PaymentMethod : IEntity
    {
        [Key]
        public string Code { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;        
        public string Description { get; set; }
    }
}
