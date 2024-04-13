namespace ClinicaSanFelipe.Core.Entities
{
    public class Venta
    {
        public VentaCab Cabecera { get; set; }
        public List<VentaDet> Detalle { get; set; }
    }
}
