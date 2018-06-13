using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.DATA.Entities
{
    public class Grade
    {
        [Key]
        public int Id { get; set; }
        public double Value { get; set; }
    }
}
