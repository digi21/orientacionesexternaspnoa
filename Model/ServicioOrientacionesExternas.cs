using System;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace pnoa.Model
{
    public class ServicioOrientacionesExternas : IServicioOrientacionesExternas
    {
        private readonly IConfiguration _configuration;
        public ServicioOrientacionesExternas(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<OrientacionExterna> ObtenOrientacionAsync(string foto)
        {
            var cadenaConexion = _configuration["ConnectionStrings:sqlConnection"];
            using var conexion = new SqliteConnection(cadenaConexion);
            await conexion.OpenAsync();
            var command = new SqliteCommand($"SELECT XL, YL, ZL, OM, PHI, K FROM [Orientación_Exterior] WHERE N_FOTO_TIF='{foto}'", conexion);
            var reader = await command.ExecuteReaderAsync();

            if( !reader.HasRows )
                throw new Exception($"No se localizó la orientación para la imagen {foto}");

            await reader.ReadAsync();

            return new OrientacionExterna
            {
                X = reader.GetDouble(0),
                Y = reader.GetDouble(1),
                Z = reader.GetDouble(2),
                Omega = reader.GetDouble(3),
                Phi = reader.GetDouble(4),
                Kappa = reader.GetDouble(5)
            };
        }
    }
}