using Banca.API.Commands.Pago;
using FluentValidation;

namespace Banca.API.Validators.Pago
{
    public class CrearPagoCommandValidator : AbstractValidator<CrearPagoCommand>
    {
        public CrearPagoCommandValidator()
        {
            RuleFor(p => p.TitularTarjetaId)
                .NotEmpty().WithMessage("El identificador del titular de la tarjeta es obligatorio.")
                .GreaterThan(0).WithMessage("El identificador del titular de la tarjeta debe ser mayor que 0.");

            RuleFor(p => p.FechaPago)
                .NotEmpty().WithMessage("La fecha de pago es obligatoria.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha de pago no puede ser mayor que la fecha actual.");

            RuleFor(p => p.Monto)
                .NotEmpty().WithMessage("El monto es obligatorio.")
                .GreaterThan(0).WithMessage("El monto debe ser mayor que 0.");
        }
    }
}
