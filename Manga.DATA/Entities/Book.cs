using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Manga.DATA.Entities
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; }

        public ICollection<Chapter> Chapters { get; set; }
    }
}
