using StudyGroups.Core.Entities;

namespace StudyGroups.Core.Interfaces
{
    public interface IStudyGroupService
    {
        Task AddAsync(List<Card> cards);
        Task<IEnumerable<Card>> GetGroupAsync(string groupName);
        Task<IEnumerable<string>> GetGroupNames();
        Task DeleteGroupAsync(string groupName);
    }
}
