using Dapper;
using StellarShipWeb.Models;
using System.Data.SqlClient;

namespace StellarShipWeb.Servicios
{
    public interface IRepositoryIdGuia
    {
        Task<bool> Existe(long idEnvio);
        Task<BusquedaPaquete> ObtenerGuia(long idEnvio);
    }
    public class RepositoryIdGuia : IRepositoryIdGuia
    {
        private readonly string connectionString;
        public RepositoryIdGuia(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }   

        public async Task<bool> Existe(long idEnvio)
        {
            using  var connection = new SqlConnection(connectionString);
            //var existe = await connection.QueryFirstOrDefaultAsync<int>(@"SELECT 1
            //                                                        FROM TiposCuentas
            //                                                        WHERE Nombre = @Nombre and UsuarioId = @UsuarioId;"
            //                                                        , new { nombre, usuarioId });
            var existe = await connection.QueryFirstOrDefaultAsync<int>(@"SELECT 1
                                                                  FROM DetalleEnvio
                                                                  WHERE IdEnvio=@IdEnvio;", new {idEnvio});

            return existe == 1;
        }

        public async Task<BusquedaPaquete> ObtenerGuia(long idEnvio)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryFirstOrDefaultAsync<BusquedaPaquete>(@"SELECT IdEnvio, Fecha, Estatus , DetallesEstado
                                                                    FROM DetalleEnvio
                                                                    WHERE IdEnvio=@IdEnvio",
                                                                    new { idEnvio});
        }
    }
}
