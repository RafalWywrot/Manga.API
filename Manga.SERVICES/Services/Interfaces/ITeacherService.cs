using Manga.DATA.Dto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.SERVICES.Services.Interfaces
{
    public interface ITeacherService
    {
        IList<TeacherDTO> GetTeachers();
        TeacherDTO GetTeacher(int id);
        Guid GetTeacherUserId(int teacherId);
        void AddTeacher(TeacherDTO teacherDTO);
        void RemoveTeacher(int id);
        void SaveTeacher(TeacherDTO teacherDTO);
    }
}
