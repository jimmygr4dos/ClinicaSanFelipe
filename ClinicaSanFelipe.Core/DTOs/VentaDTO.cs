namespace ClinicaSanFelipe.Core.DTOs
{
    public class VentaDTO
    {
        public VentaCabDTO Cabecera {  get; set; }
        public List<VentaDetDTO> Detalle {  get; set; }
    }
}
