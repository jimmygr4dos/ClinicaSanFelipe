namespace ClinicaSanFelipe.Core.Entities
{
    public partial class VentaDet
    {
        public int IdVentaDet { get; set; }
        public int? IdVentaCab { get; set; }
        public int? IdProducto { get; set; }
        public int? Cantidad { get; set; }
        public double? Precio { get; set; }
        public double? SubTotal { get; set; }
        public double? Igv { get; set; }
        public double? Total { get; set; }

        public virtual Producto? IdProductoNavigation { get; set; }
        public virtual VentaCab? IdVentaCabNavigation { get; set; }
    }
}
