using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVet.Domain.Dto.Books
{
    public class InsertBooksDto
    {
        public DateTime Date { get; set; }
        [MaxLength(100)]
        public string AuthorName{ get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }

        public int IdTypeBook { get; set; }
        //public int IdState { get; set; }
               
        public int IdEditorial { get; set; }

    }
}
