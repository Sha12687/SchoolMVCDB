using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MVCApplicationSchoolDB.Data;
using MVCApplicationSchoolDB.Models;

namespace MVCApplicationSchoolDB.Controllers
{
    public class StudentClasses1Controller : ApiController
    {
        private RainbowSchoolDBContext db = new RainbowSchoolDBContext();

        // GET: api/StudentClasses1
        public IQueryable<StudentClass> GetStudentClass()
        {
            return db.StudentClass;
        }

        // GET: api/StudentClasses1/5
        [ResponseType(typeof(StudentClass))]
        public IHttpActionResult GetStudentClass(int id)
        {
            StudentClass studentClass = db.StudentClass.Find(id);
            if (studentClass == null)
            {
                return NotFound();
            }

            return Ok(studentClass);
        }

        // PUT: api/StudentClasses1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudentClass(int id, StudentClass studentClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentClass.Id)
            {
                return BadRequest();
            }

            db.Entry(studentClass).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentClassExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/StudentClasses1
        [ResponseType(typeof(StudentClass))]
        public IHttpActionResult PostStudentClass(StudentClass studentClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StudentClass.Add(studentClass);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = studentClass.Id }, studentClass);
        }

        // DELETE: api/StudentClasses1/5
        [ResponseType(typeof(StudentClass))]
        public IHttpActionResult DeleteStudentClass(int id)
        {
            StudentClass studentClass = db.StudentClass.Find(id);
            if (studentClass == null)
            {
                return NotFound();
            }

            db.StudentClass.Remove(studentClass);
            db.SaveChanges();

            return Ok(studentClass);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentClassExists(int id)
        {
            return db.StudentClass.Count(e => e.Id == id) > 0;
        }
    }
}