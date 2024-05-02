using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListadoEmpresas.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Razon { get; set; } = String.Empty;
        public required string NombreEmpresa { get; set; }
        public long IdentificacionFiscal { get; set; }
        public long NumeroTelefono { get; set; }
        public string CorreoElectronico { get; set; } = String.Empty;
        public string SitioWeb { get; set; } = String.Empty;
        public string Direccion { get; set; } = String.Empty;
        public string Pais { get; set; } = String.Empty;
        public long Facturacion { get; set; } 
        public DateTime FechaEdicion { get; set; }
    }
}