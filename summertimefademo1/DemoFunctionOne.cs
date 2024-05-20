using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace summertimefademo1
{
    public class DemoFunctionOne
    {
        private readonly ILogger<DemoFunctionOne> _logger;

        public DemoFunctionOne(ILogger<DemoFunctionOne> logger)
        {
            _logger = logger;
        }

        [Function("DemoFunctionOne")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            string? name = req.Query["name"].ToString();
            string responseMessage;
            if (string.IsNullOrEmpty(name))
            {
                responseMessage = "welcome to azure function, you have passed no name parameter!";
            }
            else
            {
                responseMessage = "Welcome to azure function " + name;
            }
            return new OkObjectResult(responseMessage);
        }
    }
}
