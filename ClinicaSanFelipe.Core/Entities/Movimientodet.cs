namespace ClinicaSanFelipe.Core.Entities
{
    public partial class Movimientodet
    {
        public int IdMovimientoDet { get; set; }
        public int? IdMovimientoCab { get; set; }
        public int? IdProducto { get; set; }
        public int? Cantidad { get; set; }

        public virtual MovimientoCab? IdMovimientoCabNavigation { get; set; }
        public virtual Producto? IdProductoNavigation { get; set; }
    }
}
