using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.Models
{
    public class catalogo
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> subtipoactivo { get; set; }
        public Nullable<int> empleado { get; set; }
        public Nullable<int> oficina { get; set; }
        public Nullable<int> seguro { get; set; }

        public virtual empleado empleado1 { get; set; }
        public virtual oficina oficina1 { get; set; }
        public virtual seguro seguro1 { get; set; }
        public virtual subtipoactivo subtipoactivo1 { get; set; }
    }
}