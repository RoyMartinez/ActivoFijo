using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.Models
{
    public class factura
    {
        public int id { get; set; }
        public string numerofactura { get; set; }
        public Nullable<int> proveedor { get; set; }
        public Nullable<System.DateTime> fechaemision { get; set; }
        public Nullable<System.DateTime> fechaingreso { get; set; }

        public virtual proveedor proveedor1 { get; set; }
    }
}