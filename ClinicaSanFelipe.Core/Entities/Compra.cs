namespace ClinicaSanFelipe.Core.Entities
{
    public class Compra
    {
        public CompraCab Cabecera { get; set; }
        public List<CompraDet> Detalle { get; set; }
    }
}
