using Infraestructure.Entity.Model;
using Infraestructure.Entity.Model.Master;
using Infraestructure.Entity.Models.Library;
using Infraestructure.Entity.Vet;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Library
{
  
        [Table("Book", Schema = "Library")]
        public class BooksEntity
        {
            [Key]
            public int IdBook { get; set; }
            public DateTime DatePreRealease { get; set; }


            [ForeignKey("TypeBookEntity")]
            public int IdTypeBook { get; set; }
            public TypeBookEntity TypeBookEntity { get; set; }
            [MaxLength(100)]
            public string Name { get; set; }
            [MaxLength(100)]
            public string AuthorName { get; set; }

            public DateTime? DateRelease { get; set; }

            [MaxLength(300)]
            public string Description { get; set; }


            [ForeignKey("StateEntity")]
            public int IdState { get; set; }
            public StateEntity StateEntity { get; set; }



        [ForeignKey("EditorialEntity")]
        public int IdEditorial { get; set; }

        public EditorialEntity EditorialEntity { get; set; }


    }
    }
