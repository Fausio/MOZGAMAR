//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MOZGAMAR.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cart
    {
        public int CartId { get; set; }
        public Nullable<int> PoductId { get; set; }
        public Nullable<int> MemberID { get; set; }
        public Nullable<int> CarStatusId { get; set; }
    
        public virtual Poduct Poduct { get; set; }
    }
}
