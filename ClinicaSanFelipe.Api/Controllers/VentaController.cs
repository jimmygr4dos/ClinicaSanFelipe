using AutoMapper;
using ClinicaSanFelipe.Api.Responses;
using ClinicaSanFelipe.Core.DTOs;
using ClinicaSanFelipe.Core.Entities;
using ClinicaSanFelipe.Core.Interfaces.Services;
using ClinicaSanFelipe.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaSanFelipe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaService _ventaService;
        private readonly IMapper _mapper;

        public VentaController(IVentaService ventaService, IMapper mapper)
        {
            _ventaService = ventaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var ventas = _ventaService.GetAll();
            var ventasDTOs = _mapper.Map<IEnumerable<VentaDTO>>(ventas);
            var response = new ApiResponse<IEnumerable<VentaDTO>>(ventasDTOs);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var venta = await _ventaService.GetById(id);
            var ventaDTO = _mapper.Map<VentaDTO>(venta);
            var reponse = new ApiResponse<VentaDTO>(ventaDTO);
            return Ok(reponse);
        }

        [HttpPost]
        public async Task<IActionResult> Add(VentaDTO ventaDTO)
        {
            var venta = _mapper.Map<Venta>(ventaDTO);

            await _ventaService.Add(venta);

            ventaDTO = _mapper.Map<VentaDTO>(venta);
            var response = new ApiResponse<VentaDTO>(ventaDTO);
            return Ok(response);
        }
    }
}
