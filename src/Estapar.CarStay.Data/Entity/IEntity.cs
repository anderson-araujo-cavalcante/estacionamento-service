namespace Estapar.CarStay.Data.Entity
{
    public interface IEntity
    {
        public string Code { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
