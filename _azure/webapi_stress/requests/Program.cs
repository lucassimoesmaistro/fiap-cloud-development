using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Start Generating Load");
            await RunTest();
            Console.WriteLine("Completed");
        }
        public static async System.Threading.Tasks.Task RunTest()
        {
            int MAX_ITERATIONS = 500;
            int MAX_PARALLEL_REQUESTS = 500;
            int DELAY = 100;

            // Collection of Url's to test. Change to your valid Url's.
            string url = "https://proud-glacier-9e860a1ab0de45f8b267efbe3505c0f2.azurewebsites.net/WeatherForecast";

            using (var httpClient = new System.Net.Http.HttpClient())
            {
                // To add any headers like Bearer Token, Media Type etc.
                //httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.xxxxxx");

                for (var step = 1; step < MAX_ITERATIONS; step++)
                {
                    Console.WriteLine($"Started iteration: {step}");
                    var tasks = new List<System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage>>();
                    for (int i = 0; i < MAX_PARALLEL_REQUESTS; i++)
                    {
                        tasks.Add(httpClient.GetAsync(url));
                    }
                    // Run all 300 tasks in parallel
                    var result = await System.Threading.Tasks.Task.WhenAll(tasks);
                    Console.WriteLine($"Completed Iteration: {step}");

                    // Some delay before new iteration
                    await System.Threading.Tasks.Task.Delay(DELAY);
                }
            }
        }

    }
}
