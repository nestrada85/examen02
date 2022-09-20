using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Models
{
    internal class compra
    {
        public int id_compra { get; set; }
        public string id_membresia { get; set; }
        public string id_ticket { get; set; }
        public string fecha_compra { get; set; }


        public string toJson()
        {

            return "{\"id_membresia\":\"" + id_membresia + " \",\"id_ticket\": \"" + id_ticket + "\" , \"fecha_compra\":\"" + fecha_compra + "\" }";
        }
    }
}
