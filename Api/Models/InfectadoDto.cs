using System;

namespace Api.Models
{
    /// <summary>
    /// Classe de modelo responsável por retornar as propriedades da entidade infectado.
    /// </summary>
    public class InfectadoDto
    {
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}