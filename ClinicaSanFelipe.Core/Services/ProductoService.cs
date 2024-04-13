using ClinicaSanFelipe.Core.CustomEntities;
using ClinicaSanFelipe.Core.Entities;
using ClinicaSanFelipe.Core.Interfaces.Repositories;
using ClinicaSanFelipe.Core.Interfaces.Services;
using Microsoft.Extensions.Options;

namespace ClinicaSanFelipe.Core.Services
{
    public class ProductoService : IProductoService
    {
        private readonly PaginationOptions _paginationOptions;
        private readonly IUnitOfWork _unit;

        public ProductoService(IUnitOfWork unit, IOptions<PaginationOptions> options)
        {
            _unit = unit;
            _paginationOptions = options.Value;
        }

        public async Task<Producto> GetById(int id)
        {
            return await _unit.ProductoRepository.GetById(id);
        }

        public PagedList<Producto> GetAll(int PageSize, int PageNumber)
        {
            PageSize = PageSize == 0 ? _paginationOptions.DefaultPageSize : PageSize;
            PageNumber = PageNumber == 0 ? _paginationOptions.DefaultPageNumber : PageNumber;

            var productos = _unit.ProductoRepository.GetAll();

            var pagedProductos = PagedList<Producto>.Create(productos, PageNumber, PageSize);

            return pagedProductos;
        }

        public async Task Add(Producto producto)
        {
            await _unit.ProductoRepository.Add(producto);
            await _unit.SaveChangesAsync();
        }

        public async Task<bool> Update(Producto producto)
        {
            _unit.ProductoRepository.Update(producto);
            await _unit.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _unit.ProductoRepository.Delete(id);
            await _unit.SaveChangesAsync();
            return true;
        }
    }
}
