using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace rp2.api.MongoModels
{
    public class RepresentanteDbModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        public string tipo { get; set; }

        public string jurisdiccion { get; set; }

        public string url { get; set; }

        public string partido { get; set; }

        public List<PropuestaDbModel> propuestas { get; set; }

        public string correo { get; set; }

        public string telefono { get; set; }

        public int distrito { get; set; }

        public string estado { get; set; }
    }
}
