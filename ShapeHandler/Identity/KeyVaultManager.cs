using Azure;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using ShapeHandler.Database;
using ShapeHandler.Objects;
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
            var appPath = FileManager.GetFilePath("appsettings.json");

            var builder = new ConfigurationBuilder()
                .SetBasePath(appPath)
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
        /// Connects to Neo4J Database
        /// </summary>
        /// <returns></returns>
        public DatabaseConnector ConnectToDatabase()
        {
            string username = GetSecretAsync("Neo4JUsername").Result;
            string password = GetSecretAsync("Neo4JPassword").Result;
            string uri = GetSecretAsync("Neo4JURI").Result;

            return new DatabaseConnector(uri, username, password);
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
