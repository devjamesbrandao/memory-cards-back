using MongoDB.Driver;
using StudyGroups.Core.Entities;
using StudyGroups.Core.Interfaces;

namespace StudyGroups.Core.Services
{
    public class StudyGroupService : IStudyGroupService
    {
        private readonly IMongoCollection<Card> _cardsCollection;
        
        public StudyGroupService(IDbClient dbClient) => _cardsCollection = dbClient.GetCardsCollection();

        public async Task AddAsync(List<Card> cards) => await _cardsCollection.InsertManyAsync(cards);
        
        public async Task DeleteGroupAsync(string groupName) => await _cardsCollection.DeleteManyAsync(cards => cards.GroupName.Equals(groupName));

        public async Task<IEnumerable<Card>> GetGroupAsync(string groupName)
        {
            return (await _cardsCollection.FindAsync(cards => cards.GroupName.Equals(groupName))).ToEnumerable();
        }

        public async Task<IEnumerable<string>> GetGroupNames()
        {
            return await Task.FromResult(_cardsCollection.AsQueryable().Select(x => x.GroupName).Distinct());
        }
    }
}
