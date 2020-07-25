using System;
using Api.Data.Collections;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Api.Data
{
    /// <summary>
    /// Classe responsável pela configuração de conexão com o banco de dados.
    /// </summary>
    public class MongoDB
    {
        /// <value>Propriedade de referência com o banco de dados.</value>
        public IMongoDatabase DB { get; }

        /// <summary>
        /// Construtor responsável pelo recebimento das configurações com o MongoDB.
        /// </summary>
        /// <param name="configuration">Parâmetro de configuração com o MongoDB</param>
        public MongoDB(IConfiguration configuration)
        {
            try
            {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(configuration["ConnectionString"]));
                var client = new MongoClient(settings);
                DB = client.GetDatabase(configuration["NomeBanco"]);
                MapClasses();
            }
            catch (Exception ex)
            {
                throw new MongoException("It was not possible to connect to MongoDB", ex);
            }
        }

        /// <summary>
        /// Método encarregado do mapeamento da entidade Infectado no banco da dados.
        /// </summary>
        private void MapClasses()
        {
            var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("camelCase", conventionPack, t => true);

            if (!BsonClassMap.IsClassMapRegistered(typeof(Infectado)))
            {
                BsonClassMap.RegisterClassMap<Infectado>(i =>
                {
                    i.AutoMap();
                    i.SetIgnoreExtraElements(true);
                });
            }
        }
    }
}