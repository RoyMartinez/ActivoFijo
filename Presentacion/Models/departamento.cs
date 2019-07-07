using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.Models
{
    public class departamento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public departamento()
        {
            this.oficina = new HashSet<oficina>();
        }

        public int id { get; set; }
        public Nullable<int> empresa { get; set; }
        public string nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<oficina> oficina { get; set; }
        public virtual empresa empresa1 { get; set; }
    }
}