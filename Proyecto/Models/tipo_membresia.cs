using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Models
{
    internal class tipo_membresia
    {
        public int id_tipo_membresia { get; set; }
        public string descripcion { get; set; }
        

        public string toJson()
        {

            return "{\"descripcion\":\"" + descripcion + " \" }";
        }
    }
}
