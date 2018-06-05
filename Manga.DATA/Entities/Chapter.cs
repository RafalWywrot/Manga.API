using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Manga.DATA.Entities
{
    public class Chapter
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }

        [ForeignKey("Book")]
        public Guid BookId { get; set; }


        public Book Book { get; set; }
        public ICollection<Page> Pages { get; set; }
    }
}
