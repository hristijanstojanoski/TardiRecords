//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TardiRecords.DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class BackupLocations
    {
        public System.Guid id { get; set; }
        public System.Guid machineId { get; set; }
        public System.Guid dbId { get; set; }
        public string createdBy { get; set; }
        public System.DateTime createdDate { get; set; }
        public string modifyBy { get; set; }
        public System.DateTime modifyDate { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual AspNetUsers AspNetUsers1 { get; set; }
        public virtual DBs DBs { get; set; }
        public virtual Machine Machine { get; set; }
    }
}
