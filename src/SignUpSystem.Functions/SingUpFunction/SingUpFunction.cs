using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace SignUpSystem.Functions
{
    public static class SingUpFunction
    {
        [FunctionName("SingUpFunction")]
        public static void Run([QueueTrigger("myqueue-items", Connection = "")]string myQueueItem, TraceWriter log)
        {
            //Here we use automatic binders to different resources.
            //Logs target Application Insights with trackable Id so we can restore the whole flow.
            log.Info($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
