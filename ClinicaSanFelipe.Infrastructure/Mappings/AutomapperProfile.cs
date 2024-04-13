using AutoMapper;
using ClinicaSanFelipe.Core.DTOs;
using ClinicaSanFelipe.Core.Entities;

namespace ClinicaSanFelipe.Infrastructure.Mappings
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile() 
        {
            CreateMap<Producto, ProductoDTO>().ReverseMap();
            CreateMap<CompraCab, CompraCabDTO>().ReverseMap();
            CreateMap<CompraDet, CompraDetDTO>().ReverseMap();
            CreateMap<Compra, CompraDTO>().ReverseMap();
            CreateMap<VentaCab, VentaCabDTO>().ReverseMap();
            CreateMap<VentaDet, VentaDetDTO>().ReverseMap();
            CreateMap<Venta, VentaDTO>().ReverseMap();
            CreateMap<Security, SecurityDTO>().ReverseMap();
        }
    }
}
