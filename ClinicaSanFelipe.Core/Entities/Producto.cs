namespace ClinicaSanFelipe.Core.Entities
{
    public partial class Producto
    {
        public Producto()
        {
            CompraDets = new HashSet<CompraDet>();
            Movimientodets = new HashSet<Movimientodet>();
            VentaDets = new HashSet<VentaDet>();
        }

        public int IdProducto { get; set; }
        public string? NombreProducto { get; set; }
        public string? NroLote { get; set; }
        public DateTime? FecRegistro { get; set; }
        public double? Costo { get; set; }
        public double? PrecioVenta { get; set; }
        public string? Moneda { get; set; }

        public virtual ICollection<CompraDet> CompraDets { get; set; }
        public virtual ICollection<Movimientodet> Movimientodets { get; set; }
        public virtual ICollection<VentaDet> VentaDets { get; set; }
    }
}
