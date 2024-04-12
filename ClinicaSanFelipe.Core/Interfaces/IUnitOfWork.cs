namespace ClinicaSanFelipe.Core.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        ISecurityRepository SecurityRepository { get; }
        IProductoRepository ProductoRepository { get; }
        ICompraCabRepository CompraCabRepository { get; }
        ICompraDetRepository CompraDetRepository { get; }
        IMovimientoCabRepository MovimientoCabRepository { get; }
        IMovimientoDetRepository MovimientoDetRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();

        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
