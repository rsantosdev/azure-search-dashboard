using Microsoft.Azure.Search;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AzureSearchDashboard.Configuration
{
    public static class AzureSearchConfigurationExtensions
    {
        public static void ConfigureSearchClient(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<ISearchServiceClient, SearchServiceClient>(p =>
            {
                var serviceName = config["AzureSearchServiceName"];
                var serviceApiKey = config["AzureSearchServiceAdminApiKey"];
                return new SearchServiceClient(serviceName, new SearchCredentials(serviceApiKey));
            });
        }
    }
}
