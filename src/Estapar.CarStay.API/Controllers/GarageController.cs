using AutoMapper;
using Estapar.CarStay.Data.Entity;
using Estapar.CarStay.Domain.Interfaces;
using Estapar.CarStay.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Estapar.CarStay.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GarageController : ControllerBase
    {
        private readonly ILogger<GarageController> _logger;
        private readonly IMapper _mapper;
        private readonly IGarageService _garageService;

        public GarageController(ILogger<GarageController> logger,
             IMapper mapper,
             IGarageService garageService)
        {
            _logger = logger;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _garageService = garageService ?? throw new ArgumentNullException(nameof(garageService));
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<GarageDTO>>> GetAll()
        {
            var garages = await _garageService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<GarageDTO>>(garages));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Find(string id)
        {
            var garage = await _garageService.GetByIdAsync(id);
            return Ok(_mapper.Map<GarageDTO>(garage));
        }

        [HttpPost]
        public async Task<IActionResult> Add(GarageDTO garageDTO)
        {
            var garage = _mapper.Map<Garage>(garageDTO);
            await _garageService.CreateAsync(garage);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] GarageDTO garageDTO)
        {
            var garage = _mapper.Map<Garage>(garageDTO);
            await _garageService.UpdateAsync(garage);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _garageService.DeleteAsync(id);
            return Ok();
        }

        [HttpPost("range")]
        public async Task<IActionResult> AddRange(IEnumerable<GarageDTO> garageDTO)
        {
            var garages = _mapper.Map<IEnumerable<Garage>>(garageDTO);
            await _garageService.CreateRangeAsync(garages);
            return Ok();
        }
    }
}
