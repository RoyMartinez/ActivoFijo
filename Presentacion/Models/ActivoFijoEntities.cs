using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace Presentacion.Models
{
    public class ActivoFijoEntities: DbContext
    {
        public ActivoFijoEntities()
            : base("name=ActivoFijoEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<catalogo> catalogo { get; set; }
        public virtual DbSet<departamento> departamento { get; set; }
        public virtual DbSet<empleado> empleado { get; set; }
        public virtual DbSet<empresa> empresa { get; set; }
        public virtual DbSet<factura> factura { get; set; }
        public virtual DbSet<movimiento> movimiento { get; set; }
        public virtual DbSet<oficina> oficina { get; set; }
        public virtual DbSet<proformacab> proformacab { get; set; }
        public virtual DbSet<proformadet> proformadet { get; set; }
        public virtual DbSet<proveedor> proveedor { get; set; }
        public virtual DbSet<seguro> seguro { get; set; }
        public virtual DbSet<subtipoactivo> subtipoactivo { get; set; }
        public virtual DbSet<tipoactivo> tipoactivo { get; set; }
        public virtual DbSet<tipomovimiento> tipomovimiento { get; set; }
        public virtual DbSet<tipousuario> tipousuario { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
    }
}