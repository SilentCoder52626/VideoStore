//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VideoStore.App_Start
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerFormViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerFormViewModel()
        {
            this.MembershipTypes = new HashSet<MembershipType>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime BirthDate { get; set; }
        public bool IsSubscribed { get; set; }
        public byte MembershipTypeId { get; set; }
    
        public virtual MembershipType MembershipType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MembershipType> MembershipTypes { get; set; }
    }
}
