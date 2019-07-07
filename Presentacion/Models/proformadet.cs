using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.Models
{
    public class proformadet
    {
        public int id { get; set; }
        public Nullable<int> cabecera { get; set; }
        public Nullable<int> fila { get; set; }
        public string descripcion { get; set; }

        public virtual proformacab proformacab { get; set; }
    }
}