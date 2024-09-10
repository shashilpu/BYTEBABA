using Microsoft.Extensions.DependencyInjection;
using BYTEBaba.Services.SqlServer;

namespace BYTEBaba.Services.Factory
{
    public class SQLServerServiceFactory : ISQLServerServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public SQLServerServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        ISQLServerService<T> ISQLServerServiceFactory.Create<T>() where T : class
        {
            return _serviceProvider.GetService<ISQLServerService<T>>();
        }
    }
}
