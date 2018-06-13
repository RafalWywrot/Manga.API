using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.DATA.Dto
{
    public class GradesNameDTO
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string SubjectName { get; set; }
        public string TeacherName { get; set; }
        public double Grade { get; set; }
    }
}
