using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace StellarShipWeb.Models
{
    public class BusquedaPaquete
    {
        [Required(ErrorMessage = "El campo ID DE RASTREO es requerido")]
        //[StringLength(maximumLength: 18, MinimumLength = 18, ErrorMessage = "La longitud del campo ID debe ser de {2} digitos")]
        [Remote(action: "VerificarExisteTipoCuenta", controller: "Home")]
        public long IdEnvio { get; set; }
        public DateTime Fecha { get; set; }
        public string Estatus { get; set; }
        public string DetallesEstado { get; set; }

    }
}
