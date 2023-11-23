using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace MVCApplicationSchoolDB.Models
{

    [Table("StudentClass")]
    public class StudentClass
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FName { get; set; }

        [Required]
        [StringLength(50)]
        public string LName { get; set; }
        public int CId { get; set; }
        public virtual Class Classes { get; set; }
        public int SubId { get; set; }
        [JsonIgnore]
        public virtual Subject Subjects { get; set; }
    }
}