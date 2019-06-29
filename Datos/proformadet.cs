namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class proformadet
    {
        public int id { get; set; }
        public Nullable<int> cabecera { get; set; }
        public Nullable<int> fila { get; set; }
        public string descripcion { get; set; }
    
        public virtual proformacab proformacab { get; set; }
    }
}
