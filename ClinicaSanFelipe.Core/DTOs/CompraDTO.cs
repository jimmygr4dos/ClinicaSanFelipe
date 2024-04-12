namespace ClinicaSanFelipe.Core.DTOs
{
    public class CompraDTO
    {
        public CompraCabDTO Cabecera { get; set; }
        public List<CompraDetDTO> Detalle { get; set; }
    }
}
