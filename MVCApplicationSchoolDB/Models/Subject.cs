using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCApplicationSchoolDB.Models
{
    [Table("Subject")]
    public class Subject
    {
        [Key]
        public int SubId { get; set; }

        [Required]
        [StringLength(50)]
        public string SubName { get; set; }
        public int CId { get; set; }
        public virtual Class Classes { get; set; }
        public virtual ICollection<StudentClass> StudentClasses { get; set; }
    }
}