using System.Security.Authentication;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StudyGroups.Core.Entities;
using StudyGroups.Core.Interfaces;
using StudyGroups.Infrastructure.DTO;

namespace StudyGroups.Infrastructure.Persistence.Context
{
    public class DbClient : IDbClient
    {
        private readonly IMongoDatabase _database;

        public DbClient(IOptions<DbConfig> dbConfig)
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(
                new MongoUrl(@$"{dbConfig.Value.Connection_String}")
            );

            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            var client = new MongoClient(settings);

            _database = client.GetDatabase(dbConfig.Value.Database_Name);
        }

        public IMongoCollection<Card> GetCardsCollection() => _database.GetCollection<Card>("Cards");
    }
}
