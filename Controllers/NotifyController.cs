using Buisness_Layer.DTOs;
using Buisness_Layer.Services.NotifyService;
using Core.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifyController : ControllerBase
    {
        private readonly INotifyService _notifyService;
      

        public NotifyController(INotifyService notifyService)
        {
            _notifyService = notifyService;
          
        }
        [HttpPost]
        public async Task<IActionResult> Notify([FromBody] DustbinDetails dustbinDetails)
        {

            var notified =await _notifyService.Notify(dustbinDetails.FillLevel, dustbinDetails.DustbinNumber, dustbinDetails.Address);
            if (string.IsNullOrEmpty(notified))
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
