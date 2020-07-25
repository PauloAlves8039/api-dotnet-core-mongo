using Api.Data.Collections;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Api.Controllers
{
    /// <summary>
    /// Controlador responsável pelas ações de inserção e listagem de dados da entidade infectado.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
         Data.MongoDB _mongoDB;
        IMongoCollection<Infectado> _infectadosCollection;

        public InfectadoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        /// <summary>
        /// Action responsável por inserir dados.
        /// </summary>
        /// <param name="dto">Parâmetro para recebimento de propriedades da classe InfectadoDto.</param>
        /// <returns>O estado da inserção de dados.</returns>
        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadoDto dto)
        {
            var infectado = new Infectado(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);

            _infectadosCollection.InsertOne(infectado);
            
            return StatusCode(201, "Infectado adicionado com sucesso");
        }

        /// <summary>
        /// Action responsável por listar todos os infectados.
        /// </summary>
        /// <returns>Lista de infectados.</returns>
        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();
            
            return Ok(infectados);
        }
    }
}