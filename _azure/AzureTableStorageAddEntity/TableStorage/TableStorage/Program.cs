﻿
using Azure.Data.Tables;

using System;
using System.Threading.Tasks;

namespace TableStorage
{
    class Program
    {

        static string connectionString = "DefaultEndpointsProtocol=https;AccountName=fiapclouddevelopment;AccountKey=1xhWvBtbAUkz5yuShZ1lelTFVVwu4KKaZsP4+/0oQSk6Bnr1YEtdDqBQhqjbsrAijnN6JvcIIVzm4ijMejNwKw==;EndpointSuffix=core.windows.net";
        static string tableName = "Orders";
        
        
        static async Task Main(string[] args)
        {
            
            AddEntity("O1", "Mobile", 100).Wait();
            AddEntity("O2", "Laptop", 50).Wait();
            AddEntity("O3", "Desktop", 70).Wait();
            AddEntity("O4", "Laptop", 200).Wait();
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
