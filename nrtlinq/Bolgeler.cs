//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace nrtlinq
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bolgeler
    {
        public Bolgeler()
        {
            this.Personellers = new HashSet<Personeller>();
        }
    
        public string TerritoryID { get; set; }
        public string TerritoryTanimi { get; set; }
        public int BolgeID { get; set; }
    
        public virtual Bolge Bolge { get; set; }
        public virtual ICollection<Personeller> Personellers { get; set; }
    }
}
