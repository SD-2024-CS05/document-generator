using Azure;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using ShapeHandler.Database;
using ShapeHandler.Objects;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault.Models;

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

            if (!string.IsNullOrEmpty(keyVaultUrl))
            {
                client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
            }
        }

        public DatabaseConnector ConnectToDatabase()
        {
            string username = GetSecretAsync("Neo4JUsername").Result;
            string password = GetSecretAsync("Neo4JPassword").Result;
            string uri = GetSecretAsync("Neo4JURI").Result;

            return new DatabaseConnector(uri, username, password);
        }

        public async Task<string> GetSecretAsync(string secretName)
        {
            string secret = configuration[secretName];
            if (secret == null)
            {
                try
                {
                    KeyVaultSecret secretBundle = await client.GetSecretAsync(secretName);
                    return secretBundle.Value;
                }
                catch (RequestFailedException e)
                {
                    throw new Exception($"Failed to retrieve secret {secretName} from KeyVault", e);
                }
            }
            return secret;
        }
    }
}
