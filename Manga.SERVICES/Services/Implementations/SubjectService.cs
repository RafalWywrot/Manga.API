using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Manga.DATA.Dto;
using Manga.DATA.Entities;
using Manga.SERVICES.Services.Interfaces;

namespace Manga.SERVICES.Services.Implementations
{
    public class SubjectService : BaseService, ISubjectService
    {
        public void AddSubject(SubjectDTO subjectDTO)
        {
            try
            {
                var subject = new Subject()
                {
                    Name = subjectDTO.Name,
                };
                context.Subjects.Add(subject);
                SaveChanges();
                foreach (var teacherId in subjectDTO.SelectedTeachers)
                {
                    /*Mapper.Map<Subject>(subjectDTO);*/
                    //var teacher = Mapper.Map<Teacher>(teacherId);
                    var subjectTeacher = new Linq_Subject_Teacher()
                    {
                        SubjectID = subject.Id,
                        TeacherID = teacherId
                    };
                    context.Subject_Teachers.Add(subjectTeacher);
                }
                SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public SubjectDTO GetSubject(int id)
        {
            var subject = context.Subjects.Where(x => x.Id == id)
                .Select(x => new
                {
                    Subject = x,
                    Teachers = x.SubjectTeachers.Select(m => m.Teacher)
                }).FirstOrDefault();
            var teachers = Mapper.Map<IList<TeacherDTO>>(context.Teachers.ToList());
            var subjectDTO = new SubjectDTO()
            {
                Id = subject.Subject.Id,
                Name = subject.Subject.Name,
                Teachers = teachers
            };
            List<int> selectedTeachers = subject.Teachers.Select(x => x.Id).ToList();
            foreach (var subjectSelect in subjectDTO.Teachers)
            {
                subjectSelect.Selected = selectedTeachers.Contains(subjectSelect.Id);
            }
            return Mapper.Map<SubjectDTO>(subjectDTO);
        }

        public IList<SubjectDTO> GetSubjects()
        {
            var subjects = context.Subjects.ToList();
            return Mapper.Map<IList<SubjectDTO>>(subjects);
        }

        public void UpdateSubject(SubjectDTO subjectDTO)
        {
            try
            {
                var subject = context.Subjects.Where(x => x.Id == subjectDTO.Id).FirstOrDefault();
                subject.SubjectTeachers.Clear();
                if (subjectDTO.SelectedTeachers != null)
                {
                    foreach (var teacherId in subjectDTO.SelectedTeachers)
                    {
                        /*Mapper.Map<Subject>(subjectDTO);*/
                        //var teacher = Mapper.Map<Teacher>(teacherId);
                        var subjectTeacher = new Linq_Subject_Teacher()
                        {
                            SubjectID = subject.Id,
                            TeacherID = teacherId
                        };
                        context.Subject_Teachers.Add(subjectTeacher);
                    }
                }
                SaveChanges();
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public void RemoveSubject(int id)
        {
            try
            {
                var subject = context.Subjects.Find(id);
                subject.SubjectTeachers.Clear();
                context.Subjects.Remove(subject);
                SaveChanges();
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
