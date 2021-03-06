using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMovieApp.Business.Services;
using MyMovieApp.Entity;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThetreController : ControllerBase
    {
        ThetreService _thereService;

        public ThetreController(ThetreService thereService)
        {
            _thereService = thereService;
        }

        [HttpGet("selectThetre")]
        public IActionResult selectThetre()
        {
            return Ok(_thereService.SelectThetre());
        }

        [HttpPost("addThetre")]
        public IActionResult addThetre(ThetreModel thetreModel)
        {
            return Ok(_thereService.AddThetre(thetreModel));
        }

        [HttpPut("editthetre")]
        public IActionResult EditThetre(ThetreModel thetreModel)
        {
            return Ok(_thereService.EditThetre(thetreModel));
        }

        [HttpGet("fetchthetre")]
        public IActionResult FetchThetreById(int id)
        {
            return Ok(_thereService.FetchThetreById(id));
        }

        [HttpDelete("deletethetre")]
        public IActionResult DeleteThetre(int id)
        {
            return Ok(_thereService.DeleteThetre(id));
        }
    }
}
