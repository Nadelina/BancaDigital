using Banca.Data.Data.Entities;

namespace Banca.Data.Data
{
    public class SeedDb
    {
        private readonly ApplicationDbContext context;

        public SeedDb(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task SeedAsync()
        {
            await context.Database.EnsureCreatedAsync();

            // Verificar si ya existen datos
            if (!context.TitularesTarjeta.Any())
            {
                // Crear un nuevo titular de tarjeta
                var titularTarjeta = new TitularTarjeta
                {
                    NombreTitular = "Nathaly Gutierrez",
                    NumeroTarjeta = "4096309916145537",
                    SaldoActual = 114.47m,
                    LimiteCredito = 1000
                };

                // Agregar el titular a la base de datos
                context.TitularesTarjeta.Add(titularTarjeta);

                // Crear compras asociadas
                var compra1 = new Compra
                {
                    TitularTarjeta = titularTarjeta, // Asociar con el titular
                    Fecha = DateTime.Now,
                    Descripcion = "Compra en Supermercado",
                    Monto = 150
                };

                var compra2 = new Compra
                {
                    TitularTarjeta = titularTarjeta, // Asociar con el titular
                    Fecha = DateTime.Now,
                    Descripcion = "Compra en Tienda de Ropa",
                    Monto = 200
                };

                // Agregar las compras a la base de datos
                context.Compras.AddRange(compra1, compra2);

                // Guardar los cambios en la base de datos
                await context.SaveChangesAsync();
            }
        }
    }
}
