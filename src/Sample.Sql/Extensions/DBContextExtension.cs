using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.SqlClient;
using Sample.Sql.AuthenticationProvider;

namespace Sample.Sql.Extensions
{
    public static class DBContextExtension
    {
        private const string Authentication = "Authentication";
        public static IServiceCollection AddSqlAuthenticationProvider(
           this IServiceCollection services,
           string connectionString)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

            if (connectionStringBuilder.ContainsKey(Authentication))
            {
                SqlAuthenticationProvider.SetProvider(
                connectionStringBuilder.Authentication,
                new AzureSqlTokenAuthenticationProvider(connectionStringBuilder.Authentication));
            }

            return services;
        }
    }
}
