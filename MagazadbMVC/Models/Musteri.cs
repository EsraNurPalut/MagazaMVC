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
    
    public partial class Musteri
    {
        public int MusteriNo { get; set; }
        public string MusteriAd { get; set; }
        public string MusteriAdres { get; set; }
        public Nullable<int> UrunNo { get; set; }
        public Nullable<int> MagazaNo { get; set; }
    
        public virtual Magaza Magaza { get; set; }
        public virtual Urunler Urunler { get; set; }
    }
}