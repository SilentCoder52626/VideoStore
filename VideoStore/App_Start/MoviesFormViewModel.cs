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
    
    public partial class MoviesFormViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MoviesFormViewModel()
        {
            this.MoviesGenres = new HashSet<MoviesGenre>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int NumberInStock { get; set; }
        public byte MoviesGenreId { get; set; }
    
        public virtual MoviesGenre MoviesGenre { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MoviesGenre> MoviesGenres { get; set; }
    }
}
