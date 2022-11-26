using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace whizlabblob
{
    class Program
    {
        static string storageconnstring = "DefaultEndpointsProtocol=https;AccountName=storageaccountfiapmba;AccountKey=Yjzjnh05Ajy1LlmnVSmWydlCVEAswuQhzHTU3kLvzPK8GCn71WJ6vIXtdDeWBTVhb0JJhjyZHYGs+AStowImmg==;EndpointSuffix=core.windows.net";
        static string containerName = "clientes";
        static string filename = "sample.html";
        
        
        static async Task Main(string[] args)
        {
            CreateBlob().Wait();
            Console.WriteLine("Complete");
            
        }

        
        static async Task CreateBlob()
        {
            
            BlobServiceClient blobServiceClient = new BlobServiceClient(storageconnstring);
            
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            
            BlobClient blobClient = containerClient.GetBlobClient(filename);

            String str = "This is a sample file";
            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(str)))
            {
                await blobClient.UploadAsync(memoryStream, overwrite: true);
            }


        }


        
    }
}
