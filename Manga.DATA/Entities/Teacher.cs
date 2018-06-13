using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.DATA.Entities
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Linq_Subject_Teacher> SubjectTeachers { get; set; }
    }
}
