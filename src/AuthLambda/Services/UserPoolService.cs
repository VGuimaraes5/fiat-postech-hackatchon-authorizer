using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using AuthLambda.Utils;

namespace AuthLambda.Services
{
    public class UserPoolService
    {
        private readonly AmazonCognitoIdentityProviderClient _provider;

        public UserPoolService(AmazonCognitoIdentityProviderClient provider)
        {
            _provider = provider;
        }

        public async Task<string> GetUserPoolId()
        {
            var userPoolId = (await _provider.ListUserPoolsAsync(new ListUserPoolsRequest()))
                .UserPools.FirstOrDefault(x => x.Name == AwsConstants.UserPoolName)?.Id ?? throw new InvalidOperationException("Not found!");

            return userPoolId;
        }

        public async Task<string> GetUserPoolClientId(string userPoolId)
        {
            var clientId = (await _provider.ListUserPoolClientsAsync(new ListUserPoolClientsRequest { UserPoolId = userPoolId }))
                .UserPoolClients.FirstOrDefault()?.ClientId ?? throw new InvalidOperationException("Not found!");

            return clientId;
        }
    }
}