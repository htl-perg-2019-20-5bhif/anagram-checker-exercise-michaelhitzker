using System.Threading.Tasks;
using AnagramCheckerClassLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
namespace AnagramCheckerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetKnownAnagramsController : ControllerBase
    {
        private readonly IAnagramCheckerLibrary lib;
        private readonly IConfiguration configuration;
        private readonly ILogger<GetKnownAnagramsController> logger;


        public GetKnownAnagramsController(IAnagramCheckerLibrary lib, IConfiguration configuration, ILogger<GetKnownAnagramsController> logger)
        {
            this.lib = lib;
            this.configuration = configuration;
            this.logger = logger;
        }

        [HttpGet]
        async public Task<IActionResult> GetKnownAnagrams([FromQuery] string w)
        {
            var anagramFile = configuration["filename"];
            var anagrams = await lib.GetKnownAnagrams(w, anagramFile);
            if (anagrams.Length <= 0)
            {
                logger.LogWarning("No known arguments exist for that word!");
                return NotFound("No known anagrams exist for that word!");
            }
            return Ok(anagrams);
        }
    }
}
