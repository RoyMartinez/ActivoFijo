namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class subtipoactivo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public subtipoactivo()
        {
            this.catalogo = new HashSet<catalogo>();
        }
    
        public int id { get; set; }
        public Nullable<int> tipoactivo { get; set; }
        public string descripcion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<catalogo> catalogo { get; set; }
        public virtual tipoactivo tipoactivo1 { get; set; }
    }
}
