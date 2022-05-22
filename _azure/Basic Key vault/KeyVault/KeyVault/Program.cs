using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyVault
{
    class Program
    {
        static void Main(string[] args)
        {
            string keyVaultUrl = "https://demovault90900.vault.azure.net/";
            var client = new SecretClient(vaultUri: new Uri(keyVaultUrl), credential: new DefaultAzureCredential());
                        
            KeyVaultSecret secret = client.GetSecret("dbpassword");
            Console.WriteLine(secret.Value);
            Console.ReadKey();
            
        }
    }
}
//{
//  "appId": "5a8db4a9-8af2-40a7-b8b6-86b534a8c697",
//  "displayName": "secretapp",
//  "name": "http://secretapp",
//  "password": "hsEyDV6Xn22S66~_UaZip0a9ipcsfoRkjG",
//  "tenant": "3c6560bb-6078-4eab-99c5-b5d1feb73657"
//}