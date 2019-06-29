namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public empleado()
        {
            this.catalogo = new HashSet<catalogo>();
            this.movimiento = new HashSet<movimiento>();
            this.movimiento1 = new HashSet<movimiento>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public string puesto { get; set; }
        public string codigo { get; set; }
        public Nullable<int> oficina { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<catalogo> catalogo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<movimiento> movimiento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<movimiento> movimiento1 { get; set; }
        public virtual oficina oficina1 { get; set; }
    }
}
