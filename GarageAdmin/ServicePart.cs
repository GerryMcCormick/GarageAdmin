//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GarageAdmin
{
    using System;
    using System.Collections.Generic;
    
    public partial class ServicePart
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ServiceId { get; set; }
        public int PartId { get; set; }
    
        public virtual Service Service { get; set; }
        public virtual Part Part { get; set; }
    }
}
