namespace ClinicaSanFelipe.Core.DTOs
{
    public class VentaDetDTO
    {
        public int IdVentaDet { get; set; }
        public int? IdVentaCab { get; set; }
        public int? IdProducto { get; set; }
        public int? Cantidad { get; set; }
        public double? Precio { get; set; }
        public double? SubTotal { get; set; }
        public double? Igv { get; set; }
        public double? Total { get; set; }
    }
}
