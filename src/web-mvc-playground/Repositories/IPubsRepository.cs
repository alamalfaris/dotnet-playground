using web_mvc_playground.Models;

namespace web_mvc_playground.Repositories
{
    public interface IPubsRepository
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<IEnumerable<Publisher>> GetAllPublisherAsync();
        Task<Publisher?> GetPublisherById(string id);
    }
}
