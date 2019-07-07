﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Presentacion.Models
{
    public class seguro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public seguro()
        {
            this.catalogo = new HashSet<catalogo>();
        }

        public int id { get; set; } 
        [DisplayName("Numero de Seguro")]
        public string numero { get; set; }
        public Nullable<int> empresa { get; set; }
        public Nullable<int> tiempo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<catalogo> catalogo { get; set; }
        public virtual empresa empresa1 { get; set; }
    }
}