namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class factura
    {
        public int id { get; set; }
        public string numerofactura { get; set; }
        public Nullable<int> proveedor { get; set; }
        public Nullable<System.DateTime> fechaemision { get; set; }
        public Nullable<System.DateTime> fechaingreso { get; set; }
    
        public virtual proveedor proveedor1 { get; set; }
    }
}
