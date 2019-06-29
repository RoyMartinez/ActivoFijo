namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class proformacab
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
