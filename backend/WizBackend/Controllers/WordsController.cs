using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using WizBackend.DataHandler;

namespace WizBackend.Controllers
{
    [Route("api/words")]
    [EnableCors("CrossOrigin")]
    [ApiController]
    [Produces("application/json")]
    public class WordsController : ControllerBase
    {
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
        public JsonResult Get(string part)
        {

        }


    }
}
