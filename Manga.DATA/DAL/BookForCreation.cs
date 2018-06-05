using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Manga.DATA.DAL
{
    public class BookForCreation
    {
        [Required]
        [MaxLength(60)]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
