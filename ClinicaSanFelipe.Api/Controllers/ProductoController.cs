using AutoMapper;
using ClinicaSanFelipe.Api.Responses;
using ClinicaSanFelipe.Core.CustomEntities;
using ClinicaSanFelipe.Core.DTOs;
using ClinicaSanFelipe.Core.Entities;
using ClinicaSanFelipe.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ClinicaSanFelipe.Api.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;
        private readonly IMapper _mapper;
        public ProductoController(IProductoService productoService, IMapper mapper)
        {
            _productoService = productoService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] int PageSize, int PageNumber) 
        {
            var productos = _productoService.GetAll(PageSize, PageNumber);
            var productosDTOs = _mapper.Map<IEnumerable<ProductoDTO>>(productos);
            var metadata = new Metadata
            {
                TotalCount = productos.TotalCount,
                PageSize = productos.PageSize,
                CurrentPage = productos.CurrentPage,
                TotalPages = productos.TotalPages,
                HasPreviousPage = productos.HasPreviousPage,
                HasNextPage = productos.HasNextPage,
            };

            var response = new ApiResponse<IEnumerable<ProductoDTO>>(productosDTOs)
            {
                Meta = metadata
            };
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var producto = await _productoService.GetById(id);
            var productoDTO = _mapper.Map<ProductoDTO>(producto);
            var reponse = new ApiResponse<ProductoDTO>(productoDTO);
            return Ok(reponse);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductoDTO productoDTO)
        {
            var producto = _mapper.Map<Producto>(productoDTO);

            await _productoService.Add(producto);

            productoDTO = _mapper.Map<ProductoDTO>(producto);
            var response = new ApiResponse<ProductoDTO>(productoDTO);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, ProductoDTO productoDTO)
        {
            var producto = _mapper.Map<Producto>(productoDTO);
            producto.IdProducto = id;

            var result = await _productoService.Update(producto);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productoService.Delete(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
