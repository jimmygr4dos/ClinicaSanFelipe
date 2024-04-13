using ClinicaSanFelipe.Core.Entities;
using ClinicaSanFelipe.Core.Exceptions;
using ClinicaSanFelipe.Core.Interfaces.Repositories;
using ClinicaSanFelipe.Core.Interfaces.Services;

namespace ClinicaSanFelipe.Core.Services
{
    public class VentaService : IVentaService
    {
        private readonly IUnitOfWork _unit;

        public VentaService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<Venta?> GetById(int id)
        {
            var ventaCab = await _unit.VentaCabRepository.GetById(id);

            if (ventaCab == null)
            {
                throw new BusinessException($"No existe la venta con Id: {id}");
            }

            Venta venta = new Venta
            {
                Cabecera = ventaCab,
                Detalle = ventaCab.VentaDets.ToList()
            };
            return venta;
        }

        public List<Venta> GetAll()
        {
            List<Venta> ventas = new List<Venta>();
            var ventaCab = _unit.VentaCabRepository.GetAll();
            foreach(var item in ventaCab)
            {
                Venta venta = new Venta
                {
                    Cabecera = item,
                    Detalle = item.VentaDets.ToList()
                };
                ventas.Add(venta);
            }
            return ventas;
        }

        public async Task Add(Venta venta)
        {
            //Validar que todos los productos existen

            //Validar el stock de los productos según Tablas Movimientos

            await _unit.BeginTransactionAsync();

            try
            {
                var idVenta = await GetIdVenta(venta.Cabecera);
                DateTime? fecRegistro = venta.Cabecera.FecRegistro;

                var idMovimiento = await GetIdMovimiento(fecRegistro, idVenta);

                await AddVentaDetalle(venta.Detalle, idVenta, idMovimiento);

                await _unit.CommitAsync();
            }
            catch (Exception)
            {
                await _unit.RollbackAsync();
                throw;
            }
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Venta venta)
        {
            throw new NotImplementedException();
        }

        private async Task<int> GetIdVenta(VentaCab cabecera)
        {
            await _unit.VentaCabRepository.Add(cabecera);
            await _unit.SaveChangesAsync();
            return cabecera.IdVentaCab;
        }

        private async Task<int> GetIdMovimiento(DateTime? fecRegistro, int idVenta)
        {
            MovimientoCab movimientoCab = new MovimientoCab
            {
                FecRegistro = fecRegistro,
                IdTipoMovimiento = 2,
                IdDocumentoOrigen = idVenta
            };
            await _unit.MovimientoCabRepository.Add(movimientoCab);
            await _unit.SaveChangesAsync();
            return movimientoCab.IdMovimientoCab;
        }

        private async Task AddVentaDetalle(List<VentaDet> detalle, int idVenta, int idMovimiento)
        {
            foreach (var item in detalle)
            {
                item.IdVentaCab = idVenta;
                await _unit.VentaDetRepository.Add(item);
                await _unit.SaveChangesAsync();

                await AddMovimientoDetalle(idMovimiento, item.IdProducto, item.Cantidad);
            }

        }

        private async Task AddMovimientoDetalle(int idMovimiento, int? idProducto, int? cantidad)
        {
            Movimientodet movimientoDet = new Movimientodet
            {
                IdMovimientoCab = idMovimiento,
                IdProducto = idProducto,
                Cantidad = cantidad
            };
            await _unit.MovimientoDetRepository.Add(movimientoDet);
            await _unit.SaveChangesAsync();
        }
    }
}
