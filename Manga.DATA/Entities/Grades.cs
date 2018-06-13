using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.DATA.Entities
{
    public class Grades
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Student")]
        public int StudentId{ get; set; }
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        [ForeignKey("Grade")]
        public int GradeId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
