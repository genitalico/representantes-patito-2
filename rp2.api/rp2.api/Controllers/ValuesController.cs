using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using rp2.api.MongoModels;
using rp2.api.Singletons;

namespace rp2.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController()
        {
            
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            var client = new MongoClient(Configurations.Instance.DatabaseMongoSettings.ConnectionString);
            var database = client.GetDatabase(Configurations.Instance.DatabaseMongoSettings.DatabaseName);

            var propuesta = database.GetCollection<RepresentanteDbModel>(Configurations.Instance.DatabaseMongoSettings.CollectionName);

            List<PropuestaDbModel> propuestas = new List<PropuestaDbModel>();
            propuestas.Add(new PropuestaDbModel()
            {
                nombre = "nombre",
                url = "url"
            });
            var document = new RepresentanteDbModel()
            {
                tipo = "tipo",
                jurisdiccion = "jurisdiccion",
                url = "url",
                partido = "partido",
                propuestas = propuestas,
                correo = "correo",
                telefono = "telefono",
                distrito = 1,
                estado = "estado"
            };

            propuesta.InsertOne(document);

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
