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
    public class StudentService : BaseService, IStudentService
    {
        public void AddStudent(StudentDTO studentDTO)
        {
            var student = Mapper.Map<Student>(studentDTO);
            context.Students.Add(student);
            SaveChanges();
        }
        public IEnumerable<ProvinceDTO> GetProvinces()
        {
            var provinces = context.Provinces.ToList();
            var provincesDTO = Mapper.Map<IList<ProvinceDTO>>(provinces);
            return provincesDTO;
        }
        public IEnumerable<GenderDTO> GetGenders()
        {
            var genders = context.Genders.ToList();
            var gendersDTO = Mapper.Map<IList<GenderDTO>>(genders);
            return gendersDTO;
        }

        public IList<StudentDTO> GetStudents()
        {
            var students = context.Students.ToList();
            return Mapper.Map<IList<StudentDTO>>(students);
        }

        public StudentDTO GetStudent(int id)
        {
            var student = context.Students.Where(x => x.Id == id).FirstOrDefault();
            return Mapper.Map<StudentDTO>(student);
        }

        public void RemoveStudent(int id)
        {
            var student = context.Students.Where(x => x.Id == id).FirstOrDefault();
            context.Students.Remove(student);
            SaveChanges();
        }

        public Guid GetStudentUserId(int id)
        {
            var student = context.Students.Find(id);
            return student.userId;
        }

        public void UpdateStudent(StudentDTO studentDTO)
        {
            var student = context.Students.Find(studentDTO.Id);
            student.User.Name = studentDTO.Name;
            student.User.Surname = studentDTO.Surname;
            student.User.Email = studentDTO.Email;
            student.Address = studentDTO.Address;
            student.City = studentDTO.City;
            student.CodePostal = studentDTO.CodePostal;
            student.GenderId = studentDTO.GenderId;
            student.PhoneNumber = studentDTO.PhoneNumber;
            student.ProvinceId = studentDTO.ProvinceId;
            SaveChanges();
        }
    }
}
