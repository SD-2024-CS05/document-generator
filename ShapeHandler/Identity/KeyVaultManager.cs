using Azure;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ShapeHandler.Identity
{
    public class KeyVaultManager
    {

        private readonly IConfiguration configuration;
        private readonly SecretClient client;

        public KeyVaultManager()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;

            if (!dir.Contains("appsettings.json"))
            {
                dir = Path.Combine(dir, "bin");
            }

            var builder = new ConfigurationBuilder()
                .SetBasePath(dir)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            configuration = builder.Build();

            string keyVaultUrl = configuration["AzureKeyVaultURI"];

            if (keyVaultUrl == null)
            {
                throw new ArgumentNullException("AzureKeyVaultURI does not exist");
            }

            // Initialize the KeyVaultClient with Visual Studio credentials
            client = new SecretClient(new Uri(keyVaultUrl), new VisualStudioCredential());
        }

        /// <summary>
        /// Get a secret from the KeyVault
        /// </summary>
        /// <param name="secretName">The Name of the Secret</param>
        /// <returns></returns>
        /// <exception cref="Exception">Exception if cannot reach Azure Key Vault</exception>
        public async Task<string> GetSecretAsync(string secretName)
        {
            // first try from configuration, then keyvault, then fail
            string secret = configuration[secretName];
            if (secret == null)
            {
                try
                {
                    var secretResponse = await client.GetSecretAsync(secretName);
                    return secretResponse.Value.Value;
                }
                catch (RequestFailedException e)
                {
                    throw new RequestFailedException($"Failed to retrieve secret {secretName} from KeyVault", e);
                }
            }
            return secret;
        }
    }
}
