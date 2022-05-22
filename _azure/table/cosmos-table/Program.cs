using Microsoft.Azure.Cosmos.Table;
using System;
using System.Threading.Tasks;

namespace cosmos_table
{
    class Program
    {
        static string connection_string= "DefaultEndpointsProtocol=https;AccountName=0storage80808lsm;AccountKey=k3y2n/XE1E/Y+SokUHkoIMpFVbwkX5F7l17/beh1XXyDtm2cWC+AlW6KdRM0a/zaAqVkd4Pwd+C6GY6tgkxRaA==;EndpointSuffix=core.windows.net";
        static void Main(string[] args)
        {
            //NewItem().Wait();
            ReadItem().Wait();
            //UpdateItem().Wait();
            //DeleteItem().Wait();
            Console.ReadLine();
        }

        static async Task NewItem()
        {
            CloudStorageAccount p_account = CloudStorageAccount.Parse(connection_string);
            
            CloudTableClient p_tableclient = p_account.CreateCloudTableClient();
            
            CloudTable p_table = p_tableclient.GetTableReference("Customer");

            Customer obj = new Customer("2", "James", "New York");
            TableOperation p_operation = TableOperation.Insert(obj);
            TableResult response = await p_table.ExecuteAsync(p_operation);

            Console.WriteLine("Entity added");
        }

        static async Task ReadItem()
        {
            CloudStorageAccount p_account = CloudStorageAccount.Parse(connection_string);

            CloudTableClient p_tableclient = p_account.CreateCloudTableClient();

            CloudTable p_table = p_tableclient.GetTableReference("Customer");

            string partition_key = "2";
            string rowkey = "James";

            TableOperation p_operation = TableOperation.Retrieve<Customer>(partition_key, rowkey);
            TableResult response = await p_table.ExecuteAsync(p_operation);

            Customer return_obj = (Customer)response.Result;

            Console.WriteLine("Customer ID is {0}", return_obj.PartitionKey);
            Console.WriteLine("Customer Name is {0}", return_obj.RowKey);
            Console.WriteLine("Customer City is {0}", return_obj.city);


        }

        static async Task UpdateItem()
        {
            CloudStorageAccount p_account = CloudStorageAccount.Parse(connection_string);

            CloudTableClient p_tableclient = p_account.CreateCloudTableClient();

            CloudTable p_table = p_tableclient.GetTableReference("Customer");

            string partition_key = "2";
            string rowkey = "James";

            Customer updated_obj = new Customer(partition_key, rowkey, "Chicago");

            TableOperation p_operation = TableOperation.InsertOrReplace(updated_obj);
            TableResult response = await p_table.ExecuteAsync(p_operation);
            Console.WriteLine("Entity updated");

        }

        static async Task DeleteItem()
        {
            CloudStorageAccount p_account = CloudStorageAccount.Parse(connection_string);

            CloudTableClient p_tableclient = p_account.CreateCloudTableClient();

            CloudTable p_table = p_tableclient.GetTableReference("Customer");

            string partition_key = "2";
            string rowkey = "James";

            TableOperation p_operation = TableOperation.Retrieve<Customer>(partition_key, rowkey);
            TableResult response = await p_table.ExecuteAsync(p_operation);

            Customer return_obj = (Customer)response.Result;


            TableOperation p_delete = TableOperation.Delete(return_obj);

            response = await p_table.ExecuteAsync(p_delete);
            Console.WriteLine("Entity deleted");

        }
    }
    }
