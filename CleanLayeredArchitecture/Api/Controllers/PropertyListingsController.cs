using Api.Contracts.Requests;
using Api.Contracts.Responses;
using Application.Dtos;
using Application.Services;
using Commmon.Result;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyListingsController : ControllerBase
    {
        private readonly PropertyListingService _service;

        public PropertyListingsController(PropertyListingService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();

            if (!result.Success) return NotFound();

            var responses = result.Value.Select(listing => new PropertyListingResponse(
                listing.Id,
                listing.Title,
                listing.Description,
                listing.Price));

            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (!result.Success) return NotFound();

            var response = new PropertyListingResponse(
                result.Value.Id,
                result.Value.Title,
                result.Value.Description,
                result.Value.Price);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PropertyListingRequest request)
        {
            var result = await _service.AddAsync(
                new PropertyListingDto(null, request.Title, request.Description, request.Price));

            if (!result.Success) return BadRequest(result.Error);
            

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PropertyListingRequest request)
        {
            var result = await _service.UpdateAsync(
                new PropertyListingDto(id, request.Title, request.Description, request.Price));

            if (!result.Success) return BadRequest(result.Error);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result.Success) return BadRequest(result.Error);

            return Ok();
        }
    }

}
