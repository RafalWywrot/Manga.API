using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.DATA.Dto
{
    public class DataForCreateGrade
    {
        public IList<StudentDTO> students;
        public IList<SubjectDTO> subjects;
        public IList<TeacherDTO> teachers;
        public IList<GradeDTO> grades;
    }
}
