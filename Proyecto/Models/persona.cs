using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Models
{
    internal class persona
    {
        public int id_membresia { get; set; }
        public string nombre_persona { get; set; }
        public string correo_electronico { get; set; }
        public string id_tipo_membresia { get; set; }
        

        public string toJson()
        {

            return "{\"nombre_persona\":\"" + nombre_persona + " \",\"correo_electronico\": \"" + correo_electronico + "\" , \"id_tipo_membresia\":\"" + id_tipo_membresia + "\" }";
        }
    }
}
