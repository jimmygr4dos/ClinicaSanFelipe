namespace ClinicaSanFelipe.Core.Entities
{
    public partial class MovimientoCab
    {
        public MovimientoCab()
        {
            Movimientodets = new HashSet<Movimientodet>();
        }

        public int IdMovimientoCab { get; set; }
        public DateTime? FecRegistro { get; set; }
        public int? IdTipoMovimiento { get; set; }
        public int? IdDocumentoOrigen { get; set; }

        public virtual ICollection<Movimientodet> Movimientodets { get; set; }
    }
}
