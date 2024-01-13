using Windbnb.WebApi.Models.DTOs.RequestDTOs;
using Microsoft.AspNetCore.Mvc;
using OwnerStore.WebApi.csproj.Services;

namespace Windbnb.WebApi.Controllers
{
    [ApiController]
    [Route("owners")]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        public async Task<IActionResult> Getowners()
        {
            return Ok(await _ownerService.GetOwnersAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetownerById(Guid id)
        {
            return Ok(await _ownerService.GetOwnerByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Addowner(AddOwnerRequest request)
        {
            var addedowner = await _ownerService.AddOwnerAsync(request);
            return CreatedAtAction(nameof(GetownerById), new { id = addedowner.Id }, request);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteowner(Guid id)
        {
            await _ownerService.DeleteOwnerByIdAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateownerById(Guid id, UpdateOwnerRequest request)
        {
            await _ownerService.UpdateOwnerByIdAsync(id, request);
            return NoContent();
        }
    }
}