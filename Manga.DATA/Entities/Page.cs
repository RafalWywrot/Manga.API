using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manga.DATA.Entities
{
    public class Page
    {
        [Key]
        public Guid Id { get; set; }
        public byte[] Photo { get; set; }
        public Chapter Chapter { get; set; }

        [ForeignKey("Chapter")]
        public Guid ChapterId { get; set; }
    }
}
