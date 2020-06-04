using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using MVCExampleCode.DAL;
using MVCExampleCode.Models;

namespace MVCExampleCode.Controllers
{
    public class StudentApiController : ApiController
    {
        private SchoolContext db = new SchoolContext();

        private ApiStudent convertStudentToApiStudent(Student student) {
            return new ApiStudent()
            {
                ID = student.ID,
                FirstMidName = student.FirstMidName,
                LastName = student.LastName,
                EnrollmentDate = student.EnrollmentDate,
                Secret = student.Secret
            };
        }

        // GET: api/StudentApi
        //public IQueryable<Student> GetStudents()
        public IHttpActionResult GetStudents()
        {
            var students = db.Students;
            List<ApiStudent> apistudents = new List<ApiStudent>();
            foreach (var student in students)
                apistudents.Add(convertStudentToApiStudent(student));
            
            return Json(apistudents);
        }

        // GET: api/StudentApi/5
        //[ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(int id)
        {
            Student student = db.Students.FirstOrDefault(s=>s.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            return Json(convertStudentToApiStudent(student));
        }

        // PUT: api/StudentApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.ID)
            {
                return BadRequest();
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/StudentApi
        [ResponseType(typeof(Student))]
        public async Task<IHttpActionResult> PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Students.Add(student);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = student.ID }, student);
        }

        // DELETE: api/StudentApi/5
        [ResponseType(typeof(Student))]
        public async Task<IHttpActionResult> DeleteStudent(int id)
        {
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            db.Students.Remove(student);
            await db.SaveChangesAsync();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return db.Students.Count(e => e.ID == id) > 0;
        }
    }
}