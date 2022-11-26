
using Azure.Data.Tables;

using System;
using System.Threading.Tasks;

namespace TableStorage
{
    class Program
    {

        static string connectionString = "DefaultEndpointsProtocol=https;AccountName=storageaccountfiapmba;AccountKey=Yjzjnh05Ajy1LlmnVSmWydlCVEAswuQhzHTU3kLvzPK8GCn71WJ6vIXtdDeWBTVhb0JJhjyZHYGs+AStowImmg==;EndpointSuffix=core.windows.net";
        static string tableName = "Clientes";
        
        
        static async Task Main(string[] args)
        {
            
            AddEntity("Lucas", "AgPaulista", 100).Wait();
            AddEntity("Joao", "AgLapa", 50).Wait();
            AddEntity("Jose", "AgPaulista", 70).Wait();
            AddEntity("Pedro", "AgIndaiatuba", 200).Wait();
            Console.WriteLine("Complete");
            
        }

        


        static async Task  AddEntity(string orderID,string category,int quantity)
        {
            TableClient tableClient = new TableClient(connectionString, tableName);

            TableEntity tableEntity = new TableEntity(category, orderID)
            {
                {"quantity",quantity}
            };

            tableClient.AddEntity(tableEntity);
            Console.WriteLine("Added Entity with order ID {0}",orderID);
        }

        
    }
}
