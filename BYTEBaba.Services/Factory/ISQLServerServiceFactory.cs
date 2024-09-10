using BYTEBaba.Services.SqlServer;

namespace BYTEBaba.Services.Factory
{
    public interface ISQLServerServiceFactory
    {
        ISQLServerService<T> Create<T>() where T : class;
    }
}
