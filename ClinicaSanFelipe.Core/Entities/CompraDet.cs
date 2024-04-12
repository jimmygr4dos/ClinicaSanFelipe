namespace ClinicaSanFelipe.Core.Entities
{
    public partial class CompraDet
    {
        public int IdCompraDet { get; set; }
        public int? IdCompraCab { get; set; }
        public int? IdProducto { get; set; }
        public int? Cantidad { get; set; }
        public double? Precio { get; set; }
        public double? SubTotal { get; set; }
        public double? Igv { get; set; }
        public double? Total { get; set; }

        public virtual CompraCab? IdCompraCabNavigation { get; set; }
        public virtual Producto? IdProductoNavigation { get; set; }
    }
}
