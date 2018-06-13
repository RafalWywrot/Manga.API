using Manga.DATA.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.SERVICES.Services.Interfaces
{
    public interface IGradeService
    {
        IList<GradeDTO> GetGrades();
        void SaveGrade(SaveGradeDTO gradeDTO);
        List<GradesNameDTO> GetAllGrades();
        void RemoveGrade(int gradesID);
        GradesDTO GetAssessment(int gradesID);
        void EditGrade(SaveGradeDTO gradeDTO);
    }
}
