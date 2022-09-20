using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Models
{
    internal class ticket
    {
        public int id_ticket { get; set; }
        public string numero_silla { get; set; }
        public string fila { get; set; }
        public string precio { get; set; }
        public string id_evento { get; set; }

        public string toJson()
        {

            return "{\"numero_silla\":\"" + numero_silla + " \",\"fila\": \"" + fila + "\" , \"precio\":\"" + precio + "\" , \"id_evento\":\"" + id_evento + "\" }";
        }
    }
}
