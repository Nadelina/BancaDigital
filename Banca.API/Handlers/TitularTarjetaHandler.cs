using Banca.API.Commands.TitularTarjeta;
using Banca.API.DTOs;
using Banca.API.Queries.TitularTarjeta;
using Banca.Data.Data.Entities;
using Banca.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Banca.API.Handlers
{
    public class TitularTarjetaHandler
    {
        private readonly ITitularTarjetaRepository _titularTarjetaRepository;
        private readonly CompraHandler _compraHandler;
        private readonly PagoHandler _pagoHandler;
        public TitularTarjetaHandler(ITitularTarjetaRepository titularTarjetaRepository,
            CompraHandler compraHandler, PagoHandler pagoHandler)
        {
            _titularTarjetaRepository = titularTarjetaRepository;
            _compraHandler = compraHandler;
            _pagoHandler = pagoHandler;
        }

        public async Task<TitularTarjeta> ObtenerPorId(ObtenerTitularTarjetaQuery query)
        {
            return await _titularTarjetaRepository.ObtenerPorIdAsync(query.TitularTarjetaId);
        }
        public async Task<List<TitularTarjeta>> ObtenerListado()
        {
            return  await _titularTarjetaRepository.GetAll().ToListAsync();
        }

        public async Task Actualizar(ActualizarTitularTarjetaCommand command)
        {
            TitularTarjeta titularTarjeta = await _titularTarjetaRepository.ObtenerPorIdAsync(command.TitularTarjetaId);

            titularTarjeta.NumeroTarjeta = command.NumeroTarjeta;
            titularTarjeta.NombreTitular = command.NombreTitular;
            titularTarjeta.SaldoActual = command.SaldoActual;
            titularTarjeta.PorcentajeInteresConfigurable = command.PorcentajeInteresConfigurable;
            titularTarjeta.PorcentajeSaldoMinimoConfigurable = command.PorcentajeSaldoMinimoConfigurable;
            await _titularTarjetaRepository.UpdateAsync(titularTarjeta);
        }

        public async Task<EstadoDeCuentaDto> ObtenerEstadoDeCuenta(ObtenerTitularTarjetaQuery query)
        {
            var titularTarjeta = await _titularTarjetaRepository.ObtenerPorIdAsync(query.TitularTarjetaId);


            var compras = await _compraHandler.ComprasPorTitularIdAsync(new()
            {
                TitularTarjetaId = query.TitularTarjetaId,
            });
            var pagos = await _pagoHandler.PagosPorTitularIdAsync(new()
            {
                TitularTarjetaId = query.TitularTarjetaId,
            });

            var comprasDelMes = compras.Where(c => c.Fecha.Month == DateTime.Now.Month && c.Fecha.Year == DateTime.Now.Year).ToList();
            var comprasMesAnterior = compras.Where(c => c.Fecha.Month == DateTime.Now.AddMonths(-1).Month && c.Fecha.Year == DateTime.Now.Year).ToList();


            return new EstadoDeCuentaDto
            {
                TitularTarjetaId = titularTarjeta.TitularTarjetaId,
                NombreTitular = titularTarjeta.NombreTitular,
                NumeroTarjeta = titularTarjeta.NumeroTarjeta,
                SaldoActual = titularTarjeta.SaldoActual,
                LimiteCredito = titularTarjeta.LimiteCredito,
                ComprasDelMes = comprasDelMes.Select(compra => new CompraDto
                {
                    Fecha = compra.Fecha,
                    Descripcion = compra.Descripcion,
                    Monto = compra.Monto
                }).ToList(),
                Pagos = pagos.Select(pago => new PagoDto
                {
                    FechaPago = pago.FechaPago,
                    Monto = pago.Monto
                }).ToList(),
                MontoTotalComprasMesActual = comprasDelMes.Sum(c => c.Monto),
                MontoTotalComprasMesAnterior = comprasMesAnterior.Sum(c => c.Monto),
                PorcentajeInteresConfigurable = titularTarjeta.PorcentajeInteresConfigurable,
                PorcentajeSaldoMinimoConfigurable = titularTarjeta.PorcentajeSaldoMinimoConfigurable
            };
        }
    }

}
