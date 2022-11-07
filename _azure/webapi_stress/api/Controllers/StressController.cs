using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class StressController : ControllerBase
{

    private readonly ILogger<StressController> _logger;

    public StressController(ILogger<StressController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public void Get()
    {
        int cpuUsageIncreaseby = 10;
        while (true)
        {
            for (int i = 0; i < 8; i++)
            {
                //Console.WriteLine("am running ");
                //DateTime start = DateTime.Now;
                int cpuUsage = cpuUsageIncreaseby;
                int time = 5000; // duration for cpu must increase for process...
                List<Thread> threads = new List<Thread>();
                for (int j = 0; j < Environment.ProcessorCount; j++)
                {
                    Thread t = new Thread(new ParameterizedThreadStart(CPUKill));
                    t.Start(cpuUsage);
                    threads.Add(t);
                }
                Thread.Sleep(time);
                foreach (var t in threads)
                {
                    if (t.ThreadState != System.Threading.ThreadState.Running && t.ThreadState != System.Threading.ThreadState.WaitSleepJoin)
                        t.Interrupt();
                }

                //DateTime end = DateTime.Now;
                //TimeSpan span = end.Subtract(start);
                //Console.WriteLine("Time Difference (seconds): " + span.Seconds);

                //Console.WriteLine("10 sec wait... for another.");
                cpuUsageIncreaseby = cpuUsageIncreaseby + 10;
                System.Threading.Thread.Sleep(5000);
            }
        }
    }
     public static void CPUKill(object cpuUsage)
    {
        Parallel.For(0, 1, new Action<int>((int i) =>
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            while (true)
            {
                if (watch.ElapsedMilliseconds > (int)cpuUsage)
                {
                        Thread.Sleep(100 - (int)cpuUsage);
                    watch.Reset();
                    watch.Start();
                }
            }
        }));

    }
}
