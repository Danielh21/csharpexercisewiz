using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WizBackend.DataHandler;

namespace WizBackend.Controllers
{
    [Route("api/words")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            WordHandler.LookUpWord("few");
            return new string[] { "value1", "value2" };
        }
    }
}
