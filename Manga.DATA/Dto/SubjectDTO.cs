using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.DATA.Dto
{
    public class SubjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<TeacherDTO> Teachers { get; set; }
        public List<int> SelectedTeachers { get; set; }
    }
}
