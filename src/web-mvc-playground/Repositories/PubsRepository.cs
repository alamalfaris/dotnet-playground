using Dapper;
using System.Data;
using web_mvc_playground.Models;

namespace web_mvc_playground.Repositories
{
    public class PubsRepository : IPubsRepository
    {
        private readonly IDbConnection _db;

        public PubsRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            string sql = $@"SELECT [au_id] [AuId], [au_lname] [AuLname], [au_fname] [AuFname], [phone], [address], [city], [state], [zip], [contract] 
                            FROM authors";

            return await _db.QueryAsync<Author>(sql);
        }

        private string _queryGetAllPublisher = $@"SELECT a.pub_id [PubId], a.pub_name [PubName], b.logo, b.pr_info [PrInfo]
                            FROM publishers a
                            INNER JOIN pub_info b ON a.pub_id = b.pub_id";
        public async Task<IEnumerable<Publisher>> GetAllPublisherAsync()
        {
            return await _db.QueryAsync<Publisher>(_queryGetAllPublisher);
        }

        public async Task<Publisher?> GetPublisherById(string id)
        {
            string sql = $@"{_queryGetAllPublisher}
                            WHERE a.pub_id = @id";

            return await _db.QueryFirstOrDefaultAsync<Publisher>(sql, new { id });
        }
    }
}
