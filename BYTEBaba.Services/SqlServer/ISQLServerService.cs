using BYTEBaba.Model.Entities;

namespace BYTEBaba.Services.SqlServer
{
    public interface ISQLServerService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T tradeOpportunity);
        void Update(T tradeOpportunity);
        void Delete(T tradeOpportunity);       
    }
}
