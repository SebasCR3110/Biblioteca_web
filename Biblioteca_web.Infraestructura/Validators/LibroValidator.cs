using Biblioteca_web.Core.DTOs;
using FluentValidation;

namespace Biblioteca_web.Infraestructura.Validators
{
    public class LibroValidator : AbstractValidator<LibroDto>
    {
        public LibroValidator()
        {
            RuleFor(libro => libro.TituloLibro)
                .NotNull()
                .Length(4, 40)
                .WithMessage("El Titulo del libro debe contener entre 4 - 40 caracteres");

            RuleFor(libro => libro.AreaLibro)
                .NotNull()
                .Length(4, 20)
                .WithMessage("El SubGenero del libro debe contener entre 4 - 20 caracteres");

            RuleFor(libro => libro.EditorialLibro)
                .NotNull()
                .Length(4, 30)
                .WithMessage("El Editorial del libro debe contener entre 4 - 30 caracteres");
        }
    }
}
