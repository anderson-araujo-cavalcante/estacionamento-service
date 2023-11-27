using Estapar.CarStay.Data.Entity;

namespace Estapar.CarStay.Domain.Extensions
{
    public static class PassageExtension
    {
        public static decimal CalculateTotal(this Passage passage)
        {
            var value1aHour = passage.Garage.Price_1aHour;
            var PaymentMethod = passage.PaymentMethod;
            var totalPrice = decimal.Zero;

            if (PaymentMethod.Code != "MEN")
            {
                TimeSpan ts = passage.EndDateTime.Value - passage.StartDateTime;

                if (ts.Hours < 1) return value1aHour;

                var valueHours = ts.Hours * value1aHour;
                var valueFrationary = ts.Minutes <= 30 ? value1aHour * 0.5m : value1aHour;
                totalPrice = valueHours + valueFrationary;
            }

            return totalPrice;
        }

        public static double CalculateTimeInMinutes(this Passage passage)
        {
            if (!passage.EndDateTime.HasValue) return default;

            return (passage.EndDateTime.Value - passage.StartDateTime).TotalMinutes;
        }

        public static string CalculateMedia(this IEnumerable<Passage> passages)
        {
            var totalMinutes = passages.Sum(x => x.CalculateTimeInMinutes());
            var totalCar = passages.Count();

            if (totalCar == 0) return string.Empty;

            var media = totalMinutes / totalCar;
            var mediaTempo = media / 60;

            return TimeSpan.FromHours(mediaTempo).ToString();
        }
    }
}
