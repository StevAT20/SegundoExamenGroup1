using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class NacionalidadEntity : DBEntity
    {
        public int? IdNacionalidad { get; set; }
        public string Nombre { get; set; }
    }
}
