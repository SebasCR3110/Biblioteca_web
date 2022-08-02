using Biblioteca_web.Core.DTOs;
using FluentValidation;

namespace Biblioteca_web.Infraestructura.Validators
{
    public class EstudianteValidator : AbstractValidator<EstudianteDto>
    {
        public EstudianteValidator()
        {
            RuleFor(estudiante => estudiante.CedulaIdentidad)
                .NotNull()
                .Length(11, 11)
                .WithMessage("La cedula de identidad debe contener entre 11 caracteres"); 

            RuleFor(estudiante => estudiante.NombreEstudiante)
                .NotNull()
                .Length(4, 60)
                .WithMessage("Nombre del estudiante debe contener entre 4 - 60 caracteres"); 

            RuleFor(estudiante => estudiante.CarreraEstudiante)
                .NotNull()
                .Length(4, 60)
                .WithMessage("carrera del estudiante debe contener entre 4 - 60 caracteres"); 

            RuleFor(estudiante => estudiante.DireccionEstudiante)
                .NotNull()
                .Length(4, 80)
                .WithMessage("La direccion de estudiante debe contener entre 4 - 80 caracteres"); 

            RuleFor(estudiante => estudiante.EdadEstudiante)
                .NotNull()
                .WithMessage("La edad del estudiante esta vacia");
        }
    }
}
