//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MagazadbMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kargo
    {
        public int KargoNo { get; set; }
        public string KargoAd { get; set; }
        public Nullable<int> UrunNo { get; set; }
    
        public virtual Urunler Urunler { get; set; }
    }
}
