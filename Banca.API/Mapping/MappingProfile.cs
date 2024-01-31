using AutoMapper;
using Banca.API.Commands.Compra;
using Banca.API.Commands.Pago;
using Banca.Data.Data.Entities;

namespace Banca.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Compra, EliminarCompraCommand>().ReverseMap(); 
            CreateMap<Pago, EliminarPagoCommand>().ReverseMap(); 
        }
    }
}
