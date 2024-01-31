using Banca.API.Commands.TitularTarjeta;
using FluentValidation;

namespace Banca.API.Validators.TitularTarjeta
{
    public class ActualizarTitularTarjetaCommandValidator : AbstractValidator<ActualizarTitularTarjetaCommand>
    {
        public ActualizarTitularTarjetaCommandValidator()
        {
            RuleFor(x => x.TitularTarjetaId)
                .GreaterThan(0).WithMessage("El ID del titular de la tarjeta debe ser mayor que cero.");

            RuleFor(x => x.NombreTitular)
                .NotEmpty().WithMessage("El nombre del titular es obligatorio.")
                .Length(2, 100).WithMessage("El nombre del titular debe tener entre 2 y 100 caracteres.");
                
            RuleFor(x => x.NumeroTarjeta)
                .NotEmpty().WithMessage("El número de tarjeta es obligatorio.")
                .CreditCard().WithMessage("El número de tarjeta no es válido.")
                .Length(16).WithMessage("El número de tarjeta debe tener 16 dígitos.");
        }
    }
}
