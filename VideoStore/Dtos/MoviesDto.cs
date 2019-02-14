using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoStore.Dtos
{
    public class MoviesDto
    {
         public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public byte MoviesGenreId { get; set; }

        public MoviesGenreDto MoviesGenre { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime DateAdded { get; set; } 
        
        [Required]
        [Range(1,20)]
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }



    }
}