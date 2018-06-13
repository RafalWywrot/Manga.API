using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.DATA.Entities
{
    public class Linq_Subject_Teacher
    {
        [Key, Column(Order = 0)]
        public int SubjectID { get; set; }
        [Key, Column(Order = 1)]
        public int TeacherID { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
