namespace ClinicaSanFelipe.Core.DTOs
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }
        public string? NombreProducto { get; set; }
        public string? NroLote { get; set; }
        public DateTime? FecRegistro { get; set; }
        public double? Costo { get; set; }
        public double? PrecioVenta { get; set; }
        public string? Moneda { get; set; }
    }
}
