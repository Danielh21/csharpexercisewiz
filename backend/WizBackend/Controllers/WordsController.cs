using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using WizBackend.DataHandler;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;

namespace WizBackend.Controllers
{
    [Route("api/words")]
    [EnableCors("CrossOrigin")]
    [ApiController]
    [Produces("application/json")]
    public class WordsController : ControllerBase
    {

        private static readonly HttpClient client = new HttpClient();


        // GET api/values
        [HttpGet("db/{part}")]
        public JsonResult DatabaseResult(string part)
        {
            List<String> MatchingWords = WordHandler.LookUpWord(part);
            return new JsonResult(new
            {
                MatchingWords
            });
        }

        [HttpGet("webservice/{part}")]
        public async Task<JsonResult> WebServiceResult(string part)
        {
            // File is ignored with git
            var token = System.IO.File.ReadAllText("Token.txt");

            client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync("https://services.lingapps.dk/misc/getPredictions?locale=da-DK&text=" + part);
            var responseString = response.Content.ReadAsStringAsync().Result;
            return new JsonResult(new
            {

            });
        }


    }
}
