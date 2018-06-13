using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.DATA.Entities
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        //[ForeignKey("Teacher")]
        //public int TeacherId { get; set; }
        public virtual ICollection<Linq_Subject_Teacher> SubjectTeachers { get; set; }
    }
}
