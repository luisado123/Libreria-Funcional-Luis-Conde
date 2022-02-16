using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Vet
{
    [Table("TypeBook", Schema = "Library")]
    public class TypeBookEntity
    {
        [Key]
        public int Id { get; set; }
       
        
        [MaxLength(100)]
        public string TypeBook { get; set; }
    }
}
