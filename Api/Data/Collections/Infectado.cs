using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Api.Data.Collections
{
    /// <summary>
    /// Classe responsável por representar as propriedades da entidade infectado.
    /// </summary>
    public class Infectado
    {
        /// <summary>
        /// Construtor responsável pela atribuição das propriedades da entidade infectado.
        /// </summary>
        /// <param name="dataNascimento">Recebe propriedade para a data de nascimento.</param>
        /// <param name="sexo">Recebe propriedade para o sexo do infectado.</param>
        /// <param name="latitude">Recebe a propriedade de localização para a latitude.</param>
        /// <param name="longitude">Recebe a propriedade de localização para a longitude.</param>
        public Infectado(DateTime dataNascimento, string sexo, double latitude, double longitude)
        {
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            this.Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }

        /// <value>Propriedade de referência para data de nascimento.</value>
        public DateTime DataNascimento { get; set; }

        /// <value>Propriedade de referência do sexo da pessoa infectada.</value>
        public string Sexo { get; set; }

        /// <value>Propriedade resposnável pela localização da pessoa infectada</value>
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }
    }
}