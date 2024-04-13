using AutoMapper;
using ClinicaSanFelipe.Api.Responses;
using ClinicaSanFelipe.Core.DTOs;
using ClinicaSanFelipe.Core.Entities;
using ClinicaSanFelipe.Core.Interfaces.Services;
using ClinicaSanFelipe.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaSanFelipe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ICompraService _compraService;
        private readonly IMapper _mapper;

        public CompraController(ICompraService compraService, IMapper mapper)
        {
            _compraService = compraService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var compras = _compraService.GetAll();
            var comprasDTOs = _mapper.Map<IEnumerable<CompraDTO>>(compras);
            var response = new ApiResponse<IEnumerable<CompraDTO>>(comprasDTOs);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var compra = await _compraService.GetById(id);
            var compraDTO = _mapper.Map<CompraDTO>(compra);
            var reponse = new ApiResponse<CompraDTO>(compraDTO);
            return Ok(reponse);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CompraDTO compraDTO)
        {
            var compra = _mapper.Map<Compra>(compraDTO);

            await _compraService.Add(compra);

            compraDTO = _mapper.Map<CompraDTO>(compra);
            var response = new ApiResponse<CompraDTO>(compraDTO);
            return Ok(response);
        }
    }
}
