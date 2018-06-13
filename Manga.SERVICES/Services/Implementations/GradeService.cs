using AutoMapper;
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
    public class GradeService : BaseService, IGradeService
    {
        public IList<GradeDTO> GetGrades()
        {
            var grades = context.Grade.ToList();
            return Mapper.Map<IList<GradeDTO>>(grades);
        }

        public void SaveGrade(SaveGradeDTO gradeDTO)
        {

            if (!context.Grades.Any(x =>
                x.StudentId == gradeDTO.StudentId &&
                x.SubjectId == gradeDTO.SubjectId &&
                x.TeacherId == gradeDTO.TeacherId))
            {
                var grade = new Grades()
                {
                    StudentId = gradeDTO.StudentId,
                    SubjectId = gradeDTO.SubjectId,
                    TeacherId = gradeDTO.TeacherId,
                    GradeId = gradeDTO.GradeId
                };
                context.Grades.Add(grade);
                SaveChanges();
            }
            else
            {
                var grade = context.Grades.Where(x =>
                    x.StudentId == gradeDTO.StudentId &&
                    x.SubjectId == gradeDTO.SubjectId &&
                    x.TeacherId == gradeDTO.TeacherId).FirstOrDefault();
                grade.GradeId = gradeDTO.GradeId;
                SaveChanges();
            }
        }
        public List<GradesNameDTO> GetAllGrades()
        {
            var grades = context.Grades.Select(
                x => new GradesNameDTO()
                {
                    Id = x.Id,
                    StudentName = x.Student.User.Name,
                    SubjectName = x.Subject.Name,
                    TeacherName = x.Teacher.User.Name,
                    Grade = x.Grade.Value
                }).ToList();
            return grades;
        }

        public void RemoveGrade(int gradesID)
        {
            var grade = context.Grades.Where(x => x.Id == gradesID).FirstOrDefault();
            context.Grades.Remove(grade);
            SaveChanges();
        }

        public GradesDTO GetAssessment(int gradesID)
        {
            var grade = context.Grades.Where(x => x.Id == gradesID).FirstOrDefault();
            return Mapper.Map<GradesDTO>(grade);
        }

        public void EditGrade(SaveGradeDTO gradeDTO)
        {
            var grade = context.Grades.Where(x => x.Id == gradeDTO.Id).FirstOrDefault();
            grade.TeacherId = gradeDTO.TeacherId;
            grade.GradeId = gradeDTO.GradeId;
            if (!context.Grades.Any(x =>
                x.StudentId == grade.StudentId &&
                x.SubjectId == grade.SubjectId &&
                x.TeacherId == grade.TeacherId &&
                x.GradeId == grade.GradeId))
            {
                SaveChanges();
            }
        }
    }
}
