
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCApplicationSchoolDB.Data
{
    public class RainbowSchoolDBContext : DbContext
    {
        public RainbowSchoolDBContext() : base("name=RainbowSchoolDBContext")
        {
        }

        public DbSet<MVCApplicationSchoolDB.Models.Class> Class { get; set; }

        public DbSet<MVCApplicationSchoolDB.Models.StudentClass> StudentClass { get; set; }

        public DbSet<MVCApplicationSchoolDB.Models.Subject> Subject { get; set; }
    }
}