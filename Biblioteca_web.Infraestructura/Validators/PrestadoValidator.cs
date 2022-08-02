using Biblioteca_web.Core.DTOs;
using FluentValidation;
using System;

namespace Biblioteca_web.Infraestructura.Validators
{
    public class PrestadoValidator : AbstractValidator<PrestadoDto>
    {
        
        public PrestadoValidator()
        {
            RuleFor(prestado => prestado.Devuelto)
                .NotNull()
                .Length(2, 2)
                .WithMessage("El develto de contener 2 letra ejm: 'si' o 'no'");

            RuleFor(prestado => prestado.FechaPrestamo)
                .NotNull()
                .Equal(DateTime.Today)
                .WithMessage("Debe de indicar la fecha de hoy"); 
                

            RuleFor(prestado => prestado.FechaDevolucion)
                .NotNull()
                .GreaterThan(x => x.FechaPrestamo.Value)
                        .WithMessage("Fecha de devolucion debe de ser despues de la fecha de prestamo")
                            .When(x => x.FechaPrestamo.HasValue);

            RuleFor(prestado => prestado.IdEstudiante)
                .NotNull()
                .WithMessage("El id del estudiante no puede esta vacio");

            RuleFor(prestado => prestado.IdLibro)
                .NotNull()
                .WithMessage("El id del libro no puede esta vacio");

        }
        
    }
}
