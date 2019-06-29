namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class tipoactivo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tipoactivo()
        {
            this.subtipoactivo = new HashSet<subtipoactivo>();
        }
    
        public int id { get; set; }
        public string descripcion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<subtipoactivo> subtipoactivo { get; set; }
    }
}
