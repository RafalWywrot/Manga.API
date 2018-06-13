using AutoMapper;
using Manga.DATA.Dto;
using Manga.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manga.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProvinceDTO, Province>();
            CreateMap<Province, ProvinceDTO>();

            CreateMap<GenderDTO, Gender>();
            CreateMap<Gender, GenderDTO>();

            CreateMap<Student, StudentDTO>()
                .ForMember(
                    dest => dest.ProvinceName,
                    opt => opt.MapFrom(x => x.Province.Name)
                )
                .ForMember(
                    dest => dest.Gendername,
                    opt => opt.MapFrom(x => x.Gender.Name)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(x => x.User.Name)
                )
                .ForMember(
                    dest => dest.Surname,
                    opt => opt.MapFrom(x => x.User.Surname))
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(x => x.User.Email)
                );
            CreateMap<StudentDTO, Student>()
                .ForMember(
                    dest => dest.User,
                    opt => opt.MapFrom(x => new User()
                    {
                        Name = x.Name,
                        Surname = x.Surname,
                        Email = x.Email
                    })
                );
            CreateMap<Teacher, TeacherDTO>()
                .ForMember(
                    dest => dest.Lastname,
                    opt => opt.MapFrom(x => x.User.Surname))
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(x => x.User.Name))
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(x => x.User.Email)
                );
            CreateMap<TeacherDTO, Teacher>()
                .ForMember(
                    dest => dest.User,
                    opt => opt.MapFrom(x => new User()
                    {
                        Name = x.Name,
                        Surname = x.Lastname,
                        Email = x.Email
                    })
                );

            CreateMap<Subject, SubjectDTO>();
            CreateMap<SubjectDTO, Subject>();

            CreateMap<GradeDTO, Grade>();
            CreateMap<Grade, GradeDTO>();
            CreateMap<GradesNameDTO, Grades>();
            CreateMap<Grades, GradesNameDTO>();
            CreateMap<GradesDTO, Grades>();
            CreateMap<Grades, GradesDTO>();
        }
    }
}