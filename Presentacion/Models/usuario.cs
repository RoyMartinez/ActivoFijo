namespace Presentacion.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class usuario
    {
        public int id { get; set; }
        public string usuario1 { get; set; }
        public string contrasena { get; set; }
        public Nullable<int> tipo { get; set; }
    
        public virtual tipousuario tipousuario { get; set; }
    }
}
