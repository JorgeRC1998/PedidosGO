//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PedidosGO.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BANK_ACCOUNT
    {
        public string CuentaID { get; set; }
        public string Tipo { get; set; }
        public long NumeroCuenta { get; set; }
        public Nullable<int> Ultimos4Dig { get; set; }
        public Nullable<System.DateTime> FechaVence { get; set; }
        public int UserID { get; set; }
        public string CodigoSegu { get; set; }
    
        public virtual USERS USERS { get; set; }
    }
}
