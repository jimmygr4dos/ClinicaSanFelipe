using ClinicaSanFelipe.Core.Interfaces.Repositories;
using ClinicaSanFelipe.Infrastructure.Data;

namespace ClinicaSanFelipe.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClinicaSanFelipeContext _context;
        private readonly SecurityRepository _securityRepository;
        private readonly ProductoRepository _productoRepository;
        private readonly CompraCabRepository _compraCabRepository;
        private readonly CompraDetRepository _compraDetRepository;
        private readonly VentaCabRepository _ventaCabRepository;
        private readonly VentaDetRepository _ventaDetRepository;
        private readonly MovimientoCabRepository _movimientoCabRepository;
        private readonly MovimientoDetRepository _movimientoDetRepository;

        public UnitOfWork(ClinicaSanFelipeContext context)
        {
            _context = context;
        }
        public ISecurityRepository SecurityRepository => _securityRepository ?? new SecurityRepository(_context);
        public IProductoRepository ProductoRepository => _productoRepository ?? new ProductoRepository(_context);
        public ICompraCabRepository CompraCabRepository => _compraCabRepository ?? new CompraCabRepository(_context);
        public ICompraDetRepository CompraDetRepository => _compraDetRepository ?? new CompraDetRepository(_context);
        public IVentaCabRepository VentaCabRepository => _ventaCabRepository ?? new VentaCabRepository(_context);
        public IVentaDetRepository VentaDetRepository => _ventaDetRepository ?? new VentaDetRepository(_context);
        public IMovimientoCabRepository MovimientoCabRepository => _movimientoCabRepository ?? new MovimientoCabRepository(_context);
        public IMovimientoDetRepository MovimientoDetRepository => _movimientoDetRepository ?? new MovimientoDetRepository(_context);

        public void Dispose()
        {
            if(_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _context.Database.CurrentTransaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            await _context.Database.CurrentTransaction.RollbackAsync();
        }
    }
}
