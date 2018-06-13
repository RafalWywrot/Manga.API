using AutoMapper;
using Manga.DATA.DAL;
using Manga.DATA.Dto;
using Manga.DATA.Entities;
using Manga.SERVICES.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.SERVICES.Services.Implementations
{
    public class TeacherService : BaseService, ITeacherService
    {
        public void AddTeacher(TeacherDTO teacherDTO)
        {
            var teacher = Mapper.Map<Teacher>(teacherDTO);
            context.Teachers.Add(teacher);
            SaveChanges();
        }

        public TeacherDTO GetTeacher(int id)
        {
            var teacher = context.Teachers.Find(id);
            return Mapper.Map<TeacherDTO>(teacher);
        }

        public IList<TeacherDTO> GetTeachers()
        {
            var teachers = context.Teachers.ToList();
            return Mapper.Map<IList<TeacherDTO>>(teachers);
        }

        public Guid GetTeacherUserId(int teacherId)
        {
            var teacher = context.Teachers.Find(teacherId);
            return teacher.UserId;
        }

        public void RemoveTeacher(int id)
        {
            var userTeacher = context.Teachers.Where(x => x.Id == id).Select(x => x.User).FirstOrDefault();
            context.Users.Remove(userTeacher);
            SaveChanges();
        }

        public void SaveTeacher(TeacherDTO teacherDTO)
        {
            var teacher = context.Teachers.Where(x => x.Id == teacherDTO.Id).Select(
                x => x.User).FirstOrDefault();

            teacher.Email = teacherDTO.Email;
            teacher.Name = teacherDTO.Name;
            teacher.Surname = teacherDTO.Lastname;
            SaveChanges();
        }
    }
}
