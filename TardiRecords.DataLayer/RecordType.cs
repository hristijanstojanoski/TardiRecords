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
    
    public partial class RecordType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RecordType()
        {
            this.AllowedTypesForUser = new HashSet<AllowedTypesForUser>();
        }
    
        public System.Guid id { get; set; }
        public string name { get; set; }
        public int subType { get; set; }
        public bool isEnabled { get; set; }
        public bool isDeleted { get; set; }
        public string createdBy { get; set; }
        public System.DateTime createdDate { get; set; }
        public string modifiedBy { get; set; }
        public System.DateTime modifyDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AllowedTypesForUser> AllowedTypesForUser { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual AspNetUsers AspNetUsers1 { get; set; }
    }
}
