namespace ClinicaSanFelipe.Core.DTOs
{
    public class VentaCabDTO
    {
        public int IdVentaCab { get; set; }
        public DateTime? FecRegistro { get; set; }
        public double? SubTotal { get; set; }
        public double? Igv { get; set; }
        public double? Total { get; set; }
    }
}
