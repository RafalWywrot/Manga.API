using Manga.DATA.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.SERVICES.Services.Interfaces
{
    public interface ISubjectService
    {
        IList<SubjectDTO> GetSubjects();
        SubjectDTO GetSubject(int id);
        void AddSubject(SubjectDTO subjectDTO);
        void RemoveSubject(int id);
        void UpdateSubject(SubjectDTO subject);
    }
}
