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
                // Guardar los cambios en la base de datos
                await context.SaveChangesAsync();
            }
        }
    }
}
