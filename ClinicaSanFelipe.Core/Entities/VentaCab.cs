namespace ClinicaSanFelipe.Core.Entities
{
    public partial class VentaCab
    {
        public VentaCab()
        {
            VentaDets = new HashSet<VentaDet>();
        }

        public int IdVentaCab { get; set; }
        public DateTime? FecRegistro { get; set; }
        public double? SubTotal { get; set; }
        public double? Igv { get; set; }
        public double? Total { get; set; }

        public virtual ICollection<VentaDet> VentaDets { get; set; }
    }
}
