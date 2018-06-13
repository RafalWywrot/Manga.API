using Manga.DATA.Dto;
using Manga.SERVICES.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Manga.API.Controllers
{
    public class UniversityController : ApiController
    {
        private IStudentService studentService;
        private ITeacherService teacherService;
        private IUserService userService;
        private ISubjectService subjectService;
        private IGradeService gradeService;
        public UniversityController(IStudentService StudentService, ITeacherService TeacherService, IUserService UserService, ISubjectService SubjectService, IGradeService GradeService)
        {
            studentService = StudentService;
            teacherService = TeacherService;
            userService = UserService;
            subjectService = SubjectService;
            gradeService = GradeService;
        }
        #region student
        [HttpGet]
        public IHttpActionResult GetStudents()
        {
            var students = studentService.GetStudents();
            return Ok(students);
        }
        [HttpGet]
        public IHttpActionResult GetStudent(int id)
        {
            var studentDTO = studentService.GetStudent(id);
            return Ok(studentDTO);
        }
        // GET: University
        [HttpPost]
        public IHttpActionResult AddStudent(StudentDTO studentDTO)
        {
            studentService.AddStudent(studentDTO);
            return Ok();
        }
        [HttpPost]
        public IHttpActionResult SaveStudent(StudentDTO studentDTO)
        {
            studentService.UpdateStudent(studentDTO);
            return Ok();
        }
        [HttpPost]
        public IHttpActionResult RemoveStudent(RemoveIdDTO student)
        {
            var userId = studentService.GetStudentUserId(student.Id);
            userService.removeUser(userId);
            return Ok();
        }
        #endregion
        #region
        public IHttpActionResult GetTeachers()
        {
            var teachers = teacherService.GetTeachers();
            return Ok(teachers);
        }
        public IHttpActionResult GetTeacher(int id)
        {
            var teacher = teacherService.GetTeacher(id);
            return Ok(teacher);
        }
        [HttpPost]
        public IHttpActionResult AddTeacher(TeacherDTO teacherDTO)
        {
            teacherService.AddTeacher(teacherDTO);
            return Ok();
        }
        [HttpPost]
        public IHttpActionResult SaveTeacher(TeacherDTO teacherDTO)
        {
            teacherService.SaveTeacher(teacherDTO); 
            return Ok();
        }
        [HttpPost]
        public IHttpActionResult RemoveTeacher(RemoveIdDTO teacher)
        {
            var userId = teacherService.GetTeacherUserId(teacher.Id);
            userService.removeUser(userId);
            return Ok();
        }
        #endregion
        [HttpGet]
        public IHttpActionResult GetSubjects()
        {
            var subjects = subjectService.GetSubjects();
            return Ok(subjects);
        }
        [HttpGet]
        public IHttpActionResult GetSubject(int id)
        {
            var subjects = subjectService.GetSubject(id);
            return Ok(subjects);
        }
        [HttpPost]
        public IHttpActionResult AddSubject(SubjectDTO subject)
        {
            subjectService.AddSubject(subject);
            return Ok();
        }
        [HttpPost]
        public IHttpActionResult UpdateSubject(SubjectDTO subject)
        {
            subjectService.UpdateSubject(subject);
            return Ok();
        }
        [HttpPost]
        public IHttpActionResult RemoveSubject(RemoveIdDTO subject)
        {
            subjectService.RemoveSubject(subject.Id);
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult GetAllGrades()
        {
            var grades = gradeService.GetAllGrades();
            return Ok(grades);
        }
        [HttpGet]
        public IHttpActionResult GetDataForCreateGrade()
        {
            var dataGrade = new DataForCreateGrade()
            {
                students = studentService.GetStudents(),
                subjects = subjectService.GetSubjects(),
                teachers = teacherService.GetTeachers(),
                grades = gradeService.GetGrades()
            };
            return Ok(dataGrade);
        }
        [HttpPost]
        public IHttpActionResult CreateGradeForStudent(SaveGradeDTO gradeDTO)
        {
            gradeService.SaveGrade(gradeDTO);
            return Ok();
        }
        [HttpPost]
        public IHttpActionResult DeleteGradeAssessment(RemoveIdDTO grades)
        {
            gradeService.RemoveGrade(grades.Id);
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult GetAssessment(int id)
        {
            var grade = gradeService.GetAssessment(id);
            return Ok(grade);
        }
        [HttpPost]
        public IHttpActionResult UpdateGrades(SaveGradeDTO gradeDTO)
        {
            gradeService.EditGrade(gradeDTO);
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult GetProvinces()
        {
            var provinces = studentService.GetProvinces();
            return Ok(provinces);
        }
        [HttpGet]
        public IHttpActionResult GetGenders()
        {
            var genders = studentService.GetGenders();
            return Ok(genders);
        }
    }
}