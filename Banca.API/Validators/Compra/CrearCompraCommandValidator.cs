using Banca.API.Commands.Compra;
using FluentValidation;

namespace Banca.API.Validators.Compra
{
    public class CrearCompraCommandValidator : AbstractValidator<CrearCompraCommand>
    {
        public CrearCompraCommandValidator()
        {
            RuleFor(x => x.TitularTarjetaId).NotEmpty().WithMessage("El ID del titular de la tarjeta es obligatorio.");
            RuleFor(x => x.Fecha).NotEmpty().WithMessage("La fecha de la compra es obligatoria.");
            RuleFor(x => x.Descripcion).NotEmpty().WithMessage("La descripción de la compra es obligatoria.");
            RuleFor(x => x.Monto).GreaterThan(0).WithMessage("El monto de la compra debe ser mayor que cero.");
        }
    }
}
