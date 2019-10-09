using Microsoft.AspNetCore.Mvc;
using AnagramCheckerClassLibrary;

namespace AnagramCheckerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetPermutationsController : ControllerBase
    {
        private readonly IAnagramCheckerLibrary lib;

        public GetPermutationsController(IAnagramCheckerLibrary lib)
        {
            this.lib = lib;
        }

        [HttpGet]
        public IActionResult GetPermutations([FromQuery] string w)
        {
            var permutations = lib.GetPermutations(w);
            return Ok(permutations);
        }
    }
}
