using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.DATA.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public Guid userId { get; set; }
        public string City { get; set; }
        public string CodePostal { get; set; }
        [ForeignKey("Province")]
        public int ProvinceId { get; set; }
        [ForeignKey("Gender")]
        public int GenderId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public virtual Province Province { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual User User { get; set; }
    }
}
