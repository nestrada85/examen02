using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Models
{
    internal class tipo_evento
    {
        public int id_tipo_evento { get; set; }
        public string descripcion { get; set; }
        
        public string toJson()
        {

            return "{\"descripcion\":\"" + descripcion + " \"}";
        }
    }
}
