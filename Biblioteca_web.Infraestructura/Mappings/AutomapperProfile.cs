using AutoMapper;
using Biblioteca_web.Core.DTOs;
using Biblioteca_web.Core.Entities;

namespace Biblioteca_web.Infraestructura.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Prestados, PrestadoDto>();
            CreateMap<PrestadoDto, Prestados>();

            CreateMap<Estudiantes, EstudianteDto>();
            CreateMap<EstudianteDto, Estudiantes>();

            CreateMap<Libros, LibroDto>();
            CreateMap<LibroDto, Libros>();

            CreateMap<Seguridad, SeguridadDto>().ReverseMap();
        }
    }
}
