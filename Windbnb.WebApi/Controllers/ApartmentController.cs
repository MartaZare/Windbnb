using Windbnb.WebApi.Models.DTOs.RequestDTOs;
using Windbnb.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Windbnb.WebApi.Controllers
{
    [ApiController]
    [Route("apartments")]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetApartments()
        {
            return Ok(await _apartmentService.GetApartments());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetApartmentById(Guid id)
        {
            return Ok(await _apartmentService.GetApartmentById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddApartment([FromBody] AddApartmentRequest request)
        {
            var addedApartment = await _apartmentService.AddApartment(request);
            return CreatedAtAction(nameof(GetApartmentById), new { id = addedApartment.Id }, request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApartmentById(Guid id, [FromBody] UpdateApartmentRequest request)
        {
            await _apartmentService.UpdateApartmentById(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApartmentById(Guid id)
        {
            await _apartmentService.DeleteApartmentById(id);
            return NoContent();
        }

        [HttpPut("{id}/add-to-apartment")]
        public async Task<IActionResult> AddApartmentToApartmentById(Guid id, [FromBody] AddApartmentToOwnerRequest request)
        {
            await _apartmentService.AddApartmentToOwnerByIdAsync(id, request);
            return NoContent();
        }

        [HttpPut("{id}/remove-from-apartment")]
        public async Task<IActionResult> DeleteApartmentFromApartmentById(Guid id)
        {
            //await _apartmentService.DeleteApartmentFromOwnerByIdAsync(id);
            return NoContent();
        }
    }
}