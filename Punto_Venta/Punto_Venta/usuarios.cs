//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Punto_Venta
{
    using System;
    using System.Collections.Generic;
    
    public partial class usuarios
    {
        public usuarios()
        {
            this.compras = new HashSet<compras>();
            this.ventas = new HashSet<ventas>();
        }
    
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public string Privilegio { get; set; }
        public string Status { get; set; }
        public int Empleados_id { get; set; }
    
        public virtual ICollection<compras> compras { get; set; }
        public virtual empleados empleados { get; set; }
        public virtual ICollection<ventas> ventas { get; set; }
    }
}