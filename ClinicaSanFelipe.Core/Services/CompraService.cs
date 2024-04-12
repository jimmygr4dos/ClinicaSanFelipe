using ClinicaSanFelipe.Core.Entities;
using ClinicaSanFelipe.Core.Exceptions;
using ClinicaSanFelipe.Core.Interfaces;

namespace ClinicaSanFelipe.Core.Services
{
    public class CompraService : ICompraService
    {
        private readonly IUnitOfWork _unit;
        public CompraService(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<Compra?> GetById(int id)
        {
            var compraCab = await _unit.CompraCabRepository.GetById(id);
            
            if (compraCab == null) return null;
            
            Compra compra = new Compra()
            {
                Cabecera = compraCab,
                Detalle = compraCab.CompraDets.ToList()
            };

            return compra;            
        }

        public List<Compra> GetAll()
        {
            List<Compra> comprasList = new List<Compra>();
            var comprasCab = _unit.CompraCabRepository.GetAll();
            foreach(var item in comprasCab)
            {
                Compra compra = new Compra
                {
                    Cabecera = item,
                    Detalle = item.CompraDets.ToList()
                };
                comprasList.Add(compra);
            }
            return comprasList;
        }

        public async Task Add(Compra compra)
        {
            //Validar que todos los productos existen
            foreach(var detalle in compra.Detalle)
            {
                var producto = await _unit.ProductoRepository.GetById((int)detalle.IdProducto);
                if(producto == null)
                {
                    throw new BusinessException($"No existe el producto con Id: {detalle.IdProducto}");
                }
            }

            await _unit.BeginTransactionAsync();

            try
            {
                await _unit.CompraCabRepository.Add(compra.Cabecera);
                await _unit.SaveChangesAsync();

                var idCompraCabecera = compra.Cabecera.IdCompraCab;

                //Insertar el Movimiento - Cabecera
                MovimientoCab movimientoCab = new MovimientoCab
                {
                    FecRegistro = compra.Cabecera.FecRegistro,
                    IdTipoMovimiento = 1,
                    IdDocumentoOrigen = idCompraCabecera
                };
                await _unit.MovimientoCabRepository.Add(movimientoCab);
                await _unit.SaveChangesAsync();

                var idMovimientoCabecera = movimientoCab.IdMovimientoCab;

                foreach (var detalle in compra.Detalle)
                {
                    detalle.IdCompraCab = idCompraCabecera;
                    await _unit.CompraDetRepository.Add(detalle);
                    await _unit.SaveChangesAsync();

                    //Insertar el Movimiento - Detalle
                    Movimientodet movimientoDet = new Movimientodet
                    {
                        IdMovimientoCab = idMovimientoCabecera,
                        IdProducto = detalle.IdProducto,
                        Cantidad = detalle.Cantidad
                    };
                    await _unit.MovimientoDetRepository.Add(movimientoDet);
                    await _unit.SaveChangesAsync();

                    //Actualizar el costo y el precio de venta (costo * 1.35) en la Tabla Productos
                    var producto = await _unit.ProductoRepository.GetById((int)detalle.IdProducto);
                    if (producto != null)
                    {
                        producto.Costo = detalle.Precio;
                        producto.PrecioVenta = detalle.Precio * 1.35;
                        _unit.ProductoRepository.Update(producto);
                        await _unit.SaveChangesAsync();
                    }
                }

                await _unit.CommitAsync();
            }
            catch (Exception)
            {
                await _unit.RollbackAsync();
                throw;
            }
        }

        public Task<bool> Update(Compra compra)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
