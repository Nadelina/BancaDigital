using Banca.API.Commands.TitularTarjeta;
using Banca.API.DTOs;
using Banca.API.Handlers;
using Banca.API.Queries.TitularTarjeta;
using Banca.Data.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Reflection.Metadata;

namespace Banca.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TitularTarjetaController : ControllerBase
    {
        private readonly TitularTarjetaHandler _handler;

        public TitularTarjetaController(TitularTarjetaHandler handler)
        {
            _handler = handler;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TitularTarjeta>> EstadoCuenta(int id)
        {
            var query = new ObtenerTitularTarjetaQuery { TitularTarjetaId = id };
            var estadoCuenta = await _handler.ObtenerEstadoDeCuenta(query);

            if (estadoCuenta == null)
                return NotFound();

            return Ok(estadoCuenta);
        }
        [HttpGet]
        public async Task<ActionResult<TitularTarjeta>> ObtenerListado()
        {
            var titularesTarjeta = await _handler.ObtenerListado();
            return Ok(titularesTarjeta);
        }
        [HttpPost("ExportarEstadoPDF")]
        public ActionResult<TitularTarjeta> ExportarEstadoPDF(EstadoDeCuentaDto estadoDeCuenta)
        {

            var documento = QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);

                    page.Header().ShowOnce().Row(row =>
                    {
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text("ESTADO DE CUENTA").Bold().FontSize(14);
                            col.Item().Text("Tarjeta de credito").Bold().FontSize(14);
                            col.Item().Text("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"));
                            col.Item().Text(" ");
                            col.Item().Text("Titular: " + estadoDeCuenta.NombreTitular);
                            col.Item().Text("Numero de tarjeta: " + estadoDeCuenta.NumeroTarjeta);
                        });
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Background("#257272").Border(1).BorderColor("#257272")
                            .AlignCenter().Text("DETALLES FINANCIEROS");

                            col.Item().Border(1)
                            .BorderColor("#257272")
                            .AlignCenter().Text("Saldo actual: $" + estadoDeCuenta.SaldoActual);

                            col.Item().Border(1).BorderColor("#257272").
                            AlignCenter().Text("Limite credito: $" + estadoDeCuenta.LimiteCredito);

                            col.Item().Border(1).BorderColor("#257272").
                            AlignCenter().Text("Saldo disponible: $" + estadoDeCuenta.SaldoDisponible);
                        });
                    });
                    page.Content().PaddingVertical(10).Column(col1 =>
                    {
                        col1.Item().LineHorizontal(0.5f);
                        col1.Item().Text(" ");

                        col1.Item().Table(tabla2 =>
                        {
                            tabla2.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });
                            tabla2.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                   .Padding(2).Text("Compras del mes anterior: $" + estadoDeCuenta.MontoTotalComprasMesAnterior.ToString()).FontSize(10);
                            tabla2.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                            .Padding(2).Text($"Interes Configurable: {estadoDeCuenta.PorcentajeInteresConfigurable}%").FontSize(10);
                            tabla2.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                            .Padding(2).Text("Compras del mes actual: $" + estadoDeCuenta.MontoTotalComprasMesActual.ToString()).FontSize(10);
                            tabla2.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                            .Padding(2).Text($"Porcentaje configurable de saldo minimo: {estadoDeCuenta.PorcentajeSaldoMinimoConfigurable}%").FontSize(10);


                        });
                        col1.Item().Text(" ");

                        col1.Item().Table(tabla =>
                        {
                            tabla.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn(3);
                                columns.RelativeColumn();
                            });
                            tabla.Header(header =>
                            {
                                header.Cell().Background("#257272")
                                .Padding(2).Text("Fecha").FontColor("#fff");

                                header.Cell().Background("#257272")
                               .Padding(2).Text("Descripcion").FontColor("#fff");

                                header.Cell().Background("#257272")
                               .Padding(2).Text("Monto").FontColor("#fff");
                            });
                            foreach (var item in estadoDeCuenta.ComprasDelMes)
                            {
                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                .Padding(2).Text(item.Fecha.ToShortDateString()).FontSize(10);

                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                .Padding(2).Text(item.Descripcion).FontSize(10);

                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                .Padding(2).Text($"$ {item.Monto}").FontSize(10);
                            }
                        });


                        col1.Item().Text(" ");

                        col1.Item().Table(tabla2 =>
                        {
                            tabla2.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });
                            tabla2.Header(header =>
                            {
                                header.Cell().Background("#257272")
                                .Padding(2).Text("Cuota minima a pagar").FontColor("#fff");

                                header.Cell().Background("#257272")
                               .Padding(2).Text("Pago al contado").FontColor("#fff");

                                header.Cell().Background("#257272")
                               .Padding(2).Text("Pago al contado + intereses").FontColor("#fff");
                            });
                            tabla2.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                   .Padding(2).Text("$" + estadoDeCuenta.CuotaMinimaAPagar.ToString()).FontSize(10);

                            tabla2.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                            .Padding(2).Text("$" + estadoDeCuenta.MontoTotalAPagar.ToString()).FontSize(10);

                            tabla2.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                            .Padding(2).Text($"$ {estadoDeCuenta.PagoContadoConIntereses}").FontSize(10);
                        });
                    });


                    page.Footer().AlignRight().Text(txt =>
                    {
                        txt.Span("Pagina ").FontSize(10);
                        txt.CurrentPageNumber().FontSize(10);
                        txt.Span(" de ").FontSize(10);
                        txt.TotalPages().FontSize(10);
                    });
                });
            }).GeneratePdf();
            return File(documento, "application/pdf", "detalleventa.pdf");
        }

        [HttpPut]
        public async Task<ActionResult<TitularTarjeta>> Actualizar(ActualizarTitularTarjetaCommand command)
        {
            await _handler.Actualizar(command);
            return Ok();
        }
    }
}

