namespace ClinicaSanFelipe.Core.DTOs
{
    public class CompraCabDTO
    {
        public int IdCompraCab { get; set; }
        public DateTime? FecRegistro { get; set; }
        public double? SubTotal { get; set; }
        public double? Igv { get; set; }
        public double? Total { get; set; }
    }
}
