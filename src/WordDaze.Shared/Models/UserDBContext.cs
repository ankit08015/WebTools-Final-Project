using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace WordDaze.Shared.Models
{
    public class UserDBContext
    {
        private readonly IMongoDatabase _mongoDatabase;

        public UserDBContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _mongoDatabase = client.GetDatabase("UserDB");
        }

        public IMongoCollection<UserBost> UserBostRecord
        {
            get
            {
                return _mongoDatabase.GetCollection<UserBost>("UserBostRecord");
            }
        }

        public IMongoCollection<UserDetails> UserRecord
        {
            get
            {
                return _mongoDatabase.GetCollection<UserDetails>("UserRecord");
            }
        }
        public IMongoCollection<UserLogin> LoginRecord
        {
            get
            {
                return _mongoDatabase.GetCollection<UserLogin>("LoginRecord");
            }
        }
    }
}
