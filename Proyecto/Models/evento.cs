using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Models
{
    internal class evento
    {
        public int id_evento { get; set; }
        public string nombre_evento { get; set; }
        public string fecha { get; set; }
        public string id_tipo_evento { get; set; }


        public string toJson()
        {

            return "{\"nombre_evento\":\"" + nombre_evento + " \",\"fecha\": \"" + fecha + "\" , \"id_tipo_evento\":\"" + id_tipo_evento + "\" }";
        }
    }
}
