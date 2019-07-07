using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.Models
{
    public class movimiento
    {
        public int id { get; set; }
        public Nullable<int> tipomovimiento { get; set; }
        public Nullable<int> empleadoorigen { get; set; }
        public Nullable<int> empleadodestino { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<int> tiempoduracion { get; set; }

        public virtual empleado empleado { get; set; }
        public virtual empleado empleado1 { get; set; }
        public virtual tipomovimiento tipomovimiento1 { get; set; }
    }
}