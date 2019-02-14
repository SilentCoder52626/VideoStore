namespace VideoStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Rental
    {
        
        public int Id { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }

        [Required]
        public Movies Movies { get; set; }

        [Required]
        public Customers Customers { get; set; }
        
        

        

    }
}
