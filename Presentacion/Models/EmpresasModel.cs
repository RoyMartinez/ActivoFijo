using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datos;

namespace Presentacion.Models
{
    public class EmpresasModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmpresasModel()
        {
            this.departamento = new HashSet<departamento>();
            this.seguro = new HashSet<seguro>();
        }

        public int id { get; set; }
        public string nombre { get; set; }
        public string ruc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<departamento> departamento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<seguro> seguro { get; set; }
    }
}