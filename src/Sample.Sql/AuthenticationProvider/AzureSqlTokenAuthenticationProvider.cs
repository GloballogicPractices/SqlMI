using Azure.Core;
using Azure.Identity;
using Microsoft.Data.SqlClient;

namespace Sample.Sql.AuthenticationProvider
{
    public class AzureSqlTokenAuthenticationProvider : SqlAuthenticationProvider
    {
        private static readonly string[] AzureSqlScopes = new[]
        {
            "https://database.windows.net//.default"
        };

        private static readonly TokenCredential Credential = new DefaultAzureCredential();
        private readonly SqlAuthenticationMethod sqlAuthenticationMethod;

        public AzureSqlTokenAuthenticationProvider(SqlAuthenticationMethod sqlAuthenticationMethod)
        {
            this.sqlAuthenticationMethod = sqlAuthenticationMethod;
        }

        public override async Task<SqlAuthenticationToken> AcquireTokenAsync(SqlAuthenticationParameters parameters)
        {
            var tokenRequestContext = new TokenRequestContext(AzureSqlScopes);
            var tokenResult = await Credential.GetTokenAsync(tokenRequestContext, default);
            return new SqlAuthenticationToken(tokenResult.Token, tokenResult.ExpiresOn);
        }

        public override bool IsSupported(SqlAuthenticationMethod authenticationMethod) => authenticationMethod.Equals(sqlAuthenticationMethod);
    }
}
