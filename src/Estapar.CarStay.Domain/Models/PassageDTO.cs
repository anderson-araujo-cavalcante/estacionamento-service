﻿namespace Estapar.CarStay.Domain.Models
{
    public class PassageDTO
    {
        public string Garagem { get; set; }
        public string CarroPlaca { get; set; }
        public string CarroMarca { get; set; }
        public string CarroModelo { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public DateTime? DataHoraSaida { get; set; }
        public string FormaPagamento { get; set; }
        public decimal PrecoTotal { get; set; }
    }

    public class PassageCreateDTO
    {
        public string Garagem { get; set; }
        public string CarroPlaca { get; set; }
        public string CarroMarca { get; set; }
        public string CarroModelo { get; set; }
        public string FormaPagamento { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public DateTime? DataHoraSaida { get; set; }
    }
}
