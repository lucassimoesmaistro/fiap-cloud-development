using System;
using System.Threading.Tasks;
using Azure.Data.Tables;
using Azure;

namespace TableStorage
{
    class Program
    {

        static string connectionString = "DefaultEndpointsProtocol=https;AccountName=fiapclouddevelopment;AccountKey=1xhWvBtbAUkz5yuShZ1lelTFVVwu4KKaZsP4+/0oQSk6Bnr1YEtdDqBQhqjbsrAijnN6JvcIIVzm4ijMejNwKw==;EndpointSuffix=core.windows.net";
        static string tableName = "Orders";
        
        
        static async Task Main(string[] args)
        {
            
            //QueryEntity("Laptop");

            DeleteEntity("Laptop", "O2");
            Console.WriteLine("Complete");
            
        }

        static async Task QueryEntity(string category)
        {
            TableClient tableClient = new TableClient(connectionString, tableName);

            Pageable<TableEntity> queryResults = tableClient.Query<TableEntity>(entity => entity.PartitionKey == category);

            Console.WriteLine("The Entities within the partition {0}", category);
            foreach (TableEntity tableEntity in queryResults)
            {
                

                Console.WriteLine("Order ID {0}",tableEntity.RowKey);
                Console.WriteLine("Quantity {0}", tableEntity.GetInt32("quantity"));

            }
        }

        static async Task DeleteEntity(string category,string orderID)
        {
            TableClient tableClient = new TableClient(connectionString, tableName);
            tableClient.DeleteEntity(category, orderID);
            Console.WriteLine("Entity with Partition Key {0} and Row Key {1} deleted", category, orderID);
        }

    }
}
