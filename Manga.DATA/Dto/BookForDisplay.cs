using System;
using System.Collections.Generic;
using System.Text;

namespace Manga.DATA.Dto
{
    public class BookForDisplay
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}
