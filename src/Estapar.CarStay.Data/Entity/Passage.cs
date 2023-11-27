using System.ComponentModel.DataAnnotations;

namespace Estapar.CarStay.Data.Entity
{
    public class Passage : IEntity
    {
        [Key]
        public string Code { get; set; }
        public DateTime CreatedAt { get; set; }
        public string GarageCode { get; set; }
        public virtual Garage Garage { get; set; }
        public string CarPlate { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public string PaymentMethodCode { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
