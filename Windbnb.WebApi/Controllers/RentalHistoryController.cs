using Windbnb.WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Windbnb.WebApi.Controllers
{
    [ApiController]
    [Route("rentals")]
    public class RentalHistoryController : ControllerBase
    {
        private readonly IUserService _userService;

        public RentalHistoryController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> RentApartment(int userId, Guid id)
        {
            await _userService.RentApartment(userId, id);
            return NoContent();
        }
    }
}
