using AutoMapper;
using Estapar.CarStay.Data.Entity;
using Estapar.CarStay.Domain.Interfaces;
using Estapar.CarStay.Domain.Models;
using Estapar.CarStay.Domain.Requets;
using Microsoft.AspNetCore.Mvc;

namespace Estapar.CarStay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassageController : ControllerBase
    {
        private readonly ILogger<PassageController> _logger;
        private readonly IMapper _mapper;
        private readonly IPassageService _passageService;

        public PassageController(ILogger<PassageController> logger,
             IMapper mapper,
             IPassageService passageService)
        {
            _logger = logger;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _passageService = passageService ?? throw new ArgumentNullException(nameof(passageService));
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<PassageDTO>>> GetAll()
        {
            var passages = await _passageService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<PassageDTO>>(passages));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Find(string id)
        {
            var passage = await _passageService.GetByIdAsync(id);
            return Ok(_mapper.Map<PassageDTO>(passage));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PassageCreateDTO passageDTO)
        {
            var passage = _mapper.Map<Passage>(passageDTO);
            await _passageService.CreateAsync(passage);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromBody] PassageDTO passageDTO)
        {
            var passage = _mapper.Map<Passage>(passageDTO);
            await _passageService.UpdateAsync(passage);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _passageService.DeleteAsync(id);
            return Ok();
        }

        [HttpPost("range")]
        public async Task<IActionResult> AddRange(IEnumerable<PassageCreateDTO> passagesDTO)
        {
            var passage = _mapper.Map<IEnumerable<Passage>>(passagesDTO);
            await _passageService.CreateRangeAsync(passage);
            return Ok();
        }

        [HttpGet("saida/{garagem}/{carroPlaca}")]
        public async Task<IActionResult> Saida(string garagem, string carroPlaca)
        {
            var passage = await _passageService.Fechar(garagem, carroPlaca);
            return Ok(_mapper.Map<PassageDTO>(passage));
        }

        [HttpGet("{garagem}/lista-carros")]
        public async Task<IActionResult> ListaCarros(string garagem, [FromQuery] ListCarRequest request)
        {
            var passage = await _passageService.ListaCarros(garagem, request);
            return Ok(passage);
        }

        [HttpGet("{garagem}/fechamento/{dataInicial}/{dataFinal}")]
        public async Task<IActionResult> Fechamento(string garagem, DateTime dataInicial, DateTime dataFinal)
        {
            var passage = await _passageService.Fechamento(garagem, dataInicial, dataFinal);
            return Ok(passage);
        }

        [HttpGet("{garagem}/tempo-medio/{dataInicial}/{dataFinal}")]
        public async Task<IActionResult> TempoMedio(string garagem, DateTime dataInicial, DateTime dataFinal)
        {
            var passage = await _passageService.TempoMedio(garagem, dataInicial, dataFinal);
            return Ok(passage);
        }
    }
}
