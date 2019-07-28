using System;
using rp2.api.MongoModels;

namespace rp2.api.Singletons
{
    public class Configurations
    {
        private static Configurations instance;

        private Configurations() { }

        public static Configurations Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Configurations();
                }
                return instance;
            }
        }

        public DatabaseMongoSettings DatabaseMongoSettings { get; set; }
    }
}
