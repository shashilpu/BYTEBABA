using BYTEBaba.Repository.SqlServer;

namespace BYTEBaba.Services.SqlServer
{
    public class SQLServerService<T> : ISQLServerService<T> where T:class
    {
        private readonly ISQLServer<T> _repository;
        public SQLServerService(ISQLServer<T> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<T> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Add(T tradeOpportunity)
        {
            await _repository.Add(tradeOpportunity);
        }

        public void Update(T tradeOpportunity)
        {
            _repository.Update(tradeOpportunity);
        }

        public void Delete(T tradeOpportunity)
        {
            _repository.Delete(tradeOpportunity);
        }
    }
}
