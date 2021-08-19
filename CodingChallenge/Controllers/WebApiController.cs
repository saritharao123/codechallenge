using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace CodingChallenge.Controllers
{
    
    public class PostData
    {
        [Required]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public string Supervisor { get; set; }
    }
    [ApiController]
    [Route("[controller]")]
    public class WebApiController : ControllerBase
    {

        private readonly ILogger<WebApiController> _logger;
        private readonly IConfiguration _configuration;

        public WebApiController(ILogger<WebApiController> logger,IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet("/api/supervisors")]
        public async Task<IActionResult> Get()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(_configuration["apiurl"]);
                var data = response.Content.ReadAsStringAsync().Result;
                var result = JArray.Parse(data).Children<JObject>().Select(jo => $"{jo["jurisdiction"]}-{jo["firstName"]}-{jo["lastName"]}");
                return Ok(result);
            }
        }
        [HttpPost("/api/submit-data")]
        public async Task<IActionResult> Post([FromBody] PostData postData)
        {
            if(this.ModelState.IsValid)
                return Ok(postData);

            return new BadRequestResult();
        }
    }
}
