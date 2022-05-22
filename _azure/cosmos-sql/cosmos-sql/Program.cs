using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;

namespace cosmos_sql
{
    class Program
    {
        static string database = "appdb";
        static string containername = "customer";
        static string endpoint = "https://appaccountlsm.documents.azure.com:443/";
        static string accountkeys = "BQaiQOPCEWZ6AqKdnLggGxNV8pjoW68VMigRPPPpx847es5rxkH43gULRgE8lnlXVOVoS7f45FwFtCaNJkGMqw==";

        static async Task Main(string[] args)
        {
            //CreateNewItem().Wait();
            ReadItem().Wait();
            //ReplaceItem().Wait();
            //DeleteItem().Wait();
            Console.ReadLine();
        }

        private static async Task CreateNewItem()
        {
            using (CosmosClient cosmos_client = new CosmosClient(endpoint, accountkeys))
            {

                Database db_conn = cosmos_client.GetDatabase(database);

                Container container_conn = db_conn.GetContainer(containername);

                customer obj = new customer(1, "John", "Miami");
                obj.id = Guid.NewGuid().ToString();


                ItemResponse<customer> response = await container_conn.CreateItemAsync(obj);
                Console.WriteLine("Request charge is {0}", response.RequestCharge);
                Console.WriteLine("Customer added");
            }
        }

        private static async Task ReadItem()
        {
            using (CosmosClient cosmos_client = new CosmosClient(endpoint, accountkeys))
            {

                Database db_conn = cosmos_client.GetDatabase(database);

                Container container_conn = db_conn.GetContainer(containername);

                string cosmos_sql = "select c.customerIid,c.customerName,c.city from c";
                QueryDefinition query = new QueryDefinition(cosmos_sql);

                FeedIterator<customer> iterator_obj = container_conn.GetItemQueryIterator<customer>(cosmos_sql);


                while (iterator_obj.HasMoreResults)
                {
                    FeedResponse<customer> customer_obj = await iterator_obj.ReadNextAsync();
                    foreach (customer obj in customer_obj)
                    {
                        Console.WriteLine("Customer id is {0}", obj.customerid);
                        Console.WriteLine("Customer name is {0}", obj.customername);
                        Console.WriteLine("Customer city is {0}", obj.city);
                    }
                }

            }
        }

        private static async Task ReplaceItem()
        {
            using (CosmosClient cosmos_client = new CosmosClient(endpoint, accountkeys))
            {

                Database db_conn = cosmos_client.GetDatabase(database);

                Container container_conn = db_conn.GetContainer(containername);

                PartitionKey pk = new PartitionKey("Miami");
                string id = "0e31ed86-9824-4fe6-a6de-a7853348f344";

                ItemResponse<customer> response = await container_conn.ReadItemAsync<customer>(id, pk);
                customer customer_obj = response.Resource;

                customer_obj.customername = "James";

                response = await container_conn.ReplaceItemAsync<customer>(customer_obj, id, pk);
                Console.WriteLine("Item updated");

            }
        }

        private static async Task DeleteItem()
        {
            using (CosmosClient cosmos_client = new CosmosClient(endpoint, accountkeys))
            {

                Database db_conn = cosmos_client.GetDatabase(database);

                Container container_conn = db_conn.GetContainer(containername);

                PartitionKey pk = new PartitionKey("Miami");
                string id = "0e31ed86-9824-4fe6-a6de-a7853348f344";

                ItemResponse<customer> response = await container_conn.DeleteItemAsync<customer>(id, pk);

                Console.WriteLine("Item deleted");
            }

            }
        }
}
