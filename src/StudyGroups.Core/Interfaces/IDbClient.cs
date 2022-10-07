using MongoDB.Driver;
using StudyGroups.Core.Entities;

namespace StudyGroups.Core.Interfaces
{
    public interface IDbClient
    {
        IMongoCollection<Card> GetCardsCollection();
    }
}
