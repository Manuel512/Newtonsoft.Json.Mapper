using System.Collections.Generic;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Mapper;

namespace Newtonsoft.Json.Mapper.Service
{
    public static class MapperService
    {
        [FunctionName("MapperService")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# MapperService function started.");
            string result;
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var dto = JsonConvert.DeserializeObject<ServiceDTO>(requestBody);

                result = JsonMapper.MapToJsonString(JsonConvert.SerializeObject(dto.Source), dto.MappingRules);

                log.LogInformation("C# MapperService function finished.");
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is ArgumentNullException)
                    return new BadRequestObjectResult(new { message = ex.Message });
                else
                    throw;
            }


            return new OkObjectResult(result);
        }
    }

    public class ServiceDTO
    {
        public ServiceDTO()
        {
            MappingRules = new List<MappingRule>();
        }

        public object Source { get; set; }
        public List<MappingRule> MappingRules { get; set; }
    }
}

