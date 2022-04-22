using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ClienteEntity : DBEntity
    {
        public ClienteEntity()
        {
            N_Nacionalidad = N_Nacionalidad ?? new NacionalidadEntity();
            TipoClienteNombre = TipoClienteNombre ?? new TipoClienteEntity();
        }

        public int? IdCliente { get; set; }
        public int? IdNacionalidad { get; set; }
        public virtual NacionalidadEntity N_Nacionalidad { get; set; }
        public string Identificacion { get; set; }
        public int? IdTipoIdentificacion { get; set; }
        public virtual TipoClienteEntity TipoClienteNombre { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; } = DateTime.Now;        
        public DateTime FechaDefuncion { get; set; } = DateTime.Now;
        public char Genero { get; set; }
        public string NombreApellidosPadre { get; set; }
        public string NombreApellidosMadre { get; set; }
        public string Pasaporte { get; set; }
        public string CuentaIBAN { get; set; }
        public string CorreoNotifica { get; set; }
    }
}
