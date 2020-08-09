using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Agl.WebApi.Domain.Models;
using Agl.WebApi.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Agl.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private const string endPoint = "Endpoint";
        private readonly IPetsOwnerService _petService;
        private readonly ILogger<PetsController> _logger;
        private readonly IConfiguration _configuration;
        public PetsController(ILogger<PetsController> logger, IPetsOwnerService petService,IConfiguration configuration)
        {
            _logger = logger;
            _petService = petService;
            _configuration = configuration;
        }
        /// <summary>
        /// List of pets in alphabetical order grouped by gender of their owner.
        /// </summary>
        /// <param name="petType">Enter the type of pet</param>
        /// <returns>Returns list of pets in alphabetical order grouped by gender of their owner</returns>
        [HttpGet("{petType:alpha}", Name = "GetPetsByByOwnerGender")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PetsByOwnerGender>))]
        public async Task<IActionResult> Get(string petType)
        {
            if (string.IsNullOrWhiteSpace(petType)) return BadRequest();
            
            try
            {
                var endpoint = _configuration.GetSection(endPoint).Value;

                var petsGroupedByOwnerGender = await _petService.GetPetsByOwnerGenderAsync(endpoint, petType);

                if (petsGroupedByOwnerGender == null) return NotFound();

                return Ok(petsGroupedByOwnerGender);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Controller: {nameof(PetsController)}, Method: Get, ErrorMessage: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "InternalServerError");
            }
        }
    }
}
