
using System.ComponentModel.DataAnnotations;

namespace Estapar.CarStay.Data.Entity
{
    public class Garage : IEntity
    {
        [Key]
        public string Code { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public decimal Price_1aHour { get; set; }
        public decimal Price_ExtraHours { get; set; }
        public decimal Price_Monthly { get; set; }        
    }
}
