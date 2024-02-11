using AutoMapper;
using Equitel.DTOs;
using Equitel.Models;
using System.Globalization;

namespace Equitel.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Producto, ProductoDTO>().ReverseMap();
        }
    }
}