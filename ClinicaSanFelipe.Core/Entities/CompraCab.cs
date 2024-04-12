namespace ClinicaSanFelipe.Core.Entities
{
    public partial class CompraCab
    {
        public CompraCab()
        {
            CompraDets = new HashSet<CompraDet>();
        }

        public int IdCompraCab { get; set; }
        public DateTime? FecRegistro { get; set; }
        public double? SubTotal { get; set; }
        public double? Igv { get; set; }
        public double? Total { get; set; }

        public virtual ICollection<CompraDet> CompraDets { get; set; }
    }
}
