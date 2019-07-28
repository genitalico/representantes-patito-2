using System;
namespace rp2.api.MongoModels
{
    public class DatabaseMongoSettings
    {
        public string CollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
