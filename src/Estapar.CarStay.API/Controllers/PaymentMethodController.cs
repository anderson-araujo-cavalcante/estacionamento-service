using AutoMapper;
using Estapar.CarStay.Data.Entity;
using Estapar.CarStay.Domain.Interfaces;
using Estapar.CarStay.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Estapar.CarStay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly ILogger<PaymentMethodController> _logger;
        private readonly IMapper _mapper;
        private readonly IPaymentMethodService _paymentMethodService;

        public PaymentMethodController(ILogger<PaymentMethodController> logger,
            IMapper mapper,
            IPaymentMethodService paymentMethodService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _paymentMethodService = paymentMethodService ?? throw new ArgumentNullException(nameof(paymentMethodService));
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<PaymentMethodDTO>>> GetAll()
        {
            var paymentMethods = await _paymentMethodService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<PaymentMethodDTO>>(paymentMethods));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Find(string id)
        {
            var category = await _paymentMethodService.GetByIdAsync(id);
            return Ok(_mapper.Map<PaymentMethodDTO>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Add(PaymentMethodDTO paymentMethodDTO)
        {
            var paymentMethod = _mapper.Map<PaymentMethod>(paymentMethodDTO);
            await _paymentMethodService.CreateAsync(paymentMethod);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] PaymentMethodDTO paymentMethodDTO)
        {
            var paymentMethod = _mapper.Map<PaymentMethod>(paymentMethodDTO);
            await _paymentMethodService.UpdateAsync(paymentMethod);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _paymentMethodService.DeleteAsync(id);
            return Ok();
        }

        [HttpPost("range")]
        public async Task<IActionResult> AddRange(IEnumerable<PaymentMethodDTO> paymentMethodDTO)
        {
            var paymentMethods = _mapper.Map<IEnumerable<PaymentMethod>>(paymentMethodDTO);
            await _paymentMethodService.CreateRangeAsync(paymentMethods);
            return Ok();
        }
    }
}
