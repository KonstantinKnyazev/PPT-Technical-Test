using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")] commented to adapt to type of call specified in html page
    public class ImageSelectorController : ControllerBase
    {
        private readonly IImageSelectorService _service;

        public ImageSelectorController(IImageSelectorService service)
        {
            _service = service;
        }


        [HttpGet("avatar")]
        public async Task<IActionResult> GetImage([FromQuery] string userIdentifier)

        {
            var url = await _service.GetImageUrlAsync(userIdentifier);          

            return Ok(new { url });
        }
    }
}
