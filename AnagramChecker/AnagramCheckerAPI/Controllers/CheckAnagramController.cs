using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnagramCheckerClassLibrary;
using Microsoft.Extensions.Configuration;

namespace AnagramCheckerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckAnagramController : ControllerBase
    {
        private readonly IAnagramCheckerLibrary lib;
        private readonly IConfiguration configuration;

        public CheckAnagramController(IAnagramCheckerLibrary lib, IConfiguration configuration)
        {
            this.lib = lib;
            this.configuration = configuration;
        }

        [HttpPost]
        async public Task<IActionResult> CheckAnagram([FromBody] AnagramCheckContainer container)
        {
            var anagramFile = configuration["filename"];
            var areAnagrams = await lib.CheckAnagram(container.W1, container.W2, anagramFile);
            if (areAnagrams)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
