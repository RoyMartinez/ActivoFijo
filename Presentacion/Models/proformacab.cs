using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.Models
{
    public class proformacab
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public proformacab()
        {
            this.proformadet = new HashSet<proformadet>();
        }

        public int id { get; set; }
        public Nullable<int> proveedor { get; set; }
        public string numeroserie { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<proformadet> proformadet { get; set; }
        public virtual proveedor proveedor1 { get; set; }
    }
}