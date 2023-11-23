using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCApplicationSchoolDB.Models
{

    [Table("Class")]
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        [Required]
        [StringLength(50)]
        public string CName { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<StudentClass> StudentClasses { get; set; }
    }
}