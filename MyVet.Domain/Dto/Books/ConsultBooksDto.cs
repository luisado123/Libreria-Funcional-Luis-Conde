using System;
using System.Collections.Generic;
using System.Text;

namespace MyVet.Domain.Dto.Books
{

        public class ConsultBooksDto : BookDto
        {
            public string estado { get; set; }

        public string TypeBook { get; set; }
        public string StrLaunchDate { get; set; }
            public string StrPreLaunchDate { get; set; }
        }
    }


