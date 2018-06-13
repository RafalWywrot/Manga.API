using Manga.DATA.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.SERVICES.Services.Interfaces
{
    public interface IStudentService
    {
        StudentDTO GetStudent(int id);
        Guid GetStudentUserId(int id);
        IList<StudentDTO> GetStudents();
        void AddStudent(StudentDTO studentDTO);
        void RemoveStudent(int id);
        void UpdateStudent(StudentDTO student);
        IEnumerable<ProvinceDTO> GetProvinces();
        IEnumerable<GenderDTO> GetGenders();
    }
}
