using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVet.Domain.Dto
{
    public class BookDto
    {
        [Key]
        public int IdBook { get; set; }

    

        [Required(ErrorMessage = "la Descripcion es requerida")]
        [MaxLength(300)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "El nombre del Autor es Obligatorio")]
        [MaxLength(100)]
        [Display(Name = "Autor")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "El nombre del Libro es Obligatorio")]
        [MaxLength(100)]
        [Display(Name = "BookName")]
        public string Name { get; set; }

        public DateTime? DatePreRelease { get; set; }
        public DateTime? DateRelease { get; set; }
        public int  IdState { get; set; }
       
        public int IdTypeBook { get; set; }
        public string State { get; set; }

        public string TypeBook { get; set; }

        public int IdEditorial { get; set; }





    }
}