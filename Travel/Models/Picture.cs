//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Travel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Picture
    {
        public int PictureId { get; set; }
        public string PicturesURL { get; set; }
    
        public virtual Site Site { get; set; }
    }
}
